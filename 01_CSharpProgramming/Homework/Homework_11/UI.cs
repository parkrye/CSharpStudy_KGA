using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class UI
    {
        // 생성자
        public UI(Player player)
        {
            player.AddListener(UpdatePlayerHPUI);   // 체력 변동 이벤트에 함수를 할당
        }

        // 할당된 함수
        public void UpdatePlayerHPUI()
        {
            Console.WriteLine("(UI 수정)");
        }
    }
}
