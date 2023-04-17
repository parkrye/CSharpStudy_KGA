using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GithubTest
{
    internal class Player: IAttackable, IDamageTakable
    {
        string name;
        public string NAME
        {
            get { return name; }
            set { name = value; }
        }

        int hp;
        public int HP
        {
            get { return hp; }
            set { hp = value; }
        }
        int ap;
        public int AP
        {
            get { return ap; }
            set { ap = value; }
        }

        public void Attack(IDamageTakable damageTakable)
        {
            Console.WriteLine($"{name} attack {damageTakable}");
            damageTakable.TakeDamage(ap);
        }

        public void TakeDamage(int damage)
        {
            Console.WriteLine($"{name} take {damage} damage");
        }
    }
}
