using System;

namespace ProjectRPG
{
    internal class Monster_Orc : PC
    {
        public Monster_Orc(int index)
        {
            name = $"오수귀 {index}";

            Random random = new Random();

            status = new int[2, 5];
            MAX_HP = random.Next(12, 18);
            MAX_SP = random.Next(12, 18);
            MAX_PHYSICSAL = random.Next(5, 10);
            MAX_MENTAL = random.Next(2, 8);
            MAX_INITIATIVE = random.Next(2, 10);
            StatusSetting(true);

            SKILLSLOT = new SkillSlot(this, 3);
            SKILLSLOT.AddSkill(new Skill_Swing());
            SKILLSLOT.AddSkill(new Skill_RoughSkin());

            ITEMSLOT = new ItemSlot(this, 3);
            if(random.Next(10) < 2)
                ITEMSLOT.AddItem(new Item_WoodenAculpture());
        }
    }
}
