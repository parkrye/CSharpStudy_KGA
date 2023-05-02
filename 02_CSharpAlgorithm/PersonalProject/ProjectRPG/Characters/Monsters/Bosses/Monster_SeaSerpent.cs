namespace ProjectRPG
{
    internal class Monster_Seaserpent : PC
    {
        public Monster_Seaserpent(int index = -1)
        {
            name = $"해룡";
            if (index > -1)
                name += $" {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(290, 300);
            MAX_SP = random.Next(190, 200);
            MAX_PHYSICSAL = random.Next(90, 100);
            MAX_MENTAL = random.Next(90, 100);
            MAX_INITIATIVE = random.Next(70, 80);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 4);
            SKILLSLOT.AddSkill(new Skill_DeepBreath(20));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(20));
            SKILLSLOT.AddSkill(new Skill_Bite(20));
            SKILLSLOT.AddSkill(new Skill_Howling(20));

            ITEMSLOT = new ItemSlot(this, 3);
            ITEMSLOT.AddItem(new Item_ShiningShell());
            ITEMSLOT.AddItem(new Item_ShiningShell());
            ITEMSLOT.AddItem(new Item_ShiningShell());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
