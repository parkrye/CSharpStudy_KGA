using System;

namespace ProjectTextRPG
{
    public abstract class Monster
    {
        public char icon;
        public Position position;
        public int moveCount;
        public string name;

        public int curHp;
        public int maxHp;
        public int ap;
        public int dp;
        public DeadCause deadCause;

        public Monster(int floor)
        {
            while (true)
            {
                int y = Data.random.Next(Data.map.GetLength(0));
                int x = Data.random.Next(Data.map.GetLength(1));

                if (Data.map[y, x])
                {
                    position = new Position(x, y);
                    return;
                }
            }
        }

        public abstract void MonsterAction();

        public bool MonsterMove(Direction dir)
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

        public void TakeDamage(int damage)
        {
            if (damage > dp)
            {
                Console.WriteLine($"{name}(은/는) {damage - dp} 데미지를 받았다!");
                curHp -= damage - dp;
            }
            else
                Console.WriteLine($"{name}(은/는) 아무렇지 않다!");

            Thread.Sleep(500);

            if (curHp <= 0)
            {
                Console.WriteLine($"{name}(은/는) 쓰려졌다!");
                Thread.Sleep(500);
            }
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{name}(이/가) 당신을 공격했다!");
            Thread.Sleep(500);
            player.TakeDamage(Data.random.Next(ap / 2, ap * 2));
        }
    }
}
