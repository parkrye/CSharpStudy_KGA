namespace ProjectRPG
{
    internal class Monster_Goblin : PC
    {
        public Monster_Goblin(int index)
        {
            name = $"고블린 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(5, 10);
            MAX_SP = random.Next(5, 10);
            MAX_PHYSICSAL = random.Next(5, 10);
            MAX_MENTAL = random.Next(5, 10);
            MAX_INITIATIVE = random.Next(5, 10);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 2);
            SKILLSLOT.AddSkill(new Skill_Scratch(new Random().Next(3)));
            SKILLSLOT.AddSkill(new Skill_Bite(new Random().Next(3)));

            ITEMSLOT = new ItemSlot(this, 2);
            ITEMSLOT.AddItem(new Item_GoblinApple());
            if (random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_WoodenAculpture());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
