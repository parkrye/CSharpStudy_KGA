namespace ProjectRPG
{
    internal class Monster_Shaman : PC
    {
        public Monster_Shaman()
        {
            name = $"괴신의 무당";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(390, 400);
            MAX_SP = random.Next(390, 400);
            MAX_PHYSICSAL = random.Next(190, 200);
            MAX_MENTAL = random.Next(190, 200);
            MAX_INITIATIVE = random.Next(190, 200);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 10);
            SKILLSLOT.AddSkill(new Skill_Curse(30));
            SKILLSLOT.AddSkill(new Skill_Blessing(30));
            SKILLSLOT.AddSkill(new Skill_HealingWord(30));
            SKILLSLOT.AddSkill(new Skill_MagicBolt(30));
            SKILLSLOT.AddSkill(new Skill_DeepBreath(30));
            SKILLSLOT.AddSkill(new Skill_MagicShield(30));
            SKILLSLOT.AddSkill(new Skill_PainRefactor(30));
            SKILLSLOT.AddSkill(new Skill_Revival(30));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(30));
            SKILLSLOT.AddSkill(new Skill_SecondWind(30));

            ITEMSLOT = new ItemSlot(this, 2);
            ITEMSLOT.AddItem(new Item_HPPotion3());
            ITEMSLOT.AddItem(new Item_SPPotion3());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
