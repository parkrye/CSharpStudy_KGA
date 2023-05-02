namespace ProjectRPG
{
    internal class Monster_Color : PC
    {
        public Monster_Color(int index)
        {
            name = $"색체 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(10, 20);
            MAX_SP = random.Next(150, 160);
            MAX_PHYSICSAL = random.Next(10, 20);
            MAX_MENTAL = random.Next(150, 160);
            MAX_INITIATIVE = random.Next(150, 160);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 4);
            SKILLSLOT.AddSkill(new Skill_PainRefactor(new Random().Next(10) + 5));
            SKILLSLOT.AddSkill(new Skill_MagicShield(new Random().Next(10) + 5));
            SKILLSLOT.AddSkill(new Skill_Revival(new Random().Next(10) + 5));
            SKILLSLOT.AddSkill(new Skill_Curse(new Random().Next(10) + 5));

            ITEMSLOT = new ItemSlot(this, 1);
            ITEMSLOT.AddItem(new Item_DeepJuel());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
