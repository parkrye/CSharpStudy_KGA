using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _13.Additional
{
    internal class Partial
    {
        // <Partial type>
        // 클래스, 구조체, 인터페이스를 분할하여 구현하는 방법
        // 대구모 프로젝트에서 작업하는 경우 분산하여 구현에 유용

        // 전투 담당 player
        public partial class Player
        {
            int hp;
            public void Attack() { }
            public void Defense() { }
        }

        // 아이템 담당 player
        public partial class Player
        {
            int weigh;
            public void GetItem() { }
            public void UseItem() { }
        }

        // <Partial Method>
        // partial type에서 partioal method가 포함될 수 있음
        // 선언부와 구현부를 분리하여 구현함으로서 구현부를 숨길 수 있음

        // 선언부 : 함수가 있다는 것만 표시
        public partial class Monster
        {
            public partial void Attack();
        }

        // 구현부 : 함수를 실제로 구현
        public partial class Monster
        {
            public partial void Attack()
            {
                Console.WriteLine("Attack");
            }
        }

        public void Test()
        {
            Player player = new();
            player.Attack();
            player.GetItem();

            Monster monster = new Monster();
            monster.Attack();
        }
    }
}
