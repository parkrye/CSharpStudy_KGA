﻿namespace ProjectRPG
{
    /// <summary>
    /// 마을의 집에 대한 클래스
    /// </summary>
    internal class Home : TownSite
    {
        public Home()
        {
            name = "집";
        }

        public override void GetIn()
        {
            throw new NotImplementedException();
        }
    }
}
