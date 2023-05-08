namespace ProjectTextRPG
{
    internal class CoinEvnet : Event
    {
        int money;

        public CoinEvnet() 
        {
            icon = '￦';
            money = Data.random.Next(1, Data.floor + 1);
        }

        public override void Active()
        {
            Data.player.Money += money;
            Data.events.Remove(this);
        }
    }
}
