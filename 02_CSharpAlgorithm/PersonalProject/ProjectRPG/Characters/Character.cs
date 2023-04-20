using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ProjectRPG
{
    internal abstract class Character : ITargetable
    {
        protected string? name;
        protected int hp, sp;
        protected SkillSlot? skillSlot;

        public delegate void Action(ref int param);
        protected event Action? OnDamaged, OnHPDecreased, OnSPDecreased;

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

        public SkillSlot? SKILLSLOT
        {
            get {  return skillSlot; }
            set { skillSlot = value; }
        }

        public void UseSkill(int index, ITargetable targetable)
        {
            if (skillSlot is not null)
                skillSlot.UseSkill(index, targetable, ref sp);
        }

        public void Hit(int damage)
        {
            if(OnDamaged is not null)
                OnDamaged.Invoke(ref damage);

            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
            }
        }

        public void AddListenerOnDamaged(Action action)
        {
            OnDamaged += action;
        }

        public void AddListenerOnHPDecreased(Action action)
        {
            OnHPDecreased += action;
        }

        public void AddListenerOnSPDecreased(Action action)
        {
            OnSPDecreased += action;
        }
    }
}
