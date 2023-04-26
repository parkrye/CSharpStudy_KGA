namespace ProjectRPG
{
    /// <summary>
    /// 마을의 의원에 대한 클래스
    /// </summary>
    internal class Clinic : TownSite
    {
        public Clinic()
        {
            name = "의료소";
        }

        public override void GetIn()
        {
            throw new NotImplementedException();
        }
    }
}
