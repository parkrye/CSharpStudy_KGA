﻿namespace ProjectRPG
{
    /// <summary>
    /// 던전에 대한 클래스
    /// </summary>
    internal abstract class Dungeon
    {
        protected string name;                      // 던전 이름
        protected int depth;                        // 던전 깊이
        protected Queue<Queue<DungeonRoom>> floors; // 던전 층
        protected Enemies enemies;                  // 등장 적
        protected Items items;                      // 등장 아이템
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
            enemies = new Enemies();
            items = new Items();
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
            }
            BossCutScene();
            bossRoom.GetIn(99);
        }

        protected abstract void EnemySetting();
        protected abstract void ItemSetting();
        protected abstract void FloorSetting();
        protected abstract void BossSetting();

        protected abstract void BossCutScene();

        protected struct Enemies
        {
            public List<Party> party;

            public Enemies()
            {
                party = new List<Party>();
            }
        }

        protected struct Items
        {
            public List<Item> items;

            public Items()
            {
                items = new List<Item>();
            }
        }
    }
}
