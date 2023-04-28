namespace ProjectRPG
{
    internal abstract class DungeonRoom
    {
        protected string name;  // 방 이름

        protected bool inRoom;  // 방 잔류 여부
        protected int cursor;   // 커서
        protected bool clicked; // 클릭 여부
        protected int index;

        protected Player player;
        protected Party enemy;
        protected Item item;

        /// <summary>
        /// 방 이름에 대한 프로퍼티
        /// </summary>
        public string NAME { get { return name; } }
        
        /// <summary>
        /// 방 잔류에 대한 프로퍼티
        /// </summary>
        public bool InRoom { get {  return inRoom; } }

        /// <summary>
        /// 플레이어, 등장할 수 있는적을 설정하는 생성자
        /// </summary>
        /// <param name="_player">플레이어</param>
        /// <param name="_enemy">적 파티</param>
        public DungeonRoom(Player _player, Party _enemy, Item _item)
        {
            player = _player;
            enemy = _enemy;
            item = _item;
        }

        /// <summary>
        /// 방에 진입하는 메소드
        /// </summary>
        public bool GetIn(int _index)
        {
            index = _index;
            inRoom = true;
            cursor = 0;
            clicked = false;
            while (InRoom)
            {
                ShowUI();
                ShowContent();
                MoveCursor();
                ClickCursor();
                if (player.PARTY.MEMBERS == 0)
                    return false;
            }
            return true;
        }

        protected void ShowUI()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < 60; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("=");
                Console.SetCursorPosition(i, 10);
                Console.Write("=");
            }
            for (int i = 1; i < 10; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("||");
                Console.SetCursorPosition(58, i);
                Console.Write("||");
            }

            if (index < 99)
            {
                Console.SetCursorPosition(20, 1);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"[{name} : {index}/10]");
            }
            else
            {
                Console.SetCursorPosition(23, 1);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"[{name}]");
            }
        }

        /// <summary>
        /// 방의 구조를 보여주는 메소드
        /// </summary>
        protected abstract void ShowContent();

        /// <summary>
        /// 커서를 움직이는 메소드
        /// </summary>
        protected abstract void MoveCursor();

        /// <summary>
        /// 커서를 클릭하는 메소드
        /// </summary>
        protected abstract void ClickCursor();
    }
}
