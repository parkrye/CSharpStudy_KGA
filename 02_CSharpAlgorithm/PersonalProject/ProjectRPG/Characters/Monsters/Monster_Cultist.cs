namespace ProjectRPG
{
    internal class Monster_Cultist : PC
    {
        public Monster_Cultist(int index)
        {
            name = $"사교도 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(60, 70);
            MAX_SP = random.Next(150, 160);
            MAX_PHYSICSAL = random.Next(40, 50);
            MAX_MENTAL = random.Next(70, 80);
            MAX_INITIATIVE = random.Next(60, 70);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 7);
            SKILLSLOT.AddSkill(new Skill_WaterShot(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_FireBreath(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Curse(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_MagicBolt(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_MagicShield(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_PainRefactor(new Random().Next(10) + 1));

            ITEMSLOT = new ItemSlot(this, 4);
            ITEMSLOT.AddItem(new Item_MysteriousRing());
            ITEMSLOT.AddItem(new Item_HPPotion2());
            ITEMSLOT.AddItem(new Item_SPPotion2());
            if (random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_DeepJuel());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
