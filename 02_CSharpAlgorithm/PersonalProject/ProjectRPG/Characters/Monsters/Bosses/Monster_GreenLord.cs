namespace ProjectRPG
{
    internal class Monster_GreenLord : PC
    {
        public Monster_GreenLord()
        {
            name = $"녹색 군주";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(60, 80);
            MAX_SP = random.Next(30, 50);
            MAX_PHYSICSAL = random.Next(30, 50);
            MAX_MENTAL = random.Next(20, 30);
            MAX_INITIATIVE = random.Next(20, 40);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Swing(5));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(5));
            SKILLSLOT.AddSkill(new Skill_Howling(5));

            ITEMSLOT = new ItemSlot(this, 1);
            ITEMSLOT.AddItem(new Item_WoodenClub());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
