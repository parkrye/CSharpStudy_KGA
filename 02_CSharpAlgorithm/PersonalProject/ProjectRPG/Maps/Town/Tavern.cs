namespace ProjectRPG
{
    /// <summary>
    /// 마을의 주막에 대한 클래스
    /// </summary>
    internal class Tavern : TownSite
    {
        List<Class> classes;    // 랜덤 생성을 위한 클래스 모음
        PC[] characters;        // 대기중인 캐릭터들. 최대 4

        public Tavern() : base()
        {
            name = "주막";
            classes = new List<Class>();
            ClassSetting();

            characters = new PC[4];
            CharacterSetting();
        }

        /// <summary>
        /// 전체 클래스 종류
        /// </summary>
        void ClassSetting()
        {
            classes.Add(new Class_Clown());
            classes.Add(new Class_Hunter());
            classes.Add(new Class_Soccerer());
            classes.Add(new Class_Soldier());
        }

        /// <summary>
        /// 고용 가능 캐릭터를 생성하는 메소드
        /// </summary>
        void CharacterSetting()
        {
            for (int i = 0; i < 4; i++)
            {
                PC character = new PC();
                int c = new Random().Next(classes.Count + 1);
                if (c < classes.Count) character.SetClass(classes[c]);
                characters[i] = character;
            }
        }

        protected override void ShowSites()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 10);
                Console.Write("=");
            }
            for (int i = 1; i < 10; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("||");
                Console.SetCursorPosition(58, i);
                Console.Write("||");
            }

            Console.SetCursorPosition(20, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{name} | 소지금 : $ {player.MONEY}]");
            Console.SetCursorPosition(10, 2);
            Console.Write("[다음과 같은 캐릭터를 고용할 수 있습니다]");

            for(int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(10, i + 4);

                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                if (characters[i] != null)
                {
                    Console.Write($"[{characters[i].NAME}({characters[i].MAX_HP} / {characters[i].MAX_SP}) : $ {characters[i].DIFFICULTY * 2}]");
                }
                else
                {
                    Console.Write("[---]");
                }
            }

            Console.SetCursorPosition(40, 9);
            if (cursor == 4)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{name} 나가기]");
        }

        protected override void GetCursor()
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
                    goSite = true;
                    break;
                case Key.CANEL:
                    outSite = true;
                    break;
            }
        }

        protected override void ClickCursor()
        {
            if (goSite)
            {
                switch (cursor)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        if (characters[cursor] == null)
                            break;
                        if (player.LoseMoney(characters[cursor].DIFFICULTY * 2))
                        {
                            player.EmployCharacter(characters[cursor]);
                            player.EmployedToParty(player.EMPLOYED.Count - 1);
                            characters[cursor] = null;
                        }
                        break;
                    case 4:
                        outSite = true;
                        break;
                }
                goSite = false;
            }
        }
    }
}
