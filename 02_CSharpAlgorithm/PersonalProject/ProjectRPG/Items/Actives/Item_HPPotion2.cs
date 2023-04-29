namespace ProjectRPG
{
    [Serializable]
    internal class Item_HPPotion2 : Item_Active, IHealable
    {
        public Item_HPPotion2() : base()
        {
            name = "(A)치유의 포션(2)";
            price = 20;
            consumable = true;
        }

        public override bool Active(Character target)
        {
            Heal(target);
            return consumable;
        }

        public void Heal(Character target, params int[] param)
        {
            target.NOW_HP += new Random().Next(8) + new Random().Next(8) + 2;
        }
    }
}
