using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace _12.Event.Basic
{
    internal class Player
    {
        public event Action OnGetCoint;

        public void GetCoin()
        {
            Console.WriteLine("코인을 먹었다!");
            OnGetCoint?.Invoke();
        }
    }
}
