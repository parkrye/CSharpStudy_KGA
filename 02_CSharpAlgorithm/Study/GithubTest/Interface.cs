using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubTest
{
    public interface IAttackable
    {
        void Attack(IDamageTakable damageTakable);
    }

    public interface IDamageTakable
    {
        void TakeDamage(int damage);
    }

}
