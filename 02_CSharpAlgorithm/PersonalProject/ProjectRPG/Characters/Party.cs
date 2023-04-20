namespace ProjectRPG
{
    internal class Party
    {
        PC[] party;
        int members;

        public PC[] PCs
        {
            get { return party; }
            set { party = value; }
        }

        public int MEMBERS
        {
            get { return members; }
            set { members = value; }
        }

        public Party()
        {
            party = new PC[4];
        }

        public void AddPC(PC pc)
        {
            for(int i = 0; i < 4; i++)
            {
                if (party[i] == null)
                {
                    party[i] = pc;
                    members++;
                    break;
                }
            }
        }

        public void RemovePC(int index)
        {
            if (index < 0 || index >= 4)
                return;
            party[index] = null;
            members--;
        }

        public bool IsEmpty()
        {
            if (members > 0)
                return false;
            return true;
        }

        public PC GetMember(int index)
        {
            if (index < 0 || index >= 4)
                return null;
            return party[index];
        }
    }
}
