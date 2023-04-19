using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class PC : Character
    {
        public PC(string? _name = null, int _hp = 10, int _sp = 10, int _perkSlotSize = 6)
        {
            if(_name != null)
                name = _name;
            else
            {

            }
            hp = _hp;
            sp = _sp;
            perkSlot = new PerkSlot(_perkSlotSize);
        }
    }
}
