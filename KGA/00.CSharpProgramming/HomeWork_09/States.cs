using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    public class None : State
    {
        public None()
        {
            state_Name = "없음";
            state_Duration = -1;
        }

        protected override void ApplyState()
        {

        }
    }

    public class Stunned : State
    {
        public Stunned()
        {
            state_Name = "기절";
            state_Duration = 1;
        }

        protected override void ApplyState()
        {

        }
    }

    public class Poisoned : State, IDamageInflictable
    {
        public Poisoned()
        {
            state_Name = "독";
            state_Duration = 10;
        }

        public void InflictDamage(Pokemon target, int damage)
        {

        }

        protected override void ApplyState()
        {

        }
    }

    internal class Burned : State, IDamageInflictable
    {
        public Burned()
        {
            state_Name = "화상";
            state_Duration = 10;
        }

        public void InflictDamage(Pokemon target, int damage)
        {

        }

        protected override void ApplyState()
        {

        }
    }
}
