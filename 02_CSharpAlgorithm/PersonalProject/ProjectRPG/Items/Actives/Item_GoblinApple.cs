namespace ProjectRPG
{
    [Serializable]
    internal class Item_GoblinApple : Item_Active, IHealable
    {
        public Item_GoblinApple() : base()
        {
            name = "(A)고블린 사과";
            price = 3;
            consumable = true;
        }

        public override bool Active(Character target)
        {
            Heal(target);
            return consumable;
        }

        public void Heal(Character target, params int[] param)
        {
            target.NOW_HP += new Random().Next(4) + 1;
        }
    }
}
