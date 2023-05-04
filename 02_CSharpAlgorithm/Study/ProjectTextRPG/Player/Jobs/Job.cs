namespace ProjectTextRPG
{
    public abstract class Job
    {
        public string name;
        public int addHP;
        public int addAp;
        public int addDP;
        public List<Skill> skillList;

        public void AddJob()
        {
            if (Data.player.JOB != null)
                return;
            Data.player.JOB = this;
            Data.player.MaxHp += addHP;
            Data.player.AP += addAp;
            Data.player.DP += addDP;
            foreach (Skill skill in skillList)
                Data.player.skills.Add(skill);
        }

        public void Attack(Monster monster)
        {
            Console.WriteLine($"플레이어가 {name}으로 {monster.name}(을/를) 공격한다.");
            Thread.Sleep(1000);
            monster.TakeDamage(Data.player.AP);
        }
    }
}
