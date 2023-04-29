namespace ProjectRPG
{
    internal class Monster_Necromancer : PC
    {
        public Monster_Necromancer()
        {
            name = $"네크로맨서";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(30, 50);
            MAX_SP = random.Next(150, 200);
            MAX_PHYSICSAL = random.Next(20, 40);
            MAX_MENTAL = random.Next(60, 80);
            MAX_INITIATIVE = random.Next(20, 40);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_MagicShield(12));
            SKILLSLOT.AddSkill(new Skill_MagicBolt(12));
            SKILLSLOT.AddSkill(new Skill_DeepBreath(20));

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
