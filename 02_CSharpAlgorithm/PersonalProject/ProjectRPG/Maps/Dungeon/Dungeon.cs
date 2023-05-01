namespace ProjectRPG
{
    /// <summary>
    /// 던전에 대한 클래스
    /// </summary>
    internal abstract class Dungeon
    {
        protected string name;                      // 던전 이름
        protected int depth;                        // 던전 깊이
        protected Queue<Queue<DungeonRoom>> floors; // 던전 층
        protected BossRoom bossRoom;                // 보스룸

        protected Player player;

        /// <summary>
        /// 던전 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }

        /// <summary>
        /// 던전 깊이에 대한 프로퍼티
        /// </summary>
        public int DEPTH { get { return depth; } }

        /// <summary>
        /// 초기화 생성자
        /// </summary>
        public Dungeon(Player _player)
        {
            player = _player;

            floors = new Queue<Queue<DungeonRoom>>();
        }

        public void EnterDungeon()
        {
            if (player.PARTY.MEMBERS == 0)
                return;
            while(floors.Count > 0)
            {
                Queue<DungeonRoom> floor = floors.Dequeue();
                int index = 1;
                while (floor.Count > 0)
                {
                    if (!floor.Dequeue().GetIn(index))
                        return;
                    index++;
                }
                Crossroad crossroad = new Crossroad(player, null, null);
                crossroad.GetIn(99);
                if (crossroad.IsReturn())
                {
                    return;
                }
            }
            BossCutScene();
            bossRoom.GetIn(99);
            if (player.PARTY.MEMBERS > 0)
                player.FINDINGS[depth] = true;
        }


        protected abstract Party EnemySetting();

        protected abstract Item ItemSetting();

        protected abstract void FloorSetting();

        protected abstract void BossSetting();

        protected abstract void BossCutScene();
    }
}
