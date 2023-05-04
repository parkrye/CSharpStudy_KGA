namespace ProjectTextRPG
{
    public class Slime : Monster
    {
        public Slime() : base()
        {
            icon = 'ⓢ';
            name = "슬라임";
            maxHp = 10;
            curHp = maxHp;
            ap = 3;
            dp = 0;
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
