namespace ProjectRPG
{
    internal class Monster_Necromancer : PC
    {
        public Monster_Necromancer(int index = -1)
        {
            name = $"사령사";
            if (index > -1)
                name += $" {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(40, 50);
            MAX_SP = random.Next(190, 200);
            MAX_PHYSICSAL = random.Next(30, 40);
            MAX_MENTAL = random.Next(70, 80);
            MAX_INITIATIVE = random.Next(30, 40);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 7);
            SKILLSLOT.AddSkill(new Skill_FireBreath(15));
            SKILLSLOT.AddSkill(new Skill_WaterShot(15));
            SKILLSLOT.AddSkill(new Skill_MagicShield(15));
            SKILLSLOT.AddSkill(new Skill_MagicBolt(15));
            SKILLSLOT.AddSkill(new Skill_Curse(15));
            SKILLSLOT.AddSkill(new Skill_DeepBreath(15));
            SKILLSLOT.AddSkill(new Skill_PainRefactor(15));

            ITEMSLOT = new ItemSlot(this, 3);
            ITEMSLOT.AddItem(new Item_SPPotion2());
            ITEMSLOT.AddItem(new Item_SPPotion2());
            ITEMSLOT.AddItem(new Item_MysteriousRing());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
