namespace ProjectTextRPG
{
    public class Slime : Monster
    {
        public Slime(int floor) : base(floor)
        {
            icon = 'ⓢ';
            name = "슬라임";
            maxHp = Data.random.Next((10 + floor) / 2, (10 + floor) * 2);
            curHp = maxHp;
            ap = Data.random.Next((3 + floor) / 2, (3 + floor) * 2);
            dp = Data.random.Next((floor) / 2, (floor) * 2);
            deadCause = DeadCause.Melt;
        }

        public override void MonsterAction()
        {
            switch (Data.random.Next(4))
            {
                case 0:
                    MonsterMove(Direction.Left);
                    break;
                case 1:
                    MonsterMove(Direction.Right);
                    break;
                case 2:
                    MonsterMove(Direction.Up);
                    break;
                case 3:
                    MonsterMove(Direction.Down);
                    break;
            }
        }
    }
}
