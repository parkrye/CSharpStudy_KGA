namespace ProjectRPG
{
    /// <summary>
    /// 마을의 상점에 대한 클래스
    /// </summary>
    internal class Market : TownSite
    {
        public Market()
        {
            name = "상점";
        }

        public override void GetIn()
        {
            throw new NotImplementedException();
        }
    }
}
