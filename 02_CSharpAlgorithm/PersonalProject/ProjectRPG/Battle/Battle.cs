namespace ProjectRPG
{
    internal class Battle
    {
        Party player, enemy;
        int turn;
        List<PC> turnOrder;

        public int TURN
        {
            get { return turn; }
        }

        public Battle(Party _player, Party _enemy)
        {
            turn = 1;
            player = _player;
            enemy = _enemy;

            turnOrder = new List<PC>();
            foreach(PC pc in player.PCs)
            {
                if (pc == null)
                    break;
                turnOrder.Add(pc);
            }
            foreach(PC pc in enemy.PCs)
            {
                if (pc == null)
                    break;
                turnOrder.Add(pc);
            }
        }

        public void StartBattle()
        {
            TurnFlow();
        }

        void TurnFlow()
        {
            TurnOrder();
            ShowSituation();
            Play();
            TurnEnd();
        }

        void TurnOrder()
        {
            turnOrder = turnOrder.OrderByDescending(x => x.NOW_INITIATIVE).ToList();
        }

        void ShowSituation()
        {
            Console.Clear();

            Console.Write($"[Turn {turn}]");

            for (int i = 0; i < enemy.MEMBERS; i++)
            {
                Console.SetCursorPosition(i * 10, 2);
                Console.Write(enemy.PCs[i].NAME);
                Console.SetCursorPosition(i * 10, 3);
                Console.Write($"{enemy.PCs[i].NOW_HP} | {enemy.PCs[i].NOW_SP}");
            }

            for (int i = 0; i < player.MEMBERS; i++)
            {
                Console.SetCursorPosition(i * 10, 6);
                Console.Write(player.PCs[i].NAME);
                Console.SetCursorPosition(i * 10, 7);
                Console.Write($"{player.PCs[i].NOW_HP} | {player.PCs[i].NOW_SP}");
            }
        }

        void Play()
        {
            foreach(PC pc in turnOrder)
            {
                if (player.Contains(pc))
                {
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("[스킬 사용]");

                    Console.SetCursorPosition(0, 11);
                    Console.WriteLine("[아이템 사용]");




                }
                else
                {
                    for (int i = 0; i < enemy.MEMBERS; i++)
                    {
                        if (enemy.PCs[i] == pc)
                        {

                            break;
                        }
                    }

                }
            }
            Console.SetCursorPosition(0, 30);
        }

        // 이벤트 호출을 위한 대리자
        // 턴 카운트를 위해 사용
        protected event Action? OnTurnEnd;

        void TurnEnd()
        {
            turn++;
            OnTurnEnd?.Invoke();
        }

        public void Input()
        {
            switch (InputManager.GetInput())
            {
                default:
                case Key.NONE:
                    break;
                case Key.LEFT:
                    break;
                case Key.RIGHT:
                    break;
                case Key.UP:
                    break;
                case Key.DOWN:
                    break;
                case Key.ENTER:
                    break;
                case Key.CANEL:
                    break;
            }
        }
    }
}
