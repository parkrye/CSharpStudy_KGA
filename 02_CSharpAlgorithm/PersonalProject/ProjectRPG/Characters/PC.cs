using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectRPG
{
    internal class PC : Character
    {
        public PC()
        {
            Random random = new Random();
            name += (CharacterFirstName)random.Next(0, 50);
            name += (CharacterLastName)random.Next(0, 50);
            name += (CharacterLastName)random.Next(0, 50);


        }
    }
}
