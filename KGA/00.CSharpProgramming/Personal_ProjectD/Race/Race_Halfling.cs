namespace Personal_ProjectD.Races
{
    public class Race_Halfling : Race
    {
        public Race_Halfling()
        {
            raceSpeed = 25;
            raceStatus[(int)StatusType.민첩] = 2;
        }
    }
}
