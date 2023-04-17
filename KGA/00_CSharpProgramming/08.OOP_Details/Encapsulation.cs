using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.OOP
{
    /*
     * 캡슐화 (Encapsulation)
     * 객체를 상태와 기능으로 묶는 것을 의미
     * 정보은닉: 객체의 내부 상태와 기능을 숨기고, 허용한 상태와 기능만 엑세스 허용
     */

    // <캡슐화>
    // 객체를 상태와 기능으로 묶는 것. 객체의 상태와 기능을 맴버라고 표현함
    // 현실세계의 객체를 표현하기 위해 객체가 가지는 정보와 행동을 묶어 구현하며 이를 객체간 상호작용
    // c#의 맴버로는 맴버변수(필드), 맴버함수(메서드), 상수, 속성(프로퍼티), 생성자, 이벤트, 연산자, 인덱서 등이 있음

    class Capule
    {
        int variable;

        void Function(int _v)
        {
            variable = _v;
        }
    }

    // <접근제한자>
    // 객체의 접근의 허용범위를 설정
    // 외부에서 사용해주기 원하는 기능과 내부에서만 사용하기 원하는 기능을 구분
    // 지정하지 않는 경우 기본 접근제한자는 private
    // public       : 모두 접근 가능 (외부에서 사용하기 원하는 경우)
    // private      : 클래스 내부에서만 접근 가능 (외부에서 사용하기 원하지 않는 경우)
    // protected    : 상속한 자식은 접근 가능 (상속한 자식만 사용하기 원하는 경우)
    // internal     : 같은 어셈블리(프로젝트 Lib, Dll 등)에서 접근 가능

    public class Player
    {
        public int hp;  // 외부에서 사용 가능
        private int mp; // 외부에서 사용 불가
        int exp;        // == private

        public Player(int _hp, int _mp, int _exp)
        {
            hp = _hp;
            mp = _mp;
            exp = _exp;
        }

        public void TakeDamage(int _damage)
        {
            hp -= _damage;
        }

        public void CastMagic(int _cost)
        {
            mp -= _cost;
        }

        public void GetEXP(int _add)
        {
            exp += _add;
            if(exp > 100)
                LevelUp();
        }

        private void LevelUp()
        {
            exp = 0;
        }
    }

    internal class Encapsulation
    {

    }
}
