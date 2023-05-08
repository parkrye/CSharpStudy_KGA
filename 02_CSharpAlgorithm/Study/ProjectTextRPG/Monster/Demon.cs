namespace ProjectTextRPG
{
    public class Demon : Monster
    {
        public Demon(int floor) : base(floor)
        {
            icon = 'ⓓ';
            name = "악마";
            maxHp = Data.random.Next((30 + floor) / 2, (30 + floor) * 2);
            curHp = maxHp;
            ap = Data.random.Next((4 + floor) / 2, (4 + floor) * 2);
            dp = Data.random.Next((4 + floor) / 2, (4 + floor) * 2);
            deadCause = DeadCause.Burn;
        }

        public override void MonsterAction()
        {
            List<Position> path;
            if (!AStar.PathFinding(in Data.map, position, Data.player.position, out path))
                return;

            if (path.Count <= 1 || path.Count > 30)
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
