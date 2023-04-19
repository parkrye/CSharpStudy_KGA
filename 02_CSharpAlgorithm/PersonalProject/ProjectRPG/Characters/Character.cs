using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal abstract class Character : ITargetable
    {
        protected string name;
        protected int hp, sp;
        protected SkillSlot skillSlot;

        public event Func<int, int> OnHPEvent, OnSPEvent, OnHitEvent, OnDeadEvent;

        public string NAME 
        { 
            get { return name; }
            set { name = value; }
        }

        public int HP 
        { 
            get { return hp; } 
            set { hp = value; }
        }

        public int SP 
        { 
            get { return sp; } 
            set { sp = value; }
        }

        public SkillSlot SKILLSLOT
        {
            get {  return skillSlot; }
            set { skillSlot = value; }
        }

        public void UseSkill(int index, ITargetable targetable)
        {
            sp -= skillSlot.UseSkill(index, targetable, sp);
        }

        public void Hit(int damage)
        {
            OnHitEvent.Invoke(damage);
            TakeDamage(damage);
        }

        public void TakeDamage(int damage)
        {
            OnHitEvent.Invoke(damage);
            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
                OnDeadEvent.Invoke(0);
            }
        }
    }
}
