﻿namespace ProjectRPG
{
    /// <summary>
    /// 기능이 없는 아이템에 대한 클래스
    /// </summary>
    internal abstract class Item_None : Item
    {
        /// <summary>
        /// 생성자
        /// </summary>
        public Item_None()
        {
            type = ItemType.NONE;
        }
    }
}
