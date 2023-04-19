using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class PerkSlot
    {
        int size;
        Perk[] perks;

        public int SIZE
        {
            get { return size; }
            set { size = value; }
        }
        public Perk[] Perks
        {
            get { return perks; }
            set { perks = value; }
        }

        public PerkSlot(int _size)
        {
            size = _size;
            perks = new Perk[size];
        }

        public bool AddPerk(Perk perk)
        {
            if (perk == null)
                return false;

            for(int i = 0; i < size; i++)
            {
                if (perks[i] == null)
                {
                    perks[i] = perk;
                    return true;
                }
            }

            return false;
        }

        public bool RemovePerk(int index)
        {
            if (index < 0 || index >= size)
                return false;
            if (perks[index] == null)
                return false;

            perks[index] = null;
            return true;
        }

        public void ResizeSlot(int count)
        {
            Perk[] newPerks;
            if (size <= 0)
                newPerks = new Perk[1];
            else
                newPerks = new Perk[size + count];
            Array.Copy(perks, newPerks, size);
            size += count;
        }

        public bool UsePerk(int index, int sp, ITargetable hitable)
        {
            if (index < 0 || index >= size)
                return false;
            if (perks[index] == null)
                return false;

            if (perks[index] is Perk_Active)
                ((Perk_Active)perks[index]).Active(sp, hitable);
            else
                return false;
            return true;
        }
    }
}
