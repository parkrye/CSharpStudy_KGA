namespace ProjectRPG
{
    internal class Monster_Orc : PC
    {
        public Monster_Orc(int index)
        {
            name = $"오크 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(20, 30);
            MAX_SP = random.Next(10, 20);
            MAX_PHYSICSAL = random.Next(10, 20);
            MAX_MENTAL = random.Next(10, 20);
            MAX_INITIATIVE = random.Next(10, 20);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Swing(new Random().Next(5) + 1));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(new Random().Next(5) + 1));
            SKILLSLOT.AddSkill(new Skill_Bite(new Random().Next(5) + 1));

            ITEMSLOT = new ItemSlot(this, 4);
            ITEMSLOT.AddItem(new Item_WoodenClub());
            ITEMSLOT.AddItem(new Item_GoblinApple());
            ITEMSLOT.AddItem(new Item_GoblinApple());
            if(random.Next(10) < 2)
                ITEMSLOT.AddItem(new Item_WoodenAculpture());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
