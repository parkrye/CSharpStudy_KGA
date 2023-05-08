namespace ProjectTextRPG
{
    public class Player
    {
        public char icon = 'ⓟ';
        public Position position;

        public int CurHp { get; set; }
        public int MaxHp { get; set; }
        public int Level { get; set; }
        public int CurExp { get; set; }
        public int MaxExp { get; set; }
        public int AP { get; set; }
        public int DP { get; set; }
        public int Sight { get; set; }
        public int NowEight { get { int sum = 0; foreach (Item item in inventory) sum += item.weight; return sum; } }
        public int LimitWeight { get; set; }
        public int Money { get; set; }
        public int Hunger { get; set; }
        public Job JOB { get; set; }

        public List<Skill> skills;

        public List<Item> inventory;

        public Player()
        {
            MaxHp = 50;
            CurHp = MaxHp;
            Level = 1;
            MaxExp = 100;
            CurExp = 0;
            AP = 5;
            DP = 0;
            Sight = 8;
            LimitWeight = 10;
            Money = 0;
            Hunger = 100;

            skills = new List<Skill>();
            inventory = new List<Item>();
            AddJob(new None());
        }

        public void GetItem(Item item)
        {
            inventory.Add(item);
        }

        public void UseItem(Item item)
        {
            inventory.Remove(item);
            item.Use();
        }

        public void AddEXP(int value)
        {
            CurExp += value;
            while (CurExp >= MaxExp) 
            {
                AP++;
                MaxHp += 10;
                CurHp += 10;
                CurExp -= MaxExp;
                Level++;
                MaxExp += (Level) * ( MaxExp - Level + 1);
            }
        }

        public void Heal(int heal)
        {
            CurHp += heal;
            if (CurHp > MaxHp)
                CurHp = MaxHp;
        }

        public bool AddStatus(int index, int value)
        {
            switch (index)
            {
                default:
                    return false;
                case 0:
                    MaxHp += value;
                    break;
                case 1:
                    AP += value;
                    break;
                case 2:
                    DP += value;
                    break;
            }
            return true;
        }

        public void TakeDamage(int damage)
        {
            if (damage > DP)
            {
                Console.WriteLine($"당신은 {damage - DP} 데미지를 받았다!");
                CurHp -= damage - DP;
            }
            else
                Console.WriteLine($"당신은 아무렇지 않다!");

            Thread.Sleep(500);

            if (CurHp <= 0)
            {
                Console.WriteLine($"당신은 쓰려졌다!");
                Thread.Sleep(500);
            }
        }

        public bool Move(Direction dir)
        {
            int x = 0, y = 0;
            switch (dir)
            {
                case Direction.Left:
                    x--;
                    break;
                case Direction.Right:
                    x++;
                    break;
                case Direction.Up:
                    y--;
                    break;
                case Direction.Down:
                    y++;
                    break;
            }

            if (position.x + x < 0 || position.y + y < 0 || position.x + x >= Data.map.GetLength(1) || position.y + y >= Data.map.GetLength(0))
                return false;
            if (!Data.map[position.y + y, position.x + x])
                return false;

            position.x += x;
            position.y += y;
            Hunger--;                

            return true;
        }

        public bool AddJob(Job _job)
        {
            if (_job is not None && JOB is not None)
                return false;
            JOB = _job;
            MaxHp += _job.addHP;
           AP += _job.addAp;
           DP += _job.addDP;
            foreach (Skill skill in _job.skillList)
                skills.Add(skill);
            return true;
        }

        public bool AddSight(int add = 1)
        {
            if (Sight == 20)
                return false;
            Sight += add;
            return true;
        }

        public void Eat(int value)
        {
            Hunger += value;
            if (Hunger >= 200)
                Data.game.GameOver(DeadCause.Eat);
        }
    }
}
