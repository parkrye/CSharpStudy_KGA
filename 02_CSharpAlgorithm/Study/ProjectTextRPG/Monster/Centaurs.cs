namespace ProjectTextRPG
{
    public class Centaurs : Monster
    {
        public Centaurs(int floor) : base(floor)
        {
            icon = 'ⓒ';
            name = "켄타우르스";
            maxHp = Data.random.Next((20 + floor) / 2, (20 + floor) * 2);
            curHp = maxHp;
            ap = Data.random.Next((2 + floor) / 2, (2 + floor) * 2);
            dp = Data.random.Next((floor) / 2, (floor) * 2);
            deadCause = DeadCause.Beat;
        }

        public override void MonsterAction()
        {
            if (moveCount++ % 3 != 0)
                return;

            List<Position> path;
            if (!AStar.PathFinding(in Data.map, position, Data.player.position, out path))
                return;

            if (path.Count <= 1 || path.Count > 30)
                return;

            if (path[1].x == position.x)
            {
                if (path[1].y == position.y - 1)
                {
                    MonsterMove(Direction.Up);
                    MonsterMove(Direction.Up);
                }
                else
                {
                    MonsterMove(Direction.Down);
                    MonsterMove(Direction.Down);
                }
            }
            else
            {
                if (path[1].x == position.x - 1)
                {
                    MonsterMove(Direction.Left);
                    MonsterMove(Direction.Left);
                }
                else
                {
                    MonsterMove(Direction.Right);
                    MonsterMove(Direction.Right);
                }
            }
        }
    }
}
