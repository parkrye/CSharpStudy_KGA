namespace ProjectRPG
{
    internal class Item_SPPotion1 : Item_Active, IHealable
    {
        public Item_SPPotion1() : base()
        {
            name = "(A)활력의 포션(1)";
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
            target.NOW_SP += new Random().Next(6) + 1;
            return consumable;
        }
    }
}
