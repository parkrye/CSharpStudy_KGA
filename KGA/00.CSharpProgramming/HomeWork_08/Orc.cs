using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork_8
{

    // 문제 2. 상속을 이용하여 오크를 정의
    public class Orc : Monster
    {
        OrcSkill skill;

        // 몬스터 생성자 + 오크 스킬 할당
        public Orc(string _name, int _hp, int _atk) : base(_name, _hp, _atk)
        {
            skill = new OrcSkill();
        }

        // 문제 3. 다형성을 이용하여 데미지를 받는 경우 오크는 분노하도록 구현
        public new void TakeDamage(int _damage)
        {
            base.TakeDamage(_damage);
            if (hp > 0)
                Console.WriteLine(name + " 은/는 분노했습니다");
            else
                Console.WriteLine(name + " 은/는 죽었습니다");
        }

        // 문제 4. 추상화를 이용하여 오크에 스킬 추가
        public override void UseSkill(int skillNum)
        {
            // 살아있으면
            if (hp > 0)
            {
                // 입력된 스킬 번호에 따라 스킬을 사용한다
                Console.Write(name + " 은/는 ");
                switch (skillNum)
                {
                    case 0:
                        skill.Q(atk);
                        break;
                    case 1:
                        skill.W(atk);
                        break;
                    case 2:
                        skill.E(atk);
                        break;
                    case 3:
                        skill.R(atk);
                        break;
                    default:
                        Console.WriteLine("그런 스킬 없습니다");
                        break;
                }
            }
            else // 죽었으면 스킬을 못쓴다
            {
                Console.WriteLine(name + " 은/는 그냥 시체입니다");
            }
        }
    }
}
