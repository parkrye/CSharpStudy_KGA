namespace Personal_ProjectD.Races
{
    public abstract class Race_Dwarf : Race
    {
        public Race_Dwarf()
        {
            raceSpeed = 25;
            raceStatus[(int)StatusType.건강] = 2;
        }
    }
}
