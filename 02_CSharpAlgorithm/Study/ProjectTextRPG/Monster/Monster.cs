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

        public Monster()
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
                Console.WriteLine($"{name}(은/는) {damage - dp} 데미지를 받았다.");
                curHp -= damage - dp;
            }
            else
                Console.WriteLine($"공격은 {name}에게 먹히지 않았다.");

            Thread.Sleep(1000);

            if (curHp <= 0)
            {
                Console.WriteLine($"{name}(은/는) 쓰려졌다!");
                Thread.Sleep(1000);
            }
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{name}(이/가) 플레이어를 공격합니다.");
            Thread.Sleep(1000);
            player.TakeDamage(ap);
        }
    }
}
