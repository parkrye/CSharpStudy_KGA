namespace ProjectRPG
{
    internal class Battle
    {
        int turn;
        int battleOver;
        Player player;
        Party playerParty, enemyParty;
        List<PC> turnOrder;
        Random random;

        public int TURN
        {
            get { return turn; }
        }

        public Battle(Player _player, Party _playerParty, Party _enemyParty)
        {
            turn = 1;
            battleOver = 0;
            player = _player;
            playerParty = _playerParty;
            enemyParty = _enemyParty;
            random = new Random();

            turnOrder = new List<PC>();
            foreach(PC pc in playerParty.PCs)
            {
                if (pc == null)
                    break;
                turnOrder.Add(pc);
                pc.StatusSetting();
            }
            foreach(PC pc in enemyParty.PCs)
            {
                if (pc == null)
                    break;
                turnOrder.Add(pc);
                pc.StatusSetting();
            }
        }

        public void StartBattle()
        {
            while (battleOver == 0)
            {
                TurnOrder();
                ShowSituation();
                Play();
                TurnEnd();
            }
            Result();
        }

        void TurnOrder()
        {
            turnOrder = turnOrder.OrderByDescending(x => x.NOW_INITIATIVE).ToList();
        }

        void ShowSituation()
        {
            Console.Clear();

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($"[Turn {turn}]");

            for (int i = 0; i < enemyParty.MEMBERS; i++)
            {
                if (enemyParty.PCs[i].NOW_HP == 0)
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                else
                    Console.ForegroundColor = ConsoleColor.Red;
                Console.SetCursorPosition(i * 10, 2);
                Console.Write(enemyParty.PCs[i].NAME);
                Console.SetCursorPosition(i * 10, 3);
                Console.Write($"{enemyParty.PCs[i].NOW_HP} | {enemyParty.PCs[i].NOW_SP}");
            }

            for (int i = 0; i < playerParty.MEMBERS; i++)
            {
                if (playerParty.PCs[i].NOW_HP == 0)
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                else
                    Console.ForegroundColor = ConsoleColor.Blue;
                Console.SetCursorPosition(i * 10, 5);
                Console.Write(playerParty.PCs[i].NAME);
                Console.SetCursorPosition(i * 10, 6);
                Console.Write($"{playerParty.PCs[i].NOW_HP} | {playerParty.PCs[i].NOW_SP}");
            }
        }

        void Play()
        {
            foreach(PC pc in turnOrder)
            {
                if (pc.NOW_HP == 0)
                    continue;
                if (playerParty.Contains(pc))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine($"[{pc.NAME}의 차례]");

                    bool selectOver = false;
                    while (!selectOver)
                    {
                        switch (Select_Main())
                        {
                            default:
                                break;
                            case 0:
                                selectOver = Select_Skill(pc);
                                break;
                            case 1:
                                selectOver = Select_Item(pc);
                                break;
                            case 2:
                                selectOver = Select_Run();
                                break;
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < enemyParty.MEMBERS; i++)
                    {
                        if (enemyParty.PCs[i] == pc)
                        {
                            // 랜덤 스킬, 아이템 선택
                            // IAttackable이면 플레이어쪽 타겟팅
                            // IHealable, IBurfable이면 적쪽 타겟팅
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

        /// <summary>
        /// 턴 종료
        /// </summary>
        void TurnEnd()
        {
            int playerDead = 0;
            for(int i = 0; i < playerParty.MEMBERS; i++)
            {
                if (playerParty.PCs[i].NOW_HP == 0)
                    playerDead++;
            }
            if(playerDead == playerParty.MEMBERS - 1)
            {
                battleOver = 1;
            }

            int enemyDead = 0;
            for(int i = 0; i < enemyParty.MEMBERS; i++)
            {
                if (enemyParty.PCs[i].NOW_HP == 0)
                    enemyDead++;
            }
            if (enemyDead == enemyParty.MEMBERS - 1)
            {
                battleOver = 2;
            }

            turn++;
            OnTurnEnd?.Invoke();
        }

        void Result()
        {
            switch (battleOver)
            {
                // 플레이어 승리
                case 1:
                    int sum = 0;
                    foreach (PC enemy in enemyParty.PCs)
                    {
                        sum += enemy.DIFFICULTY;
                    }
                    player.GetMonsy(sum);

                    List<Item> items = new List<Item>();
                    foreach(PC enemy in enemyParty.PCs)
                    {
                        foreach(Item item in enemy.ITEMSLOT.ITEMS)
                        {
                            items.Add(item);
                        }
                    }
                    foreach(Item item in items)
                    {
                        player.AddItem(item);
                    }
                    break;
                // 플레이어 패배
                case 2:
                    while (playerParty.MEMBERS > 0)
                        playerParty.RemovePC(0);
                    break;
                // 플레이어 도주
                case 3:
                    break;
            }
        }

        /// <summary>
        /// 주요 선택지
        /// </summary>
        /// <returns>0: 스킬, 1: 아이템, 2: 도주</returns>
        int Select_Main()
        {
            // 출력창 지우기
            Console.SetCursorPosition(0, 10);
            for(int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 60; j++)
                    Console.Write("　");
                Console.WriteLine();
            }

            int select = 0;
            while (true)
            {
                if (select == 0)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 10);
                Console.WriteLine("[스킬 사용]");

                if (select == 1)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 11);
                Console.WriteLine("[아이템 사용]");

                if (select == 2)
                    Console.ForegroundColor = ConsoleColor.Green;
                else
                    Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 12);
                Console.WriteLine("[도망치기]");

                int input = Input();
                switch (input)
                {
                    default:
                        break;
                    case 1:
                    case 3:
                        select--;
                        if (select < 0)
                            select = 2;
                        break;
                    case 2:
                    case 4:
                        select++;
                        if (select > 2)
                            select = 0;
                        break;
                    case 5:
                        return select;
                    case 6:
                        return -1;
                }
            }
        }

        /// <summary>
        /// 스킬 선택지
        /// </summary>
        /// <param name="pc">현재 캐릭터</param>
        /// <returns>스킬 선택 여부</returns>
        bool Select_Skill(PC pc)
        {
            int select = 0;
            int count = pc.SKILLSLOT.SIZE;

            while (true)
            {
                // 출력창 지우기
                Console.SetCursorPosition(0, 10);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 60; j++)
                        Console.Write("　");
                    Console.WriteLine();
                }

                for (int i = 0; i < count; i++)
                {
                    if (pc.SKILLSLOT.SKILLS[i] == null)
                        break;
                    if (i == select)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 10 + i);
                    Console.WriteLine($"[{pc.SKILLSLOT.SKILLS[i].NAME}]");
                }

                int input = Input();
                switch (input)
                {
                    default:
                        break;
                    case 1:
                    case 3:
                        select--;
                        if (select < 0)
                            select = count - 1;
                        while (pc.SKILLSLOT.SKILLS[select] == null)
                            select--;
                        break;
                    case 2:
                    case 4:
                        select++;
                        if (select >= count)
                            select = 0;
                        if (pc.SKILLSLOT.SKILLS[select] == null)
                            select = 0;
                        break;
                    case 5:
                        PC target = Targeting(pc);
                        if (target == null)
                            break;
                        if (pc.SKILLSLOT.UseSkill(select, target, pc.STATUS))
                            return true;
                        break;
                    case 6:
                        return false;
                }
            }
        }


        /// <summary>
        /// 아이템 선택지
        /// </summary>
        /// <param name="pc">현재 캐릭터</param>
        /// <returns>아이템 선택 여부</returns>
        bool Select_Item(PC pc)
        {
            int select = 0;
            int count = pc.ITEMSLOT.SIZE;

            while (true)
            {
                // 출력창 지우기
                Console.SetCursorPosition(0, 10);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 60; j++)
                        Console.Write("　");
                    Console.WriteLine();
                }

                for (int i = 0; i < count; i++)
                {
                    if (pc.ITEMSLOT.ITEMS[i] == null)
                        break;
                    if (i == select)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 10 + i);
                    Console.WriteLine($"[{pc.ITEMSLOT.ITEMS[i].NAME}]");
                }

                int input = Input();
                switch (input)
                {
                    default:
                        break;
                    case 1:
                    case 3:
                        select--;
                        if (select < 0)
                            select = count - 1;
                        while (pc.ITEMSLOT.ITEMS[select] == null)
                            select--;
                        break;
                    case 2:
                    case 4:
                        select++;
                        if (select >= count)
                            select = 0;
                        if (pc.ITEMSLOT.ITEMS[select] == null)
                            select = 0;
                        break;
                    case 5:
                        PC target = Targeting(pc);
                        if (target == null)
                            break;
                        pc.ITEMSLOT.UseItem(select, target);
                        return true;
                    case 6:
                        return false;
                }
            }
        }

        /// <summary>
        /// 도망 선택지
        /// </summary>
        /// <returns>도망 성공 여부</returns>
        bool Select_Run()
        {
            // 출력창 지우기
            Console.SetCursorPosition(0, 10);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 60; j++)
                    Console.Write("　");
                Console.WriteLine();
            }

            if (random.Next(10) < 5 - enemyParty.MEMBERS * 2 + playerParty.MEMBERS)
            {
                battleOver = 3;
            }

            return true;
        }

        /// <summary>
        /// 타겟팅
        /// </summary>
        /// <param name="pc">시전자</param>
        /// <returns>타겟. 없을 경우 null</returns>
        PC Targeting(PC pc)
        {
            int select = 0;

            while (true)
            {
                // 출력창 지우기
                Console.SetCursorPosition(0, 14);
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 60; j++)
                        Console.Write("　");
                    Console.WriteLine();
                }

                Console.SetCursorPosition(0, 14);
                Console.WriteLine($"[대상 : {turnOrder[select].NAME}]");

                int input = Input();
                switch (input)
                {
                    default:
                        break;
                    case 1:
                    case 3:
                        select--;
                        if (select < 0)
                            select = turnOrder.Count - 1;
                        while (turnOrder[select] == null)
                            select--;
                        break;
                    case 2:
                    case 4:
                        select++;
                        if (select >= turnOrder.Count)
                            select = 0;
                        if (turnOrder[select] == null)
                            select = 0;
                        break;
                    case 5:
                        return turnOrder[select];
                    case 6:
                        return null;
                }
            }
        }

        /// <summary>
        /// 입력 처리
        /// </summary>
        /// <returns>입력 종류</returns>
        public int Input()
        {
            switch (InputManager.GetInput())
            {
                default:
                case Key.NONE:
                    return 0;
                case Key.LEFT:
                    return 1;
                case Key.RIGHT:
                    return 2;
                case Key.UP:
                    return 3;
                case Key.DOWN:
                    return 4;
                case Key.ENTER:
                    return 5;
                case Key.CANEL:
                    return 6;
            }
        }
    }
}
