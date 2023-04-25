﻿namespace ProjectRPG
{
    internal class Item_SPPotion3 : Item_Active
    {
        public Item_SPPotion3() : base()
        {
            name = "활력의 포션(3)";
            price = 50;
            consumable = true;
        }

        /// <summary>
        /// 아이템 사용에 대한 메소드
        /// </summary>
        /// <param name="param">능력치 데이터</param>
        /// <param name="targets">사용 대상. 0: 자신 1:추가 대상</param>
        /// <returns>아이템 소모 여부</returns>
        public override bool Active(int[,] param, params ITargetable[] targets)
        {
            param[1, 1] += new Random().Next(12) + new Random().Next(12) + 2;
            return consumable;
        }
    }
}
