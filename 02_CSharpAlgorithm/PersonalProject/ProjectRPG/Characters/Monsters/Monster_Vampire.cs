namespace ProjectRPG
{
    internal class Monster_Vampire : PC
    {
        public Monster_Vampire(int index)
        {
            name = $"뱀파이어 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(20, 30);
            MAX_SP = random.Next(20, 30);
            MAX_PHYSICSAL = random.Next(10, 20);
            MAX_MENTAL = random.Next(10, 20);
            MAX_INITIATIVE = random.Next(10, 20);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Revival());
            SKILLSLOT.AddSkill(new Skill_Bite());
            SKILLSLOT.AddSkill(new Skill_Bloodsucking());

            ITEMSLOT = new ItemSlot(this, 1);
            if(random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_BronzeCoin());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
