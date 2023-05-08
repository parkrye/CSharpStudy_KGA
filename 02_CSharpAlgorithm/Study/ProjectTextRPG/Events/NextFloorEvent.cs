namespace ProjectTextRPG
{
    internal class NextFloorEvent : Event
    {
        public NextFloorEvent() 
        {
            icon = '@';
        }

        public override void Active()
        {
            foreach(Item item in Data.player.inventory)
            {
                if(item is Key)
                {
                    Console.Clear();
                    Data.player.inventory.Remove(item);
                    Console.WriteLine("다음 층으로 향하는 문이 열렸다!");
                    Thread.Sleep(500);
                    Data.floor++;
                    Data.CreateLevel();
                    return;
                }
            }
        }
    }
}
