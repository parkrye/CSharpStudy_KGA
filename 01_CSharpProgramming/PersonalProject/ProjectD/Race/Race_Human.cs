namespace Personal_ProjectD.Races
{
    public class Race_Human : Race
    {
        public Race_Human()
        {
            raceName = "인간";
            raceSpeed = 30;
            for (int i = 0; i < 6; i++)
                raceStatus[i] = 1;
        }
    }
}
