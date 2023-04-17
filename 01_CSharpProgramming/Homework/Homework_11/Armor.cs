using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static HomeWork_11.Player;

namespace HomeWork_11
{
    internal class Armor
    {
        Player player;      // 현재 착용 중인 플레이어
        int armorHP = 50;   // 방어구의 내구도

        // 생성자
        public Armor(Player player)
        {
            this.player = player;                   // 플레이어에게 착용시키고
            this.player.AddListener2(BlockDamage);  // 데미지 발생 이벤트에 함수를 할당한다
        }

        // 데미지 발생 이벤트가 호출되면 실행되는 함수
        public int BlockDamage(int damage)
        {
            // 방어구 내구도와 데미지를 비교하여
            if (armorHP < damage)   // 데미지가 크다면
            {
                Console.WriteLine("데미지를 막은 방어구가 부서져버렸다!");
                player.RemoveListener2(BlockDamage);    // 방어구가 무서지고(방어구 호출을 데미지 이벤트에서 제거하고)
                return damage - armorHP;                // 플레이어가 받아야 하는 초과 데미지를 반환한다
            }
            else                    // 데미지가 작다면
            {
                armorHP -= damage;                      // 데미지만큼 방어구 내구도를 소모하고
                Console.WriteLine("방어구가 모든 데미지를 막아주었다!");
                return 0;                               // 플레이어가 받아야 하는 0 데미지를 반환한다
            }
        }

        // 이하 플레이어에서 방어구 객체를 선언하는 방식
        event Action DestroyArmor;  // 방어구 파괴 이벤트

        // 데미지 발생 함수
        public int BlockDamage3(int damage)
        {
            // 방어구 내구도와 데미지를 비교하여
            if (armorHP < damage)   // 데미지가 크다면
            {
                DestroyArmor?.Invoke();                 // 방어구 파괴 이벤트를 호출하고
                return damage - armorHP;                // 플레이어가 받아야 하는 초과 데미지를 반환한다
            }
            else                    // 데미지가 작다면
            {
                armorHP -= damage;                      // 데미지만큼 방어구 내구도를 소모하고
                return 0;                               // 플레이어가 받아야 하는 0 데미지를 반환한다
            }
        }

        // 이벤트에 델리게이트를 추가로 할당한다
        public void AddListener(Action action)
        {
            DestroyArmor += action;
        }

        // 이벤트에서 델리게이트를 제거한다
        public void RemoveListener(Action action)
        {
            DestroyArmor -= action;
        }
    }
}
