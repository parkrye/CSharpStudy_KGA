namespace DataStructure
{
    internal class PriorityQueue<TElement, TPriority>
    {
        /// <summary>
        /// 구조체를 이용하여 각 요소를 구현
        /// </summary>
        struct Item
        {
            public TElement element;    // 요소의 값
            public TPriority priority;  // 요소의 우선도

            /// <summary>
            /// 기본 생성자
            /// </summary>
            public Item()
            {
                element = default(TElement);
                priority = default(TPriority);
            }

            /// <summary>
            /// 값과 우선도를 지정하는 생성자
            /// </summary>
            /// <param name="_element">요소의 값</param>
            /// <param name="_priority">요소의 우선도</param>
            public Item(TElement _element, TPriority _priority)
            {
                element = _element;
                priority = _priority;
            }
        }

        List<Item> list;    // 리스트를 사용하여 구현
        IComparer<TPriority> comparer;  // 비교자

        public int COUNT { get { return list.Count; } }

        /// <summary>
        /// 기본 생성자
        /// </summary>
        public PriorityQueue()
        {
            Clear();
            comparer = Comparer<TPriority>.Default;
        }

        /// <summary>
        /// 비교자를 포함하는 생성자
        /// </summary>
        /// <param name="_comparer">비교자</param>
        public PriorityQueue(IComparer<TPriority> _comparer)
        {
            Clear();
            comparer = _comparer;
        }

        /// <summary>
        /// 큐를 초기화하는 함수
        /// </summary>
        public void Clear()
        {
            list = new List<Item>();
        }

        /// <summary>
        /// 우선도가 가장 낮은 요소의 값을 반환하고 삭제하는 함수
        /// </summary>
        /// <returns>우선도가 가장 낮은 요소의 값</returns>
        public TElement Dequeue()
        {
            Item rootItem = list[0];

            // 1. 마지막 요소를 최상단으로 위치
            Item lastItem = list[COUNT - 1];
            list[0] = lastItem;
            list.RemoveAt(COUNT - 1);

            // 2. 최상단의 요소를 있어야 할 위치로 재배열한다
            int lastIndex = 0;
            while(lastIndex < COUNT)
            {
                (int left, int right) childrenIndexes = GetChildrenIndex(lastIndex);

                // 2. 자식의 수에 따라 나누어 처리
                // 2-1. 자식이 둘일 때
                if (childrenIndexes.right < COUNT)
                {
                    // 2-1. 두 자식 중 우선순위가 더 높은 자식을 대상으로 처리
                    int lessChildIndex = comparer.Compare(list[childrenIndexes.left].priority, list[childrenIndexes.right].priority) <= 0 ? childrenIndexes.left : childrenIndexes.right;
                    
                    if (comparer.Compare(list[lessChildIndex].priority, list[lastIndex].priority) < 0)
                    {
                        list[lastIndex] = list[lessChildIndex];
                        list[lessChildIndex] = lastItem;
                        lastIndex = lessChildIndex;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2-2. 자식이 하나일 때(왼쪽 자식만 있을 때)
                else if (childrenIndexes.left < COUNT)
                {
                    if (comparer.Compare(list[childrenIndexes.left].priority, list[lastIndex].priority) < 0)
                    {
                        list[lastIndex] = list[childrenIndexes.left];
                        list[childrenIndexes.left] = lastItem;
                        lastIndex = childrenIndexes.left;
                    }
                    else
                    {
                        break;
                    }
                }
                // 2-3. 자식이 없을 때
                else
                {
                    break;
                }
            }

            return rootItem.element;
        }

        /// <summary>
        /// 새로운 요소를 추가하는 함수
        /// </summary>
        /// <param name="element">추가할 요소의 값</param>
        /// <param name="priority">추가할 요소의 우선도</param>
        public void Enqueue(TElement element, TPriority priority)
        {
            Item newItem = new Item(element, priority);

            // 1. 추가할 요소를 가장 뒤에 추가
            list.Add(newItem);
            int newIndex = COUNT - 1;
            
            // 2. 추가한 요소를 부모와 비교하여 교환
            while(newIndex > 0)
            {
                int parentIndex = GetParentIndex(newIndex);
                Item parentItem = list[parentIndex];
                if(comparer.Compare(newItem.priority, parentItem.priority) < 0)
                {
                    list[newIndex] = parentItem;
                    list[parentIndex] = newItem;
                    newIndex = parentIndex;
                }
                else
                {
                    // 현재 위치에 좌우 요소가 존재한다면, 왼쪽에 더 작은 아이템을 놓고 싶음
                    if(newIndex > 0 && newIndex + 1 < COUNT)
                    {
                        int brotherIndex;
                        Item brotherItem;
                        // 짝수라면 왼쪽(-1)이 형제
                        if (newIndex % 2 == 0)
                        {
                            brotherIndex = newIndex - 1;
                            brotherItem = list[brotherIndex];
                            // 현재 노드가 오른쪽인데 더 작다면 교환
                            if (comparer.Compare(newItem.priority, brotherItem.priority) < 0)
                            {
                                list[newIndex] = brotherItem;
                                list[brotherIndex] = newItem;
                            }
                        }
                        // 홀수라면 오른쪽(+1)이 형제
                        else
                        {
                            brotherIndex = newIndex + 1;
                            brotherItem = list[brotherIndex];
                            // 현재 노드가 왼쪽인데 더 크다면 교환
                            if (comparer.Compare(newItem.priority, brotherItem.priority) > 0)
                            {
                                list[newIndex] = brotherItem;
                                list[brotherIndex] = newItem;
                            }
                        }
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// 새로운 요소를 추가하고 즉시 우선도가 낮은 요소의 값을 반환하는 함수
        /// </summary>
        /// <param name="element">추가할 요소의 값</param>
        /// <param name="priority">추가할 요소의 우선도</param>
        /// <returns>요소를 추가한 후 가장 우선도가 낮은 요소의 값</returns>
        public TElement EnqueueDequeue(TElement element, TPriority priority)
        {
            Enqueue(element, priority);
            return Dequeue();
        }

        /// <summary>
        /// 부모의 인덱스를 반환하는 함수
        /// </summary>
        /// <param name="childIndex">자식의 인덱스</param>
        /// <returns>부모의 인덱스</returns>
        int GetParentIndex(int childIndex)
        {
            return (childIndex - 1) / 2;
        }

        /// <summary>
        /// 자식의 인덱스를 반환하는 함수
        /// </summary>
        /// <param name="parentIndex">부모의 인덱스</param>
        /// <returns>(왼쪽 자식 인덱스, 오른쪽 자식 인덱스) 튜플</returns>
        (int, int) GetChildrenIndex(int parentIndex)
        {
            return (parentIndex * 2 + 1, parentIndex * 2 + 2);
        }

        /// <summary>
        /// 우선도가 가장 낮은 요소의 값을 반환하는 함수
        /// </summary>
        /// <returns>우선도가 가장 낮은 요소의 값</returns>
        public TElement Peek()
        {
            return list[0].element;
        }

        /// <summary>
        /// 우선도가 가장 낮은 요소를 삭제할 수 있다면 값과 우선도를 복사하고 성공 여부를 반환하는 함수
        /// </summary>
        /// <param name="element">제거할 요소의 값을 복사할 값</param>
        /// <param name="priority">제거할 요소의 우선도를 복사할 값</param>
        /// <returns>요소 제거 성공 여부. false일 경우 default 값을 복사한다</returns>
        public bool TryDequeue(out TElement element, out TPriority priority)
        {
            try
            {
                priority = list[0].priority;
                element = Dequeue();
            }
            catch
            {
                element = default(TElement);
                priority = default(TPriority);
                return false;
            }
            return true;
        }

        /// <summary>
        /// 우선도가 가장 낮은 요소를 반환할 수 있다면 값과 우선도를 복사하고 성공 여부를 반환하는 함수
        /// </summary>
        /// <param name="element">제거할 요소의 값을 복사할 값</param>
        /// <param name="priority">제거할 요소의 우선도를 복사할 값</param>
        /// <returns>값 반환 성공 여부. false일 경우 default 값을 복사한다</returns>
        public bool TryPeek(out TElement element, out TPriority priority)
        {
            try
            {
                element = list[0].element;
                priority = list[0].priority;
            }
            catch
            {
                element = default(TElement);
                priority = default(TPriority);
                return false;
            }
            return true;
        }
    }
}
