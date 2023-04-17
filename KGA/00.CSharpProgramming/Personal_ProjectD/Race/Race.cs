namespace Personal_ProjectD.Races
{
    public abstract class Race
    {
        protected string raceName;
        protected int raceSpeed;
        protected int[] raceStatus = new int[6];

        public string GetRaceName()
        {
            return raceName;
        }

        public int GetRaceSpeed()
        {
            return raceSpeed;
        }
        public int[] GetRaceStatus()
        {
            return raceStatus;
        }
    }
}
