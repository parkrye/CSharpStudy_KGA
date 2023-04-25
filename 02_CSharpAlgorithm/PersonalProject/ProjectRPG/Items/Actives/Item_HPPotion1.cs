namespace ProjectRPG
{
    internal class Item_HPPotion1 : Item_Active, IHealable
    {
        public Item_HPPotion1() : base()
        {
            name = "(A)치유의 포션(1)";
            price = 5;
            consumable = true;
        }

        /// <summary>
        /// 아이템 사용에 대한 메소드
        /// </summary>
        /// <param name="target">사용 대상</param>
        /// <returns>아이템 소모 여부</returns>
        public override bool Active(Character target)
        {
            target.NOW_HP += new Random().Next(6) + 1;
            return consumable;
        }
    }
}
