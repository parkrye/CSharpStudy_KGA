using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG.Interfaces
{
    internal interface IAttackable
    {
        int Attack(int sp, ITargetable hitable);
    }
}
