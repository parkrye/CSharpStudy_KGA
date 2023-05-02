namespace ProjectRPG
{
    internal class Monster_DeepOne : PC
    {
        public Monster_DeepOne(int index)
        {
            name = $"딥원 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(80, 90);
            MAX_SP = random.Next(80, 90);
            MAX_PHYSICSAL = random.Next(60, 70);
            MAX_MENTAL = random.Next(60, 70);
            MAX_INITIATIVE = random.Next(60, 70);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 7);
            SKILLSLOT.AddSkill(new Skill_WaterShot(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_LuckyAttack(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Scratch(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Howling(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Arcrobatics(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_RoughSkin(new Random().Next(10) + 1));
            SKILLSLOT.AddSkill(new Skill_Curse(new Random().Next(10) + 1));

            ITEMSLOT = new ItemSlot(this, 4);
            if (random.Next(10) <= 5)
                ITEMSLOT.AddItem(new Item_Trident());
            else
                ITEMSLOT.AddItem(new Item_WoodenClub());
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
