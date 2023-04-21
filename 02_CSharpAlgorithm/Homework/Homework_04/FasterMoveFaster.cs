namespace Homework_04
{
    // 문제 3-1.

    /// <summary>
    /// 플레이어 행동 순서
    /// </summary>
    internal class FasterMoveFaster
    {
        /// <summary>
        /// 순서 실행
        /// </summary>
        public void StartOrder()
        {
            // 속도가 다른 다섯의 플레이어
            Player player1 = new Player("김마법사", 1);
            Player player2 = new Player("이도적", 4);
            Player player3 = new Player("박전사", 3);
            Player player4 = new Player("최레인저", 5);
            Player player5 = new Player("정사제", 2);

            // 순서대로 행동 개시
            Ordering(player1, player2, player3, player4, player5);
        }

        /// <summary>
        /// 플레이어의 속도가 빠른 순서대로 행동
        /// </summary>
        /// <param name="players">임의의 수의 플레이어</param>
        public void Ordering(params Player[] players)
        {
            Queue<Player> order = new Queue<Player>();      // 순서를 저장할 큐
            Queue<Player> tempQ = new Queue<Player>();  // 순서를 저장하기 위한 임시 큐
            foreach (Player p in players)                   // 각 플레이어에 대해
            {
                if(!order.IsEmpty())                         // 큐 차있다면
                {
                    do
                    {
                        Player poped = order.Dequeue();         // 큐 하나를 꺼내

                        if (poped.SPEED > p.SPEED)          // 속도를 비교하고
                        {
                            tempQ.Enqueue(poped);          // 꺼낸 것이 더 빠르다면 꺼낸 것을 임시로 넣는다
                        }
                        else
                        {                                   // 꺼낸 것이 더 느리거나 같다면
                            tempQ.Enqueue(p);                  // 이번 플레이어도 넣고
                            tempQ.Enqueue(poped);              // 꺼낸 것을 넣고
                            while (!order.IsEmpty())     // 임시에 넣어둔 더 빠른 플레이어들도 넣는다
                            {
                                tempQ.Enqueue(order.Dequeue());
                            }
                            break;              // 그리고 반복을 탈출한다
                        }
                    } while (!order.IsEmpty()); // 순서가 비어있지 않다면 이를 반복

                    while (!tempQ.IsEmpty())     // 이후 임시에 있던 플레이어들을 순서에 넣는다
                    {
                        order.Enqueue(tempQ.Dequeue());
                    }

                }
                else
                {
                    order.Enqueue(p);                          // 큐 비어있다면 푸시한다
                }
            }

            while(!order.IsEmpty())
            {
                order.Dequeue().TakeAction();                   // 빠른 순서로 행동한다
            }
        }
    }

    /// <summary>
    /// 플레이어 클래스
    /// </summary>
    internal class Player
    {
        string name;    // 플레이어 이름
        int speed;      // 플레이어 속도

        /// <summary>
        /// 플레이어 이름에 대한 프로퍼티
        /// </summary>
        public string NAME
        {
            get { return name; }
        }

        /// <summary>
        /// 플레이어 속도에 대한 프로퍼티
        /// </summary>
        public int SPEED
        {
            get { return speed; }
        }

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="_name">플레이어 이름</param>
        /// <param name="_speed">플레이어 속도</param>
        public Player(string _name, int _speed)
        {
            name = _name;
            speed = _speed;
        }

        /// <summary>
        /// 플레이어 행동
        /// </summary>
        public void TakeAction()
        {
            Console.WriteLine($"{name} 행동했습니다!");
        }
    }
}
