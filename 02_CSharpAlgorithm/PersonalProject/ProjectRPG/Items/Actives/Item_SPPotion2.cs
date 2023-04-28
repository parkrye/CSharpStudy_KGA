namespace ProjectRPG
{
    [Serializable]
    internal class Item_SPPotion2 : Item_Active, IHealable
    {
        public Item_SPPotion2() : base()
        {
            name = "(A)활력의 포션(2)";
            price = 20;
            consumable = true;
        }

        public override bool Active(Character target)
        {
            Heal(target);
            return consumable;
        }

        public void Heal(Character target)
        {
            target.NOW_SP += new Random().Next(8) + new Random().Next(8) + 2;
        }
    }
}
