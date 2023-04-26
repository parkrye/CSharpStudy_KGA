namespace ProjectRPG
{
    /// <summary>
    /// 마을의 주막에 대한 클래스
    /// </summary>
    internal class Tavern : TownSite
    {
        public Tavern()
        {
            name = "주막";
        }

        public override void GetIn()
        {
            throw new NotImplementedException();
        }
    }
}
