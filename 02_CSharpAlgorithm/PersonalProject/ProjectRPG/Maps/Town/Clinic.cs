namespace ProjectRPG
{
    /// <summary>
    /// 마을의 의원에 대한 클래스
    /// </summary>
    internal class Clinic : TownSite
    {
        public Clinic() : base()
        {
            name = "의료소";
        }

        protected override void ShowSites()
        {
            for (int j = 1; j < 10; j++)
            {
                for (int i = 1; i < 59; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(" ");
                }
            }

            Console.SetCursorPosition(20, 1);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[{name} | 소지금 : $ {player.MONEY}]");
            Console.SetCursorPosition(10, 2);
            Console.Write("[파티 내 캐릭터를 회복시킬 수 있습니다]");
            for (int i = 0; i < 4; i++)
            {
                Console.SetCursorPosition(10, i + 4);

                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                if (player.PARTY.PCs[i] != null)
                {
                    Console.Write($"[{player.PARTY.PCs[i].NAME}({player.PARTY.PCs[i].NOW_HP} / {player.PARTY.PCs[i].MAX_HP}) : $ {player.PARTY.PCs[i].MAX_HP - player.PARTY.PCs[i].NOW_HP}]");
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
                        if (player.PARTY.PCs[cursor] == null)
                            break;
                        if (player.LoseMoney(player.PARTY.PCs[cursor].MAX_HP - player.PARTY.PCs[cursor].NOW_HP))
                        {
                            player.PARTY.PCs[cursor].NOW_HP = player.PARTY.PCs[cursor].MAX_HP;
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
