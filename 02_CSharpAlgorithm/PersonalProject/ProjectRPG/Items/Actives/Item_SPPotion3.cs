namespace ProjectRPG
{
    [Serializable]
    internal class Item_SPPotion3 : Item_Active, IHealable
    {
        public Item_SPPotion3() : base()
        {
            name = "(A)활력의 포션(3)";
            price = 50;
            consumable = true;
        }

        public override bool Active(Character target)
        {
            Heal(target);
            return consumable;
        }

        public void Heal(Character target)
        {
            target.NOW_SP += new Random().Next(12) + new Random().Next(12) + 2;
        }
    }
}
