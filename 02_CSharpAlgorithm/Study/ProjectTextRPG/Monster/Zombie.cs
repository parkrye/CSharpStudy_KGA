namespace ProjectTextRPG
{
    public class Zombie : Monster
    {
        public Zombie() : base()
        {
            icon = 'ⓩ';
            name = "좀비";
            maxHp = 20;
            curHp = maxHp;
            ap = 2;
            dp = 0;
        }

        public override void MonsterAction()
        {
            if (moveCount++ % 2 != 0)
                return;

            List<Position> path;
            if (!AStar.PathFinding(in Data.map, position, Data.player.position, out path))
                return;

            if (path.Count <= 1)
                return;

            if (path[1].x == position.x)
            {
                if (path[1].y == position.y - 1)
                    MonsterMove(Direction.Up);
                else
                    MonsterMove(Direction.Down);
            }
            else
            {
                if (path[1].x == position.x - 1)
                    MonsterMove(Direction.Left);
                else
                    MonsterMove(Direction.Right);
            }
        }
    }
}
