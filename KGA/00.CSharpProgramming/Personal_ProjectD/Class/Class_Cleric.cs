using Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange;
using Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange;
using Personal_ProjectD.Items;
using Personal_ProjectD.Skills;
using Personal_ProjectD.Items.Weapons.SimpleWeapon.CloseRange;
using Personal_ProjectD.Items.Armors.NormalArmor;

namespace Personal_ProjectD.Classes
{
    public class Class_Cleric : Class
    {
        public Class_Cleric()
        {
            className = "성직자";
            classHitDice = 8;
            classHitPoint = 8;
            classType = ClassType.Mage;
            classSkills = new Skill[5] { new Skill_History(), new Skill_Insight(), new Skill_Medicine(), new Skill_Persuasion(), new Skill_Religion() };
            classItems = new Item[3] { new Item_Weapon_Mace(), new Item_Armor_ScaleMail(), new Item_Weapon_LightCrossbow() };
            classArmorProficiencies = new bool[4] { true, true, true, true };
            classWeaponProficiencies = new bool[2] { true, false };
        }
    }
}
