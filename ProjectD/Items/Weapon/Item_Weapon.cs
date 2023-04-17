using Personal_ProjectD.Characters;
using Personal_ProjectD.Interfaces;
using System.Numerics;

namespace Personal_ProjectD.Items.Weapons
{
    internal abstract class Item_Armor : Item, IDamageTakable
    {
        protected int weaponDice;
        protected int weaponRange;
        protected WeaponType weaponType;

        public void TakeDamage(Character attacker, IDamageGetable target)
        {
            target.GetDamage(weaponDice);
        }
    }
}
