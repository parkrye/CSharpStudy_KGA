using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class ActiveSkill
    {
        int usingManaValue;         // 소모 마나
        bool coolDown = false;      // 스킬 쿨다운 여부

        // 생성자
        public ActiveSkill(int usingManaValue)
        {
            this.usingManaValue = usingManaValue;
        }

        // 스킬 사용 함수. 매개변수로 현재 마나량을 전달받는다
        public int UseSkill(int mana)
        {
            if (coolDown)             // 쿨다운이면 사용할 수 없다
            {
                Console.WriteLine("현재 쿨다운이다");
                return 0;
            }

            if(mana < usingManaValue) // 마나가 부족하면 사용할 수 없다
            {
                Console.WriteLine("마나가 부족하다");
                return 0;
            }

            Console.WriteLine("사용하면 {0} 마나로 뭔가 하는 액티브 스킬을 사용하였다!", usingManaValue);
            coolDown = true;     // 스킬을 사용했으므로 쿨다운이 돈다
            return usingManaValue;    // 사용할 수 있으므로 소모 마나를 반환한다
        }
    }
}
