namespace ProjectRPG
{
    internal class Monster_Gremrin : PC
    {
        public Monster_Gremrin(int index)
        {
            name = $"그렘린 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(60, 70);
            MAX_SP = random.Next(60, 70);
            MAX_PHYSICSAL = random.Next(40, 50);
            MAX_MENTAL = random.Next(40, 50);
            MAX_INITIATIVE = random.Next(40, 50);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 6);
            SKILLSLOT.AddSkill(new Skill_FireBreath(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_LuckyAttack(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Scratch(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Howling(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Arcrobatics(new Random().Next(10) + 1));

            ITEMSLOT = new ItemSlot(this, 2);
            ITEMSLOT.AddItem(new Item_Trident());
            if (random.Next(10) == 0)
                ITEMSLOT.AddItem(new Item_DeepJuel());

            for (int i = 0; i < 5; i++)
                DIFFICULTY += status[0, i] / 10;
            DIFFICULTY += SKILLSLOT.QUANTITY;
            DIFFICULTY += ITEMSLOT.QUANTITY;
        }
    }
}
