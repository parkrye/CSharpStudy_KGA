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

            Data.init();

            sceneDict = new Dictionary<SceneCate, Scene>
            {
                { SceneCate.Main, new MainMenuScene(this) },
                { SceneCate.Map, new MapScene(this) },
                { SceneCate.Inve, new InventoryScene(this) },
                { SceneCate.Batt, new BattleScene(this) }
            };

            currScene = sceneDict[SceneCate.Main];
        }

        void Render()
        {
            currScene.Render();
        }

        void Update()
        {
            currScene.Update();
        }

        void Release()
        {
            Data.Release();
            Console.WriteLine("[게임 종료]");
        }

        public void MainMenu()
        {
            currScene = sceneDict[SceneCate.Main];
        }

        public void Map()
        {
            currScene = sceneDict[SceneCate.Map];
        }

        public void Inventory()
        {
            currScene = sceneDict[SceneCate.Inve];
        }

        public void GameStart()
        {
            Data.LoadLevel();
            currScene = sceneDict[SceneCate.Map];
        }

        public void GameOver()
        {
            isRunning = false;
        }

        public void BattleStart(Monster monster)
        {
            currScene = sceneDict[SceneCate.Batt];
            ((BattleScene)currScene).BattleStart(monster);
        }
    }
}
