using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class PassiveSkill
    {
        bool coolDown = false;  // 스킬 쿨다운 여부

        // 생성자
        public PassiveSkill(Player player)
        {
            player.AddListener3(UseSkill);  // 마나 소모 이벤트에 함수를 할당한다
        }

        // 스킬 사용 함수. 매개 변수로 최대 마나와 현재 마나를 전달받는다
        private void UseSkill(float param1, float param2)
        {
            if (coolDown)               // 쿨다운이라면 사용할 수 없다
                return;

            if(param2 / param1 <= 0.5f) // 현재 마나량이 전체의 50% 이하인 경우
            {
                Console.WriteLine("마나가 절반 이하가 되면 자동으로 뭔가 하는 패시브 스킬이 발동되었다!");
                coolDown = true;        // 스킬을 사용했으므로 쿨다운이 돈다
            }
        }
    }
}
