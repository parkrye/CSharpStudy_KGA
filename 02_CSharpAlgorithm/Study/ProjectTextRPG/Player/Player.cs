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
        public Job JOB { get; set; }

        public List<Skill> skills;

        public Player()
        {
            MaxHp = 100;
            CurHp = MaxHp;
            Level = 1;
            MaxExp = 100;
            CurExp = 0;
            AP = 5;
            DP = 1;

            skills = new List<Skill>();
            skills.Add(new Attack());
            skills.Add(new Recovery());
        }

        public void GetItem(Item item)
        {
            Data.inventory.Add(item);
        }

        public void UseItem(Item item)
        {
            Data.inventory.Remove(item);
            item.Use();
        }

        public void AddEXP(int value)
        {
            CurExp += value;
            while (CurExp >= MaxExp) 
            {
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
                Console.WriteLine($"플레이어는 {damage - DP} 데미지를 받았다.");
                CurHp -= damage - DP;
            }
            else
                Console.WriteLine($"공격은 플레이어에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (CurHp <= 0)
            {
                Console.WriteLine($"플레이어는 쓰려졌다!");
                Thread.Sleep(1000);
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

            return true;
        }
    }
}
