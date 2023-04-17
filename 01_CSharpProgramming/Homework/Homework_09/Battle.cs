using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Homework_9
{
    /// <summary>
    /// 배틀 진행에 대한 클래스
    /// </summary>
    internal class Battle
    {
        Pokemon player, other;  // 플레이어 포켓몬, 상대 포켓몬
        bool turn;              // 턴: true(플레이어)
        Random random;          // 난수

        /// <summary>
        /// 배틀 생성자.
        /// 매개변수로 입력한 두 포켓몬으로 배틀을 생성한다
        /// </summary>
        /// <param name="player">플레이어 포켓몬</param>
        /// <param name="other">상대 포켓몬</param>
        public Battle(Pokemon player, Pokemon other)
        {
            this.player = player;
            this.other = other;
            random = new Random();
        }

        /// <summary>
        /// 배틀을 시작하는 함수
        /// </summary>
        public void StartBattle()
        {
            // 각 포켓몬의 상대로 서로를 지목한다
            player.StartBattle(other);
            other.StartBattle(player);
            Console.WriteLine(player.GetName() + " 와/과 " + other.GetName() +" 이/가 전투를 시작했다!");

            // 배틀 시작
            ShowState();
            while (CheckPokemon())  // 배틀이 지속중이라면
            {
                TurnOrder();        // 이번 라운드의 선공을 정하고
                Action();           // 선공이 행동을 취하고
                ShowState();        // 배틀 창을 보여주고
                Action();           // 후공이 행동을 취하고
                ShowState();        // 배틀 창을 보여준다
            }
        }

        /// <summary>
        /// 배틀 진행 상태를 확인하는 함수
        /// </summary>
        /// <returns>배틀 지속 여부</returns>
        bool CheckPokemon()
        {
            if (!player.IsBattle())
            {
                Console.WriteLine(player.GetName() + " 은/는 전투에서 물러났다!");
                return false;
            }
            if (!other.IsBattle())
            {
                Console.WriteLine(other.GetName() + " 은/는 전투에서 물러났다!");
                player.TakeEXP(other.GetLevel() * 10);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 라운드의 선공을 정하는 함수
        /// </summary>
        void TurnOrder()
        {
            // 스피드가 큰 쪽이 선공, 동일하다면 랜덤으로 선공
            if (player.GetStatus(true)[4] > other.GetStatus(true)[4]) turn = true;
            else if (player.GetStatus(true)[4] < other.GetStatus(true)[4]) turn = false;
            else if (random.Next(2) == 0) turn = true;
        }

        /// <summary>
        /// 배틀 중에 할 수 있는 행동
        /// </summary>
        void Action()
        {
            int num = random.Next(4);
            bool critical = random.Next(10) == 0;
            if (turn)
            {
                Console.WriteLine(player.GetName() + " 의 차례!");
                while(player.GetSkills()[num] == null)
                    num = random.Next(4);
                player.CommandPokemon(num, critical);
            }
            else
            {
                Console.WriteLine(other.GetName() + " 의 차례!");
                while (other.GetSkills()[num] == null)
                    num = random.Next(4);
                other.CommandPokemon(num, critical);
            }
            Console.WriteLine();
            Console.ReadKey();
            turn = !turn;
        }

        /// <summary>
        /// 배틀 UI
        /// </summary>
        void ShowState()
        {
            Console.Clear();
            Console.WriteLine("====================================================");
            Console.Write("||");
            Console.SetCursorPosition(30, 1);
            Console.Write("{0}", other.GetName());
            Console.SetCursorPosition(50, 1);
            Console.WriteLine("||");
            Console.Write("||");
            Console.SetCursorPosition(35, 2);
            Console.Write("{0} / {1}", other.GetHP().Item2, other.GetHP().Item1);
            Console.SetCursorPosition(50, 2);
            Console.WriteLine("||");
            Console.Write("||");
            Console.SetCursorPosition(50, 3);
            Console.WriteLine("||");
            Console.Write("||");
            Console.SetCursorPosition(50, 4);
            Console.WriteLine("||");
            Console.Write("||");
            Console.SetCursorPosition(50, 5);
            Console.WriteLine("||");
            Console.Write("||");
            Console.SetCursorPosition(10, 6);
            Console.Write("{0}", player.GetName());
            Console.SetCursorPosition(50, 6);
            Console.WriteLine("||");
            Console.Write("||");
            Console.SetCursorPosition(15, 7);
            Console.Write("{0} / {1}", player.GetHP().Item2, player.GetHP().Item1);
            Console.SetCursorPosition(50, 7);
            Console.WriteLine("||");
            Console.WriteLine("====================================================");
        }
    }
}
