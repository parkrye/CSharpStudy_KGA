using System.ComponentModel;
using System.Xml.Linq;

namespace ProjectRPG
{
    internal class SkillStone
    {
        Skill skill;    // 배울 수 있는 스킬
        Player player;  // 플레이어
        int cursor, prevCursor;         // 커서
        bool click, inStone;            // 클릭 여부, 스킬석에 남아있는지 여부
        enum Screen { Characters, Skills }
        Screen screen;

        /// <summary>
        /// 생성자. 스킬을 지정
        /// </summary>
        /// <param name="_player">플레이어</param>
        public SkillStone(Player _player)
        {
            player = _player;
            click = false;
            inStone = true;
            cursor = 0;
            prevCursor = 0;
            screen = Screen.Characters;

            SetSkill();
        }       
        
        /// <summary>
        /// 생성자. 입력된 스킬 중 하나를 지정
        /// </summary>
        /// <param name="_player">플레이어</param>
        /// <param name="skills">입력할 스킬</param>
        public SkillStone(Player _player, params Skill[] skills)
        {
            player = _player;
            click = false;
            inStone = true;
            cursor = 0;
            prevCursor = 0;
            screen = Screen.Characters;

            skill = skills[new Random().Next(skills.Length)];
        }

        /// <summary>
        /// 스킬석의 스킬을 습득하는 메소드
        /// </summary>
        public void LearnSkill()
        {
            Console.Clear();
            while (inStone)
            {
                ShowSites();
                GetCursor();
                ClickCursor();
            }
        }

        void ShowSites()
        {
            for (int j = 1; j < 10; j++)
            {
                for (int i = 1; i < 59; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            if (screen == Screen.Characters)
            {
                Console.SetCursorPosition(10, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"[{skill.NAME} 의 스킬석]");
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(10, i + 4);

                    if (cursor == i)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    if (player.PARTY.PCs[i] != null)
                    {
                        Console.Write($"[{player.PARTY.PCs[i].NAME}]");
                    }
                    else
                    {
                        Console.Write("[---]");
                    }
                }

                Console.SetCursorPosition(10, 9);
                if (cursor == 4)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[나가기]");
            }
            else if (screen == Screen.Skills)
            {
                Console.SetCursorPosition(10, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"[{skill.NAME} 의 스킬석 => {player.PARTY.PCs[prevCursor].NAME}]");
                for (int i = 0; i < 4; i++)
                {
                    Console.SetCursorPosition(10, i + 4);

                    if (cursor == i)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;

                    Console.Write($"[{player.PARTY.PCs[prevCursor].SKILLSLOT.SKILLS[i].NAME}]");
                }

                Console.SetCursorPosition(10, 9);
                if (cursor == 4)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.Write("[취소]");
            }
        }

        void GetCursor()
        {
            switch (InputManager.GetInput())
            {
                default:
                    break;
                case Key.LEFT:
                case Key.UP:
                    cursor--;
                    if (cursor < 0)
                        cursor = 4;
                    break;
                case Key.RIGHT:
                case Key.DOWN:
                    cursor++;
                    if (cursor > 4)
                        cursor = 0;
                    break;
                case Key.ENTER:
                    click = true;
                    break;
                case Key.CANEL:
                    inStone = true;
                    break;
            }
        }

        void ClickCursor()
        {
            if (click)
            {
                switch (cursor)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        if (player.PARTY.PCs[prevCursor] == null)
                            break;
                        if (player.PARTY.PCs[prevCursor].SKILLSLOT.QUANTITY < player.PARTY.PCs[prevCursor].SKILLSLOT.SKILLS.Length)
                        {
                            player.PARTY.PCs[prevCursor].SKILLSLOT.AddSkill(skill);
                            inStone = false;
                        }
                        else
                        {
                            if(screen == Screen.Characters)
                            {
                                prevCursor = cursor;
                                screen = Screen.Skills;
                            }
                            else if (screen == Screen.Skills)
                            {
                                player.PARTY.PCs[prevCursor].SKILLSLOT.RemoveSkill(cursor);
                                player.PARTY.PCs[prevCursor].SKILLSLOT.AddSkill(skill);
                                inStone = false;
                            }
                        }
                        click = false;
                        break;
                    case 4:
                        if(screen == Screen.Characters)
                        {
                            inStone = false;
                        }
                        else if (screen == Screen.Skills)
                        {
                            screen = Screen.Characters;
                            cursor = prevCursor;
                        }
                        click = false;
                        break;
                }
            }
        }

        /// <summary>
        /// 이 스킬석의 스킬을 정하는 메소드
        /// </summary>
        void SetSkill()
        {
            switch(new Random().Next(17))
            {
                case 0:
                    skill = new Skill_Bite();
                    break;
                case 1:
                    skill = new Skill_Blessing();
                    break;
                case 2:
                    skill = new Skill_LuckyAttack();
                    break;
                case 3:
                    skill = new Skill_Curse();
                    break;
                case 4:
                    skill = new Skill_DashAttack();
                    break;
                case 5:
                    skill = new Skill_FireBreath();
                    break;
                case 6:
                    skill = new Skill_HealingWord();
                    break;
                case 7:
                    skill = new Skill_ThrowDagger();
                    break;
                case 8:
                    skill = new Skill_MagicBolt();
                    break;
                case 9:
                    skill = new Skill_Swing();
                    break;
                case 10:
                    skill = new Skill_WaterShot();
                    break;
                case 11:
                    skill = new Skill_Arcrobatics();
                    break;
                case 12:
                    skill = new Skill_DeepBreath();
                    break;
                case 13:
                    skill = new Skill_MagicShield();
                    break;
                case 14:
                    skill = new Skill_PainRefactor();
                    break;
                case 15:
                    skill = new Skill_RoughSkin();
                    break;
                case 16:
                    skill = new Skill_SecondWind();
                    break;
            }
        }
    }
}
