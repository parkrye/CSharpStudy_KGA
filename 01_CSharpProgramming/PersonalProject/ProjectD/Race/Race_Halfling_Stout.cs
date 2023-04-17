namespace Personal_ProjectD.Races
{
    public class Race_Halfling_Stout : Race_Halfling
    {
        public Race_Halfling_Stout()
        {
            raceName = "스타우트 하플링";
            raceStatus[(int)StatusType.건강] = 1;
        }
    }
}
