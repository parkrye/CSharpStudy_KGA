using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08.OOP
{
    /****************************************************************
    * 다형성 (Polymorphism)
    * 
    * 부모클래스의 함수를 자식클래스에서 재정의하여 자식클래스의 서로 다른 반응을 구현
    ****************************************************************/

    // <다형성>
    // 하이딩(hiding)			: 부모클래스의 함수를 자식클래스에서 같은 이름, 매개변수로 재정의하여 자식클래스가 우선되도록 함
    // 오버라이딩(overriding)	: 부모클래스의 가상함수를 자식클래스에서 override를 통해 재정의, 부모함수가 자식함수로 대체됨

    internal class Polymorphism
    {
        public class Monster
        {
            public string name;

            public Monster(string _name)
            {
                name = _name;
            }

            public void Move()
            {
                Console.WriteLine(name + " Move");
            }

            public virtual void TakeDamage()
            {
                Console.WriteLine(name + " Die");
            }
        }

        public class Dragon : Monster
        {
            public Dragon(string _name) : base(_name)
            {

            }

            // 하이딩: 부모 클래스의 기능을 숨김(자식 클래스의 기능을 먼저 실행)
            public new void Move()
            {
                Console.WriteLine(name + " Fly");
            }

            // 오버라이딩: 부모 클래스의 기능을 대체함
            public override void TakeDamage()
            {
                Console.WriteLine(name + " Cry");
            }
        }
    }
}
