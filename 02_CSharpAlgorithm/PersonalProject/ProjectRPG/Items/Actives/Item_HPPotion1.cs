namespace ProjectRPG
{
    [Serializable]
    internal class Item_HPPotion1 : Item_Active, IHealable
    {
        public Item_HPPotion1() : base()
        {
            name = "(A)치유의 포션(1)";
            price = 5;
            consumable = true;
        }

        public override bool Active(Character target)
        {
            Heal(target);
            return consumable;
        }

        public void Heal(Character target, params int[] param)
        {
            target.NOW_HP += new Random().Next(4) + new Random().Next(4) + 1;
        }
    }
}
