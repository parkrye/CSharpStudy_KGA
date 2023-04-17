using Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange;
using Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange;
using Personal_ProjectD.Items;
using Personal_ProjectD.Skills;
using Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange;

namespace Personal_ProjectD.Classes
{
    public class Class_Wizard : Class
    {
        public Class_Wizard()
        {
            className = "마법사";
            classHitDice = 6;
            classHitPoint = 6;
            classType = ClassType.Mage;
            classSkills = new Skill[5] { new Skill_Arcana(), new Skill_History(), new Skill_Insight(), new Skill_Investigation(), new Skill_Medicine() };
            classItems = new Item[2] { new Item_Weapon_QuaterStaff(), new Item_Weapon_Dagger() };
            classArmorProficiencies = new bool[4] { true, false, false, false };
            classWeaponProficiencies = new bool[2] { true, false };
        }
    }
}
