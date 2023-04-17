using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_11
{
    internal class Player
    {
        // 문제 1 - 4.
        event Action OnHPChanged;   // 체력 변화에 대한 이벤트

        // 데미지를 받았다면 이벤트를 호출한다
        public void GetDamage()
        {
            Console.WriteLine("플레이어가 피해를 입었다!");
            OnHPChanged?.Invoke();
        }

        // 회복을 받았다면 이벤트를 호출한다
        public void GetHeal ()
        {
            Console.WriteLine("플레이어가 회복을 받았다!");
            OnHPChanged?.Invoke();
        }

        // 이벤트에 델리게이트를 추가로 할당한다
        public void AddListener(Action action)
        {
            OnHPChanged += action;
        }

        // 이벤트에서 델리게이트를 제거한다
        public void RemoveListener(Action action)
        {
            OnHPChanged -= action;
        }

        // 문제 5.
        public delegate int DelegateAboutHP(int param);    // 데미지 발생에 대한 델리게이트
        event DelegateAboutHP OnDamaged;                   // 데미지 발생에 대한 이벤트
        int hp = 100;                                      // 플레이어 체력

        // 데미지를 받았다면 데미지 발생 이벤트를 호출한다
        public void GetDamage(int damage)
        {
            if(OnDamaged != null)                       // 데미지 이벤트에 할당된 함수가 있다면
            {
                int over = OnDamaged.Invoke(damage);    // 이벤트를 호출하여 초과된 데미지를 저장하고
                hp -= over;                             // 방어구가 막아주지 못한 데미지는 받는다
                if(over > 0)
                    Console.WriteLine("플레이어가 {0}의 데미지를 입어 체력이 {1}이 되었다!", over, hp);
                else
                    Console.WriteLine("방어구가 {0}의 피해를 막아주었다!!", damage);
            }
            else                                        // 데미지 이벤트에 할당된 함수가 없다면
            {
                hp -= damage;                           // 데미지를 받는다
                Console.WriteLine("플레이어가 {0}의 데미지를 입어 체력이 {1}이 되었다!", damage, hp);
            }
        }

        // 이벤트에 델리게이트를 추가로 할당한다
        public void AddListener2(DelegateAboutHP action)
        {
            OnDamaged += action;
        }

        // 이벤트에서 델리게이트를 제거한다
        public void RemoveListener2(DelegateAboutHP action)
        {
            OnDamaged -= action;
        }

        // 문제 5-2. 플레이어에서 방어구를 선언하고 사용하는 방식
        public delegate int DelegateAboutHP3(int param);   // 데미지 발생에 대한 델리게이트
        event DelegateAboutHP3 OnDamaged3;                 // 데미지 발생에 대한 이벤트
        int hp3 = 100;                                     // 플레이어 체력
        Armor takingArmor;                                 // 현재 착용중인 방어구

        // 방어구 착용 함수
        public void TakeOnArmor(Armor armor)
        {
            Console.WriteLine("플레이어는 방어구를 입었다!");
            takingArmor = armor;                        // 현재 방어구를 할당하고
            takingArmor.AddListener(TakeOffArmor);      // 방어구 파괴 이벤트에 방어구 해제 함수를 할당하고
            OnDamaged3 += armor.BlockDamage3;           // 데미지 발생 이벤트에 방어구 방어 함수를 할당
        }

        // 방어구 해제 함수
        public void TakeOffArmor()
        {
            Console.WriteLine("플레이어는 방어구를 벗었다!");
            takingArmor.RemoveListener(TakeOffArmor);   // 방어구 파괴 이벤트에서 방어구 해제 함수를 제거하고
            OnDamaged3 -= takingArmor.BlockDamage3;     // 데미지 발생 이벤트에서 방어구 방어 함수를 제거하고
            takingArmor = null;                         // 현재 방어구를 제거
        }

        // 데미지를 받았다면 데미지 발생 이벤트를 호출한다
        public void GetDamage3(int damage)
        {
            if (OnDamaged3 != null)                       // 데미지 이벤트에 할당된 함수가 있다면
            {
                int over = OnDamaged3.Invoke(damage);    // 이벤트를 호출하여 초과된 데미지를 저장하고
                hp3 -= over;                             // 방어구가 막아주지 못한 데미지는 받는다
                if (over > 0)
                    Console.WriteLine("플레이어가 {0}의 데미지를 입어 체력이 {1}이 되었다!", over, hp3);
                else
                    Console.WriteLine("방어구가 {0}의 피해를 막아주었다!!", damage);
            }
            else                                        // 데미지 이벤트에 할당된 함수가 없다면
            {
                hp3 -= damage;                           // 데미지를 받는다
                Console.WriteLine("플레이어가 {0}의 데미지를 입어 체력이 {1}이 되었다!", damage, hp3);
            }
        }

        // 이벤트에 델리게이트를 추가로 할당한다
        public void AddListener3(DelegateAboutHP3 action)
        {
            OnDamaged3 += action;
        }

        // 이벤트에서 델리게이트를 제거한다
        public void RemoveListener3(DelegateAboutHP3 action)
        {
            OnDamaged3 -= action;
        }

        // 문제 6.
        public delegate void DelegateAboutMana(float param1, float param2); // 마나와 연관된 델리게이트를 사용한다
        event DelegateAboutMana deligateAboutMana;                          // 이벤트 선언
        ActiveSkill[] activeSkills = new ActiveSkill[4];                    // 사용할 액티브 스킬을 선언
        int mpMax = 100;                                                    // 최대 마나
        int mpNow = 100;                                                    // 현재 마나

        // 액티브 스킬을 할당한다
        public void SetActiveSkill(int index, ActiveSkill active)
        {
            if(index >= 0 && index < 4)
                activeSkills[index] = active;
        }

        // 특정 키를 누르면 액티브 스킬을 사용한다
        public void UseSkill(int index)
        {
            if (index >= 0 && index < 4)
                if (activeSkills[index] != null)
                    // 액티브 스킬 클래스의 스킬 사용 함수의 매개변수로 현재 마나를 전달하고
                    // 액티브 스킬 클래스의 스킬 사용 함수의 반환값인 소모 마나를 매개변수로 전달하여 마나 소모 함수를 실행한다
                    UseMana(activeSkills[index].UseSkill(mpNow));
        }

        // 마나 소모 함수
        public void UseMana(int usedValue)
        {
            if (usedValue <= 0)                         // 소모 마나가 0 이하라면 굳이 실행하지 않는다
                return;
            mpNow -= usedValue;                         // 마나를 소모하고
            Console.WriteLine("플레이어가 {0} 마나를 사용해 {1} 마나가 남았다!", usedValue, mpNow);
            deligateAboutMana?.Invoke(mpMax, mpNow);    // 마나 소모 이벤트를 호출한다
        }

        // 이벤트에 델리게이트를 추가로 할당한다
        public void AddListener3(DelegateAboutMana action)
        {
            deligateAboutMana += action;
        }

        // 이벤트에서 델리게이트를 제거한다
        public void RemoveListener3(DelegateAboutMana action)
        {
            deligateAboutMana -= action;
        }
    }
}
