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
            Console.Clear();

            Console.SetCursorPosition(0, 0);
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{name} | 소지금 : $ {player.MONEY}]");
            Console.WriteLine("[파티 내 캐릭터를 회복시킬 수 있습니다]");
            Console.WriteLine();
            for (int i = 0; i < 4; i++)
            {
                if (cursor == i)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;

                if (player.PARTY.PCs[i] != null)
                {
                    Console.WriteLine($"[{player.PARTY.PCs[i].NAME}({player.PARTY.PCs[i].NOW_HP} / {player.PARTY.PCs[i].MAX_HP}) : $ {player.PARTY.PCs[i].MAX_HP - player.PARTY.PCs[i].NOW_HP}]");
                }
                else
                {
                    Console.WriteLine("[---]");
                }
            }
            if (cursor == 4)
                Console.ForegroundColor = ConsoleColor.Green;
            else
                Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine($"[{name} 나가기]");
        }

        protected override void GetCursor()
        {
            int key = Input();
            switch (key)
            {
                case 1:
                case 3:
                    cursor--;
                    if (cursor < 0)
                        cursor = 4;
                    break;
                case 2:
                case 4:
                    cursor++;
                    if (cursor > 4)
                        cursor = 0;
                    break;
                case 5:
                    goSite = true;
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
                        cursor = 0;
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
