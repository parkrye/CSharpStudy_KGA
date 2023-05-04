namespace ProjectTextRPG
{
    public abstract class Scene
    {
        protected Game game;

        public Scene(Game _game)
        {
            game = _game;
        }

        public abstract void Render();
        
        public abstract void Update();
    }
}
