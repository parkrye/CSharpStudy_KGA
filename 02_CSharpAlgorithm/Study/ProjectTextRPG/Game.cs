using static System.Formats.Asn1.AsnWriter;

namespace ProjectTextRPG
{
    public class Game
    {
        bool isRunning;

        Scene currScene;
        Dictionary<SceneCate, Scene> sceneDict;

        public void Run()
        {
            // 초기화
            Init();

            // 게임 루프
            while (isRunning)
            {
                // 랜더링
                Render();
                // 입력 + 갱신
                Update();
            }

            // 마무리
            Release();
        }

        void Init()
        {
            Console.Title = "Project Text RPG";
            Console.CursorVisible = false;

            isRunning = true;

            Data.init(this);

            sceneDict = new Dictionary<SceneCate, Scene>
            {
                { SceneCate.Main, new MainMenuScene(this) },
                { SceneCate.Map, new MapScene(this) },
                { SceneCate.Inve, new InventoryScene(this) },
                { SceneCate.Batt, new BattleScene(this) },
                { SceneCate.Shop, new ShopScene(this) }
            };

            currScene = sceneDict[SceneCate.Main];
        }

        void Render()
        {
            Console.ForegroundColor = ConsoleColor.White;
            currScene.Render();
        }

        void Update()
        {
            currScene.Update();
        }

        void Release()
        {
            Data.Release();
            Console.ForegroundColor = ConsoleColor.White;
            if(Data.floor > Data.high)
                Console.WriteLine($"[최고 기록 갱신! {Data.floor} → {Data.high}]");
            else
                Console.WriteLine();
            Console.WriteLine("[게임 종료]");
        }

        public void MainMenu()
        {
            Console.Clear();
            currScene = sceneDict[SceneCate.Main];
        }

        public void Map()
        {
            Console.Clear();
            currScene = sceneDict[SceneCate.Map];
        }

        public void Inventory()
        {
            Console.Clear();
            currScene = sceneDict[SceneCate.Inve];
        }

        public void Shop()
        {
            Console.Clear();
            currScene = sceneDict[SceneCate.Shop];
        }

        public void GameStart()
        {
            Console.Clear();
            Data.CreateLevel();
            currScene = sceneDict[SceneCate.Map];
        }

        public void GameOver(DeadCause deadCause)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            switch (deadCause)
            {
                case DeadCause.Beat:
                    Console.WriteLine("[당신은 맞아죽었습니다!]");
                    break;
                case DeadCause.Melt:
                    Console.WriteLine("[당신은 녹아죽었습니다!]");
                    break;
                case DeadCause.Tear:
                    Console.WriteLine("[당신은 찢겨죽었습니다!]");
                    break;
                case DeadCause.Burn:
                    Console.WriteLine("[당신은 타죽었습니다!]");
                    break;
                case DeadCause.Posion:
                    Console.WriteLine("[당신은 중독되어 죽었습니다!]");
                    break;
                case DeadCause.Starve:
                    Console.WriteLine("[당신은 굶어죽었습니다!]");
                    break;
                case DeadCause.Eat:
                    Console.WriteLine("[당신은 배가 터져 죽었습니다!]");
                    break;
            }
            isRunning = false;
            Thread.Sleep(1000);
        }

        public void BattleStart(Monster monster)
        {
            currScene = sceneDict[SceneCate.Batt];
            ((BattleScene)currScene).BattleStart(monster);
        }
    }
}
