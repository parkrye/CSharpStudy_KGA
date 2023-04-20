namespace ProjectRPG
{
    internal abstract class Character : ITargetable
    {
        protected string? name;
        protected float hp, sp;
        protected SkillSlot? skillSlot;

        public delegate float Action(float param);
        protected event Action? OnDamaged, OnHPDecreased, OnSPDecreased;

        public string NAME 
        { 
            get { return name; }
            set { name = value; }
        }

        public float HP 
        { 
            get { return hp; } 
            set { hp = value; }
        }

        public float SP 
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
            {
                sp -= skillSlot.UseSkill(index, targetable, sp);
                if (OnSPDecreased is not null)
                    sp += OnSPDecreased.Invoke(sp);
            }
        }

        public void Hit(float damage)
        {
            if(OnDamaged is not null)
                damage -= OnDamaged.Invoke(damage);

            hp -= damage;
            if (hp < 0)
            {
                hp = 0;
                if (OnHPDecreased is not null)
                    hp += OnHPDecreased.Invoke(hp);
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
