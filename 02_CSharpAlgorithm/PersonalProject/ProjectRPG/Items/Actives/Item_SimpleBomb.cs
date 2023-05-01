using Newtonsoft.Json.Linq;
using System.Reflection.Emit;

namespace ProjectRPG
{
    [Serializable]
    internal class Item_SimpleBomb : Item_Active, IAttackable
    {
        public Item_SimpleBomb() : base()
        {
            name = "(A)간이 폭탄";
            price = 10;
            consumable = true;
        }

        public override bool Active(Character targets)
        {
            if (targets != null)
            {
                return Attack(targets, 0);
            }
            return false;
        }

        public bool Attack(IHitable hitable, params int[] param)
        {
            int damage = new Random().Next(20);
            if (hitable.Hit(damage))
            {
                return true;
            }
            return false;
        }
    }
}
