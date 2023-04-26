namespace ProjectRPG
{
    internal class Item_HPPotion3 : Item_Active, IHealable
    {
        public Item_HPPotion3() : base()
        {
            name = "(A)치유의 포션(3)";
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
            target.NOW_HP += new Random().Next(12) + new Random().Next(12) + 2;
        }
    }
}
