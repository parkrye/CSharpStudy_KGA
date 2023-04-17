using Personal_ProjectD.Items;
using Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange;
using Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange;
using Personal_ProjectD.Skills;

namespace Personal_ProjectD.Classes
{
    public class Class_Rogue : Class
    {
        public Class_Rogue()
        {
            className = "도적";
            classHitDice = 8;
            classHitPoint = 8;
            classType = ClassType.Melee;
            classSkills = new Skill[5] { new Skill_Acrobatics(), new Skill_Deception(), new Skill_Intimitation(), new Skill_SleightOfHand(), new Skill_Stealth() };
            classItems = new Item[4] { new Item_Weapon_Rapier(), new Item_Weapon_ShortSword(), new Item_Weapon_ShortSword(), new Item_Weapon_ShortBow() };
            classArmorProficiencies = new bool[4] { true, true, false, false };
            classWeaponProficiencies = new bool[2] { true, false };
        }
    }
}
