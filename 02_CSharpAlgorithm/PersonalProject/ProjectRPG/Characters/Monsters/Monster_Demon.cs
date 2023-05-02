namespace ProjectRPG
{
    internal class Monster_Demon : PC
    {
        public Monster_Demon(int index)
        {
            name = $"악마 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(150, 180);
            MAX_SP = random.Next(150, 160);
            MAX_PHYSICSAL = random.Next(100, 110);
            MAX_MENTAL = random.Next(100, 110);
            MAX_INITIATIVE = random.Next(80, 90);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 4);
            SKILLSLOT.AddSkill(new Skill_Howling(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Swing(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_FireBreath(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Curse(new Random().Next(10) + 1));

            ITEMSLOT = new ItemSlot(this, 2);
            if (random.Next(10) <= 5)
                ITEMSLOT.AddItem(new Item_Trident());
            else
                ITEMSLOT.AddItem(new Item_WoodenClub());
            if (random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_DeepJuel());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
