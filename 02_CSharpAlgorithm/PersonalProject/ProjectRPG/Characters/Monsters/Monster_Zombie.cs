namespace ProjectRPG
{
    internal class Monster_Zombie : PC
    {
        public Monster_Zombie(int index)
        {
            name = $"좀비 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(20, 40);
            MAX_SP = 0;
            MAX_PHYSICSAL = random.Next(10, 20);
            MAX_MENTAL = 0;
            MAX_INITIATIVE = random.Next(1, 5);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 2);
            SKILLSLOT.AddSkill(new Skill_Revival());
            SKILLSLOT.AddSkill(new Skill_Bite());

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
