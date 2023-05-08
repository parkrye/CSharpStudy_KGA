namespace ProjectTextRPG
{
    public class Gremrin : Monster
    {
        public Gremrin(int floor) : base(floor)
        {
            icon = 'ⓖ';
            name = "그렘린";
            maxHp = Data.random.Next((10 + floor) / 2, (10 + floor) * 2);
            curHp = maxHp;
            ap = Data.random.Next((2 + floor) / 2, (2 + floor) * 2);
            dp = Data.random.Next((1 + floor) / 2, (1 + floor) * 2);
            deadCause = DeadCause.Tear;
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

                for (int i = 1; i <= 2 && i < path.Count; i++)
            {
                if (path[i].x == position.x)
                {
                    if (path[i].y == position.y - 1)
                        MonsterMove(Direction.Up);
                    else
                        MonsterMove(Direction.Down);
                }
                else
                {
                    if (path[i].x == position.x - 1)
                        MonsterMove(Direction.Left);
                    else
                        MonsterMove(Direction.Right);
                }
            }
        }
    }
}
