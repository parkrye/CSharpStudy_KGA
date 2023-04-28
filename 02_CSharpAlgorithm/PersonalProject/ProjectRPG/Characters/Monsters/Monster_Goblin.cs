namespace ProjectRPG
{
    internal class Monster_Goblin : PC
    {
        public Monster_Goblin(int index)
        {
            name = $"소귀 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(5, 8);
            MAX_SP = random.Next(5, 8);
            MAX_PHYSICSAL = random.Next(3, 8);
            MAX_MENTAL = random.Next(1, 5);
            MAX_INITIATIVE = random.Next(1, 8);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Scratch());

            ITEMSLOT = new ItemSlot(this, 3);
            if(random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_WoodenAculpture());
        }
    }
}
