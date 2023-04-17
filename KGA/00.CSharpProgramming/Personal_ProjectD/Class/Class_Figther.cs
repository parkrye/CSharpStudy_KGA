using Personal_ProjectD.Items.Weapons.MartialWeapon.CloseRange;
using Personal_ProjectD.Items.Weapons.SimpleWeapon.FarRange;
using Personal_ProjectD.Items;
using Personal_ProjectD.Skills;
using Personal_ProjectD.Items.Armors.HeavyArmor;
using Personal_ProjectD.Items.Armors;

namespace Personal_ProjectD.Classes
{
    public class Class_Figther : Class
    {
        public Class_Figther()
        {
            className = "전사";
            classHitDice = 10;
            classHitPoint = 10;
            classType = ClassType.Melee;
            classSkills = new Skill[5] { new Skill_Acrobatics(), new Skill_AnimalHandling(), new Skill_Athletics(), new Skill_Intimitation(), new Skill_Survival() };
            classItems = new Item[4] { new Item_Armor_ChainMail(), new Item_Weapon_LongSword(), new Item_Armor_Shield(), new Item_Weapon_LightCrossbow() };
            classArmorProficiencies = new bool[4] { true, true, true, true };
            classWeaponProficiencies = new bool[2] { true, true };
        }
    }
}
