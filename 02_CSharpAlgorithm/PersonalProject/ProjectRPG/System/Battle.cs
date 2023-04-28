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

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_player">플레이어</param>
        /// <param name="_enemyParty">적 파티</param>
        public Battle(Player _player, Party _enemyParty)
        {
            turn = 1;
            battleOver = 0;
            player = _player;
            playerParty = player.PARTY;
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
            foreach(PC enemy in enemyParty.PCs)
            {
                if (enemy == null)
                    break;
                turnOrder.Add(enemy);
                enemy.StatusSetting();
            }
        }

        /// <summary>
        /// 전투 개시
        /// </summary>
        public void StartBattle()
        {
            Console.Clear();
            while (battleOver == 0)
            {
                TurnOrder();
                Play();
                TurnEnd();
            }
            ShowSituation();
            Result();
        }

        /// <summary>
        /// 턴 순서 재설정
        /// </summary>
        void TurnOrder()
        {
            turnOrder = turnOrder.OrderByDescending(x => x.NOW_INITIATIVE).ToList();
        }

        /// <summary>
        /// 위쪽 UI 출력
        /// </summary>
        void ShowSituation()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 60; j++)
                    Console.Write("　");
                Console.WriteLine();
            }

            Console.SetCursorPosition(0, 0);
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

        /// <summary>
        /// 턴 진행
        /// </summary>
        void Play()
        {
            foreach(PC turnCharacter in turnOrder)
            {
                if (turnCharacter.NOW_HP == 0)
                {
                    continue;
                }

                Thread.Sleep(1000);
                ShowSituation();
                if (playerParty.Contains(turnCharacter))
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 8);
                    Console.WriteLine($"[{turnCharacter.NAME}의 차례]");

                    bool selectOver = false;
                    while (!selectOver)
                    {
                        switch (Select_Main())
                        {
                            default:
                                break;
                            case 0:
                                selectOver = Select_Skill(turnCharacter);
                                break;
                            case 1:
                                selectOver = Select_Item(turnCharacter);
                                break;
                            case 2:
                                selectOver = Select_Run();
                                break;
                        }
                    }
                }
                else
                {
                    EnemyPlay(turnCharacter);
                }

                if (playerParty.LIVES == 0 || enemyParty.LIVES == 0)
                {
                    break;
                }
            }
        }

        // 이벤트 호출을 위한 대리자
        // 턴 카운트를 위해 사용
        protected event Action? OnTurnEnd;

        /// <summary>
        /// 턴 종료
        /// </summary>
        void TurnEnd()
        {
            if(playerParty.LIVES == 0)
            {
                battleOver = 2;
            }
            else if (enemyParty.LIVES == 0)
            {
                battleOver = 1;
            }
            else
            {
                turn++;
                OnTurnEnd?.Invoke();
            }
        }

        /// <summary>
        /// 전투 결과 결산
        /// </summary>
        void Result()
        {
            // 출력창 지우기
            Console.SetCursorPosition(0, 10);
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 60; j++)
                    Console.Write("　");
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.White;

            switch (battleOver)
            {
                // 플레이어 승리
                case 1:
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("전투에서 승리했습니다!");
                    int sum = 0;
                    for(int i = 0; i < enemyParty.MEMBERS; i++)
                    {
                        sum += enemyParty.PCs[i].DIFFICULTY;
                    }
                    player.AddMoney(sum);

                    List<Item> items = new List<Item>();
                    for (int i = 0; i < enemyParty.MEMBERS; i++)
                    {
                        for(int j = 0; j < enemyParty.PCs[i].ITEMSLOT.QUANTITY; j++)
                        {
                            player.AddItem(enemyParty.PCs[i].ITEMSLOT.ITEMS[j]);
                        }
                    }

                    for(int i = 0; i < playerParty.MEMBERS; i++)
                    {
                        if (playerParty.PCs[i].NOW_HP == 0)
                            playerParty.PCs[i].NOW_HP++;
                    }
                    break;
                // 플레이어 패배
                case 2:
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("전투에서 패배했습니다..");
                    while (playerParty.MEMBERS > 0)
                        playerParty.RemovePC(0);
                    break;
                // 플레이어 도주
                case 3:
                    Console.SetCursorPosition(0, 10);
                    Console.WriteLine("전투에서 도망쳤습니다!");

                    for (int i = 0; i < playerParty.MEMBERS; i++)
                    {
                        if (playerParty.PCs[i].NOW_HP == 0)
                            playerParty.PCs[i].NOW_HP++;
                    }
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

                switch (InputManager.GetInput())
                {
                    default:
                        break;
                    case Key.LEFT:
                    case Key.UP:
                        select--;
                        if (select < 0)
                            select = 2;
                        break;
                    case Key.RIGHT:
                    case Key.DOWN:
                        select++;
                        if (select > 2)
                            select = 0;
                        break;
                    case Key.ENTER:
                        return select;
                    case Key.CANEL:
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
            int count = pc.SKILLSLOT.QUANTITY;

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
                    if (i == select)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 10 + i);
                    Console.WriteLine($"[{pc.SKILLSLOT.SKILLS[i].NAME}]");
                }

                switch (InputManager.GetInput())
                {
                    default:
                        break;
                    case Key.LEFT:
                    case Key.UP:
                        select--;
                        if (select < 0)
                            select = count - 1;
                        while (pc.SKILLSLOT.SKILLS[select] == null)
                            select--;
                        break;
                    case Key.RIGHT:
                    case Key.DOWN:
                        select++;
                        if (select >= count)
                            select = 0;
                        if (pc.SKILLSLOT.SKILLS[select] == null)
                            select = 0;
                        break;
                    case Key.ENTER:
                        PC target = Targeting(pc.SKILLSLOT.SKILLS[select] is IAttackable);
                        if (target == null)
                            break;
                        if (pc.SKILLSLOT.UseSkill(select, target, pc.STATUS))
                            return true;
                        break;
                    case Key.CANEL:
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
            int count = pc.ITEMSLOT.QUANTITY;

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
                    if (i == select)
                        Console.ForegroundColor = ConsoleColor.Green;
                    else
                        Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(0, 10 + i);
                    Console.WriteLine($"[{pc.ITEMSLOT.ITEMS[i].NAME}]");
                }

                switch (InputManager.GetInput())
                {
                    default:
                        break;
                    case Key.LEFT:
                    case Key.UP:
                        select--;
                        if (select < 0)
                            select = count - 1;
                        while (pc.ITEMSLOT.ITEMS[select] == null)
                            select--;
                        break;
                    case Key.RIGHT:
                    case Key.DOWN:
                        select++;
                        if (select >= count)
                            select = 0;
                        if (pc.ITEMSLOT.ITEMS[select] == null)
                            select = 0;
                        break;
                    case Key.ENTER:
                        PC target = Targeting(pc.ITEMSLOT.ITEMS[select] is IAttackable);
                        if (target == null)
                            break;
                        pc.ITEMSLOT.UseItem(select, target);
                        return true;
                    case Key.CANEL:
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
            Console.SetCursorPosition(0, 10);

            if (random.Next(10) < 5 - enemyParty.MEMBERS * 2 + playerParty.MEMBERS)
            {
                battleOver = 3;
            }
            else
            {
                Console.WriteLine("도망치는데 실패했습니다..");
            }

            return true;
        }

        /// <summary>
        /// 플레이어 타겟팅
        /// </summary>
        /// <param name="isAttack">공격인지</param>
        /// <returns>타겟. 없을 경우 null</returns>
        PC Targeting(bool isAttack)
        {
            int select = 0;
            for(int i = 0; i < turnOrder.Count; i++)
            {
                if (isAttack)
                {
                    if (enemyParty.Contains(turnOrder[i]))
                    {
                        select = i;
                        break;
                    }
                }
                else
                {
                    if (playerParty.Contains(turnOrder[i]))
                    {
                        select = i;
                        break;
                    }
                }
            }

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
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[대상 : {turnOrder[select].NAME}]");

                switch (InputManager.GetInput())
                {
                    default:
                        break;
                    case Key.LEFT:
                    case Key.UP:
                        select--;
                        if (select < 0)
                            select = turnOrder.Count - 1;
                        if (isAttack && playerParty.Contains(turnOrder[select]))
                            select--;
                        if (select < 0)
                            select = turnOrder.Count - 1;
                        while (turnOrder[select] == null)
                            select--;
                        if (select < 0)
                            select = turnOrder.Count - 1;
                        break;
                    case Key.RIGHT:
                    case Key.DOWN:
                        select++;
                        if (select >= turnOrder.Count)
                            select = 0;
                        if (isAttack && playerParty.Contains(turnOrder[select]))
                            select++;
                        if (select >= turnOrder.Count)
                            select = 0;
                        if (turnOrder[select] == null)
                            select = 0;
                        if (select >= turnOrder.Count)
                            select = 0;
                        break;
                    case Key.ENTER:
                        return turnOrder[select];
                    case Key.CANEL:
                        return null;
                }
            }
        }

        /// <summary>
        /// 적 행동
        /// </summary>
        /// <param name="enemy">행동하는 적 캐릭터</param>
        void EnemyPlay(PC enemy)
        {
            bool done = false;
            while (!done)
            {
                bool targeting = false;
                int count = enemy.ITEMSLOT.QUANTITY + enemy.SKILLSLOT.QUANTITY;
                int select = 0;
                PC target = null;

                while (!targeting)
                {
                    select = random.Next(count);
                    if (select < enemy.ITEMSLOT.QUANTITY)
                    {
                        if (enemy.ITEMSLOT.ITEMS[select] is IAttackable)
                        {
                            target = playerParty.PCs[random.Next(playerParty.MEMBERS)];
                            if (target.NOW_HP > 0)
                                targeting = true;
                        }
                        else if (enemy.ITEMSLOT.ITEMS[select] is IHealable)
                        {
                            target = enemyParty.PCs[random.Next(enemyParty.MEMBERS)];
                            if (target.NOW_HP < target.MAX_HP)
                                targeting = true;
                        }
                        else if (enemy.ITEMSLOT.ITEMS[select] is IBurfable)
                        {
                            target = enemyParty.PCs[random.Next(enemyParty.MEMBERS)];
                            if (target.NOW_HP > 0)
                                targeting = true;
                        }
                    }
                    else
                    {
                        if (enemy.SKILLSLOT.SKILLS[select - enemy.ITEMSLOT.QUANTITY] is IAttackable)
                        {
                            target = playerParty.PCs[random.Next(playerParty.MEMBERS)];
                            if (target.NOW_HP > 0)
                                targeting = true;
                        }
                        else if (enemy.SKILLSLOT.SKILLS[select - enemy.ITEMSLOT.QUANTITY] is IHealable)
                        {
                            target = enemyParty.PCs[random.Next(enemyParty.MEMBERS)];
                            if (target.NOW_HP < target.MAX_HP)
                                targeting = true;
                        }
                        else if (enemy.ITEMSLOT.ITEMS[select - enemy.ITEMSLOT.QUANTITY] is IBurfable)
                        {
                            target = enemyParty.PCs[random.Next(enemyParty.MEMBERS)];
                            if (target.NOW_HP > 0)
                                targeting = true;
                        }
                    }
                }

                // 출력창 지우기
                Console.SetCursorPosition(0, 10);
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 60; j++)
                        Console.Write("　");
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(0, 10);
                Console.Write($"{enemy.NAME} 은 {target.NAME} 에게 ");

                if (select < enemy.ITEMSLOT.QUANTITY)
                {
                    Console.WriteLine($"{enemy.ITEMSLOT.ITEMS[select].NAME} 을 사용했다!");
                    if (enemy.ITEMSLOT.UseItem(select, target))
                        done = true;
                }
                else
                {
                    select -= enemy.ITEMSLOT.QUANTITY;
                    Console.WriteLine($"{enemy.SKILLSLOT.SKILLS[select].NAME} 을 사용했다!");
                    if (enemy.SKILLSLOT.UseSkill(select, target, enemy.STATUS))
                        done = true;
                }
            }
        }
    }
}
