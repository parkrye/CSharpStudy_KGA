namespace ProjectRPG
{
    internal class Monster_SeaGhost : PC
    {
        public Monster_SeaGhost(int index)
        {
            name = $"물귀신 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(40, 50);
            MAX_SP = random.Next(170, 180);
            MAX_PHYSICSAL = random.Next(20, 30);
            MAX_MENTAL = random.Next(70, 80);
            MAX_INITIATIVE = random.Next(30, 40);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 5);
            SKILLSLOT.AddSkill(new Skill_Revival(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_MagicBolt(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_WaterShot(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_Curse(new Random().Next(7) + 1));
            SKILLSLOT.AddSkill(new Skill_MagicShield(new Random().Next(7) + 1));

            ITEMSLOT = new ItemSlot(this, 1);
            if(random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_ShiningShell());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
