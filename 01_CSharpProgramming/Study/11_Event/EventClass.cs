using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12.Event
{
    /*
     * 이벤트 (Event)
     * 이벤트 : 일련의 사건이 발생했다는 사실을 다른 개체에게 전달
     * 델리게이트의 일부 기능을 제한하여 이벤트의 용도로 사용
     */

    public class EventBroadCaster
    {
        public delegate void EventDelegate(string msg);
        public EventDelegate OnEvent1;           // 그냥 델리게이트는 외부에서도 접근하여 실행될 수 있다
        public event EventDelegate OnEvent2;     // 이벤트 변수 : 델리게이트 변수 앞에 event 키워드를 추가하여 생성
                                                 // 이벤트 변수는 +=이나 -=으로만 체인할 수 있음

        public void Progress(string mag)
        {
            if(OnEvent1 != null)
            {
                OnEvent1(mag);       // 이벤트 발생
            }

            OnEvent2?.Invoke(mag);   // ?. (널 조건 연산자) : null이라면 하지 않는다

        }
    }

    public class EventListener
    {
        public string name;

        public EventListener(string name)
        {
            this.name = name;
        }

        public void ReceiveMessage(string msg)
        {
            Console.WriteLine(name + " : " + msg);
        }
    }

    internal class EventClass
    {
        public static void Test()
        {
            EventBroadCaster broadCaster = new EventBroadCaster();
            
            EventListener listener1 = new EventListener("Listener1");
            EventListener listener2 = new EventListener("Listener2");

            broadCaster.OnEvent1 += listener1.ReceiveMessage;
            broadCaster.OnEvent1 += listener2.ReceiveMessage;
            broadCaster.OnEvent1("이벤트 발생 1");

            // <이벤트 제약사항>
            // 1. 대입(=)을 통한 할당 불가
            //    +=과 -=을 통해 추가 할당과 할당 제거만 가능
            //    대입을 통한 할당으로 기대하고 있는 다른 함수들의 할당이 제거되는 경우를 막기 위함
            // 2. 외부에서 이벤트 발생 불가
            //    이벤트는 이벤트가 포함된 클래스 내에서만 발생 가능
            //    일련의 사건이 발생했다는 사실을 다른 객체에게 전달 용도로만 사용하기 위해
            // broadCaset.OnEvnet2 = listener1.ReceiveMessage;
            broadCaster.OnEvent2 += listener1.ReceiveMessage;
            broadCaster.OnEvent2 += listener2.ReceiveMessage;
            // broadCaster.OnVenct2("이벤트 발생");
            broadCaster.Progress("이벤트 발생 2");
        }
    }
}
