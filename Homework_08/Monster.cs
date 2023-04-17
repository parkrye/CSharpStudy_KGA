using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{

    // 문제 1. 캡슐화를 이용하여 몬스터를 정의
    public abstract class Monster
    {
        // 각 맴버 변수는 자신 및 자식 클래스에서만 접근 가능
        protected string name;
        protected int hp, atk;

        // 생성자. skill은 몬스터 별로 다르기 때문에 할당하지 않음
        public Monster(string _name, int _hp, int _atk)
        {
            name = _name;
            hp = _hp;
            atk = _atk;
        }

        // 이름을 사용하려면 이거 쓰세요
        public string GetName()
        {
            return name;
        }

        public void SetName(string _name)
        {
            name = _name;
        }

        // hp를 사용하려면 이거 쓰세요
        public int GetHP()
        {
            return hp;
        }

        public void SetHP(int _hp)
        {
            hp = _hp;
        }

        // atk를 사용하려면 이거 쓰세요
        public int GetATK()
        {
            return atk;
        }

        public void SetATK(int _atk)
        {
            atk = _atk;
        }

        // 문제 3. 다형성을 이용하여 데미지를 받는 경우
        public virtual void TakeDamage(int _damage)
        {
            hp -= _damage;
            hp = hp < 0 ? 0 : hp;
            Console.WriteLine("{0} 은/는 {1}의 데미지를 입어 체력이 {2}이 되었습니다", name, _damage, hp);
        }

        // 문제 4. 추상화를 이용하여 몬스터에 스킬 추가
        public abstract void UseSkill(int skillNum);
    }
}
