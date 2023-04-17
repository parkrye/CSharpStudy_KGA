using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    public abstract class State
    {
        protected string state_Name;
        protected int state_Duration;

        protected abstract void ApplyState();
    }
}
