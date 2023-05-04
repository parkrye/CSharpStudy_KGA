namespace ProjectTextRPG
{
    public class Gremrin : Monster
    {
        public Gremrin() : base()
        {
            icon = 'ⓖ';
            name = "그렘린";
            maxHp = 15;
            curHp = maxHp;
            ap = 2;
            dp = 1;
        }

        public override void MonsterAction()
        {
            if (moveCount++ % 3 != 0)
                return;

            List<Position> path;
            if (!AStar.PathFinding(in Data.map, position, Data.player.position, out path))
                return;

            for(int i = 1; i <= 2 && i < path.Count; i++)
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
