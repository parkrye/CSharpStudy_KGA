using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class VFX
    {
        public VFX(Player player)
        {
            player.AddListener(PlayEffect1);   // 체력 변동 이벤트에 함수를 할당
        }

        // 할당된 함수
        public void PlayEffect1()
        {
            Console.WriteLine("(이펙트) 반짝반짝");
        }
    }
}
