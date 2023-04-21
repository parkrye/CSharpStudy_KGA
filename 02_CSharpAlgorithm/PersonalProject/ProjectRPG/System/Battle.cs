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
            player = _player;
            enemy = _enemy;

            turnOrder = new List<PC>();
            foreach(PC pc in player.PCs)
                turnOrder.Add(pc);
            foreach(PC pc in enemy.PCs)
                turnOrder.Add(pc);
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
            turnOrder = turnOrder.OrderByDescending(x => x.INITIATIVE).ToList();
        }

        void ShowSituation()
        {
            Console.Clear();
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 60; i++)
                Console.Write("=");
            Console.SetCursorPosition(0, 9);
            for (int i = 0; i < 60; i++)
                Console.Write("=");
            Console.SetCursorPosition(0, 19);
            for (int i = 0; i < 60; i++)
                Console.Write("=");
            for (int i = 0; i < 20; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("+");
                Console.SetCursorPosition(60, i);
                Console.Write("+");
            }
            Console.SetCursorPosition(50, 1);
            Console.Write($"[Turn {turn}]");

            for (int i = 0; i < enemy.MEMBERS; i++)
            {
                Console.SetCursorPosition(i * 10 + 2, 2);
                Console.Write(enemy.PCs[i].NAME);
                Console.SetCursorPosition(i * 10 + 2, 3);
                Console.Write($"{enemy.PCs[i].HP} | {enemy.PCs[i].SP}");
            }

            for (int i = 0; i < player.MEMBERS; i++)
            {
                Console.SetCursorPosition(i * 10 + 2, 7);
                Console.Write(player.PCs[i].NAME);
                Console.SetCursorPosition(i * 10 + 2, 8);
                Console.Write($"{player.PCs[i].HP} | {player.PCs[i].SP}");
            }
        }

        void Play()
        {
            foreach(PC pc in turnOrder)
            {
                for(int i = 2; i < 58; i++)
                {
                    for (int j = 4; j < 7; j+=2)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("　");
                    }
                    for (int j = 13; j < 17; j++)
                    {
                        Console.SetCursorPosition(i, j);
                        Console.Write("　");
                    }
                }

                if (player.Contains(pc))
                {
                    for(int i = 0; i < player.MEMBERS; i++)
                    {
                        if (player.PCs[i] == pc)
                        {
                            Console.SetCursorPosition(i * 10 + 4, 6);
                            Console.Write("↓");
                            break;
                        }
                    }
                    for(int i = 0; i < pc.SKILLSLOT.SIZE; i++)
                    {
                        if (pc.SKILLSLOT.SKILLS[i] == null)
                            break;
                        if(i < 3)
                        {
                            Console.SetCursorPosition(2 + i * 16, 13);
                            Console.Write($"{i}.{pc.SKILLSLOT.SKILLS[i].NAME}");
                        }
                        else
                        {
                            Console.SetCursorPosition(2 + (i - 3) * 16, 14);
                            Console.Write($"{i}.{pc.SKILLSLOT.SKILLS[i].NAME}");
                        }
                    }

                    Console.SetCursorPosition(2, 15);
                    for (int i = 0; i < pc.ITEMSLOT.SIZE; i++)
                    {
                        if (pc.ITEMSLOT.ITEMS[i] == null)
                            break;
                        if (i < 3)
                        {
                            Console.SetCursorPosition(2 + i * 16, 13);
                            Console.Write($"{i+6}.{pc.ITEMSLOT.ITEMS[i].NAME}");
                        }
                        else
                        {
                            Console.SetCursorPosition(2 + (i - 3) * 16, 14);
                            Console.Write($"{i+6}.{pc.ITEMSLOT.ITEMS[i].NAME}");
                        }
                    }

                    int input = -1;
                    do
                    {
                        int.TryParse(Console.ReadLine(), out input);
                    } while (input < 0 || input > pc.SKILLSLOT.SIZE || pc.SKILLSLOT.SKILLS[input] == null);


                }
                else
                {
                    for (int i = 0; i < enemy.MEMBERS; i++)
                    {
                        if (enemy.PCs[i] == pc)
                        {
                            Console.SetCursorPosition(i * 10 + 4, 4);
                            Console.Write("↑");
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
    }
}
