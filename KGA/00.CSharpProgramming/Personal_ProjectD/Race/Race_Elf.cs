namespace Personal_ProjectD.Races
{
    public abstract class Race_Elf : Race
    {
        public Race_Elf()
        {
            raceStatus[(int)StatusType.민첩] = 2;
            raceSpeed = 30;
        }
    }
}
