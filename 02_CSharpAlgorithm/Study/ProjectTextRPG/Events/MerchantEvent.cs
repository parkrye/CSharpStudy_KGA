namespace ProjectTextRPG
{
    internal class MerchantMevent : Event
    {
        public MerchantMevent() 
        {
            icon = '＄';
            Data.CreatShop();
        }

        public override void Active()
        {
            Data.game.Shop();
        }
    }
}
