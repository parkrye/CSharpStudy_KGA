namespace ProjectRPG
{
    internal class Monster_ArmoredTurtle : PC
    {
        public Monster_ArmoredTurtle(int index)
        {
            name = $"무장거북 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(90, 100);
            MAX_SP = random.Next(40, 50);
            MAX_PHYSICSAL = random.Next(20, 30);
            MAX_MENTAL = random.Next(20, 30);
            MAX_INITIATIVE = random.Next(10, 20);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Bite(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_SecondWind(new Random().Next(7) + 1));

            ITEMSLOT = new ItemSlot(this, 2);
            ITEMSLOT.AddItem(new Item_SimpleBomb());
            if (random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_ShiningShell());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
