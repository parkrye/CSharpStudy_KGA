using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_9
{
    // 이하 기술에 대한 인터페이스들
    
    /// <summary>
    /// 데미지를 가할 수 있음
    /// </summary>
    interface IDamageInflictable
    {
        void InflictDamage(Pokemon target, int damage);
    }

    /// <summary>
    /// 능력치를 변동시킬 수 있음
    /// </summary>
    interface IStatusChangable
    {
        void ChangeStatus(Pokemon target, int change_Value);
    }

    /// <summary>
    /// 체력을 회복시킬 수 있음
    /// </summary>
    interface IHPRecoverable
    {
        void RecoveryHP(Pokemon target);
    }
}
