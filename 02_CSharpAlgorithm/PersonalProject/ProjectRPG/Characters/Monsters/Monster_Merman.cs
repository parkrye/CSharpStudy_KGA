namespace ProjectRPG
{
    internal class Monster_Merman : PC
    {
        public Monster_Merman(int index)
        {
            name = $"어인 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(50, 60);
            MAX_SP = random.Next(50, 60);
            MAX_PHYSICSAL = random.Next(30, 40);
            MAX_MENTAL = random.Next(30, 40);
            MAX_INITIATIVE = random.Next(20, 30);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 4);
            SKILLSLOT.AddSkill(new Skill_LuckyAttack(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_Scratch(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_Howling(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_Arcrobatics(new Random().Next(7) + 1));

            ITEMSLOT = new ItemSlot(this, 2);
            ITEMSLOT.AddItem(new Item_Trident());
            if (random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_ShiningShell());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
