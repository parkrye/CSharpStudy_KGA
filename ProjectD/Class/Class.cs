using Personal_ProjectD.Items;
using Personal_ProjectD.Skills;

namespace Personal_ProjectD.Classes
{
    public abstract class Class
    {
        protected string className;
        protected int classHitDice;
        protected int classHitPoint;
        protected enum ClassType { Melee, Mage };
        protected ClassType classType;
        protected Skill[] classSkills;
        protected Item[] classItems;

        protected bool[] classArmorProficiencies;
        protected bool[] classWeaponProficiencies;

        public bool[] GetClassArmorProficiencies()
        {
            return classArmorProficiencies;
        }

        public bool[] GetClassWeaponProficiencies()
        {
            return classWeaponProficiencies;
        }

        public string GetClassName()
        {
            return className;
        }

        public int GetClassHitDice()
        {
            return classHitDice;
        }

        public int GetClassHitPoint()
        {
            return classHitPoint;
        }

        public Skill[] GetClassSkills()
        {
            return classSkills;
        }

        public Item[] GetClassItems()
        {
            return classItems;
        }
    }
}
