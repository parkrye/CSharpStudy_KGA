using Personal_ProjectD.Characters;

namespace Personal_ProjectD.Interfaces
{
    interface IDamageTakable
    {
        void TakeDamage(Character attacker, IDamageGetable target);
    }

    interface IDamageGetable
    {
        void GetDamage(int damage);
    }
}
