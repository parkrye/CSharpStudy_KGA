using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class SFX
    {
        public SFX(Player player)
        {
            player.AddListener(PlaySound1);   // 체력 변동 이벤트에 함수를 할당
        }

        // 할당된 함수
        public void PlaySound1()
        {
            Console.WriteLine("(효과음) 띠링띠링");
        }
    }
}
