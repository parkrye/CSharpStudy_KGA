namespace Homework_06
{
    /// <summary>
    /// 이진검색트리
    /// </summary>
    /// <typeparam name="T">자로형</typeparam>
    internal class BinarySearchTree<T> where T : IComparable<T>
    {
        /// <summary>
        /// 노드
        /// </summary>
        private class Node
        {
            T item; // 노드의 값
            Node parent, leftChild, rightChild; // 부모, 왼쪽 자식, 오른족 자식 노드

            /// <summary>
            /// 생성자
            /// </summary>
            /// <param name="_item">노드의 값</param>
            public Node(T _item) { item = _item; }

            // 프로퍼티
            public T ITEM { get { return item; } set { item = value; } }
            public Node PARENT { get { return parent; } set { parent = value; } }
            public Node LEFTCHILD { get { return leftChild; } set { leftChild = value; } }
            public Node RIGHTCHILD { get { return rightChild; } set { rightChild = value; } }

            /// <summary>
            /// 이 노드가 왼쪽 자식이 있는가
            /// </summary>
            /// <returns></returns>
            public bool HasLeftChild() { return leftChild != null; }

            /// <summary>
            /// 이 노드가 오른쪽 자식이 있는가
            /// </summary>
            /// <returns></returns>
            public bool HasRightChild() { return rightChild != null; }

            /// <summary>
            /// 이 노드가 자식이 있는가
            /// </summary>
            /// <returns></returns>
            public bool HasChild() { return HasLeftChild() || HasRightChild(); }

            /// <summary>
            /// 이 노드가 왼쪽 자식인가
            /// </summary>
            /// <returns></returns>
            public bool IsLeftChild() { return parent != null && parent.leftChild == this; }

            /// <summary>
            /// 이 노드가 오른쪽 자식인가
            /// </summary>
            /// <returns></returns>
            public bool IsRightChild() { return parent != null && parent.rightChild == this; }
            
            /// <summary>
            /// 이 노드가 루트 노드인가
            /// </summary>
            /// <returns></returns>
            public bool IsRootChild() { return parent == null; }
        }

        Node root;  // 루트 노드
        Comparer<T> comparer;   // 비교자

        /// <summary>
        /// 생성자
        /// </summary>
        public BinarySearchTree()
        {
            root = null;
            comparer = Comparer<T>.Default;
        }

        /// <summary>
        /// 노드를 추가하는 메소드
        /// </summary>
        /// <param name="item">추가할 노드의 값</param>
        /// <returns>추가 성공 여부</returns>
        public bool Add(T item)
        {
            // 입력 값의 노드
            Node newNode = new Node(item);
            if (root == null)   // 최초라면 루트 노드로
            {
                root = newNode;
                return true;
            }
            else
            {
                Node cursor = root; // 루트 노드에서 출발
                while (cursor != null)  // 빈 노드를 가리키기까지 반복
                {
                    if (comparer.Compare(item, cursor.ITEM) < 0)    // 추가 노드가 커서가 가리키는 노드보다 작다면
                    {
                        if (cursor.LEFTCHILD == null)   // 커서의 왼쪽이 비어있다면 그 자리에 추가
                        {
                            cursor.LEFTCHILD = newNode;
                            newNode.PARENT = cursor;
                            return true;
                        }
                        else    // 비어있지 않다면 커서 이동
                        {
                            cursor = cursor.LEFTCHILD;
                        }
                    }
                    else if (comparer.Compare(item, cursor.ITEM) > 0)    // 추가 노드가 커서가 가리키는 노드보다 크다면
                    {
                        if (cursor.RIGHTCHILD == null)   // 커서의 오른쪽이 비어있다면 그 자리에 추가
                        {
                            cursor.RIGHTCHILD = newNode;
                            newNode.PARENT = cursor;
                            return true;
                        }
                        else    // 비어있지 않다면 커서 이동
                        {
                            cursor = cursor.RIGHTCHILD;
                        }
                    }
                    else    // 추가 노드가 커서가 가리키는 노드와 같다면 추가할 수 없음(중복 불가)
                        return false;
                }
            }
            return false;
        }

        /// <summary>
        /// 노드를 삭제하는 메소드
        /// </summary>
        /// <param name="item">삭제할 노드의 값</param>
        /// <returns>삭제 성공 여부</returns>
        public bool Remove(T item)
        {
            Node cursor = FindNode(item);   // 해당하는 값의 노드 찾기
            if (cursor == null) // 해당하는 값의 노드가 없다면 false
                return false;
            EraseNode(cursor);  // 해당하는 값의 노드가 있다면 삭제
            return true;
        }

        /// <summary>
        /// 트리를 초기화하는 메소드
        /// </summary>
        public void Clear()
        {
            root = null;
        }

        /// <summary>
        /// 노드를 찾고 그 값을 저장하는 메소드
        /// </summary>
        /// <param name="item">찾을 노드의 값</param>
        /// <param name="outValue">찾은 노드의 값을 저장할 변수</param>
        /// <returns>검색 및 저장 성공 여부</returns>
        public bool TryGetValue(T item, out T outValue)
        {
            outValue = default(T);
            Node finding = FindNode(item);   // 해당하는 값의 노드 찾기
            if (finding == null) // 해당하는 값의 노드가 없다면 false
                return false;
            outValue = finding.ITEM;  // 해당하는 값의 노드가 있다면 변수에 값 저장 
            return true;
        }

        /// <summary>
        /// 노드를 찾는 메소드
        /// </summary>
        /// <param name="item">찾을 노드의 값</param>
        /// <returns>검색한 노드. 찾지 못할 경우 null</returns>
        private Node FindNode(T item)
        {
            Node cursor = root; // 루트 노드부터 탐색
            while (cursor.HasChild())   // 커서에 자식이 있다면
            {
                if ((comparer.Compare(item, cursor.ITEM) == 0)) // 커서의 값이 찾던 값이라면
                {
                    return cursor;  // 커서를 반환
                }
                else if (comparer.Compare(item, cursor.ITEM) < 0)   // 커서의 값이 찾던 값보다 크다면
                {
                    cursor = cursor.LEFTCHILD;  // 커서를 왼쪽으로
                }
                else
                {
                    cursor = cursor.RIGHTCHILD; // 커서를 오른쪽으로
                }
            }
            return null;    // 찾지 못하여 null 반환
        }

        /// <summary>
        /// 노드를 삭제하는 메소드
        /// </summary>
        /// <param name="node">삭제할 노드</param>
        private void EraseNode(Node node)
        {
            if (!node.HasChild())   // 노드에 자식이 없다면
            {
                if (node.IsLeftChild()) // 부모로부터 삭제
                    node.PARENT.LEFTCHILD = null;
                else if (node.IsRightChild())
                    node.PARENT.RIGHTCHILD = null;
                else
                    root = null;    // 루트 노드였다면 루트 삭제
            }
            else if(node.HasLeftChild() && node.HasRightChild())    // 노드에 자식이 둘 다 있다면
            {
                Node cursor = node.LEFTCHILD;   // 커서는 일단 왼쪽 자식
                while (cursor.HasRightChild())  // 커서에게 오른족 자식이 있다면
                    cursor = cursor.RIGHTCHILD; // 계속 오른쪽 자식으로
                                                // (노드보다 작은 값중에 가장 큰 값을 찾음)
                node.ITEM = cursor.ITEM;  // 찾은 노드를 삭제 노드와 바꾸고, 삭제 노드를 삭제
                EraseNode(cursor);
            }
            else    // 노드에 자식이 하나만 있다면
            {
                if (node.HasLeftChild())    // 왼쪽 자식이라면
                {
                    if(node.IsRootChild())  // 루트 노드라면 왼쪽 자식이 루트
                        root = node.LEFTCHILD;
                    else
                    {
                        if (node.IsLeftChild()) // 왼쪽 자식이었다면 왼쪽 자식이 부모의 새 자식
                            node.PARENT.LEFTCHILD = node.LEFTCHILD;
                        else if (node.IsRightChild()) // 오른쪽 자식이었다면 왼쪽 자식이 부모의 새 자식
                            node.PARENT.RIGHTCHILD = node.LEFTCHILD;
                        node.LEFTCHILD.PARENT = node.PARENT;    // 왼쪽 자식의 부모도 재설정
                    }
                }
                else    // 오른쪽 자식이라면
                {
                    if (node.IsRootChild()) // 루트 노드라면 오른쪽 자식이 루트
                        root = node.RIGHTCHILD;
                    else
                    {
                        if (node.IsLeftChild()) // 왼쪽 자식이었다면 오른쪽 자식이 부모의 새 자식
                            node.PARENT.LEFTCHILD = node.RIGHTCHILD;
                        else if (node.IsRightChild()) // 오른쪽 자식이었다면 오른쪽 자식이 부모의 새 자식
                            node.PARENT.RIGHTCHILD = node.RIGHTCHILD;
                        node.RIGHTCHILD.PARENT = node.PARENT;    // 오른쪽 자식의 부모도 재설정
                    }
                }
            }
        }

        public void Print()
        {
            Console.WriteLine("[전위순회]");
            PrintPrevOrder(root);
            Console.WriteLine("[중위순회]");
            PrintMidOrder(root);
            Console.WriteLine("[후위순회]");
            PrintNextOrder(root);
        }

        /// <summary>
        /// 전위순회
        /// </summary>
        /// <param name="node">현재 노드</param>
        void PrintPrevOrder(Node node)
        {
            Console.WriteLine(node.ITEM);
            if (node.HasLeftChild()) PrintPrevOrder(node.LEFTCHILD);
            if (node.HasRightChild()) PrintPrevOrder(node.RIGHTCHILD);
        }

        /// <summary>
        /// 중위순회
        /// </summary>
        /// <param name="node">현재 노드</param>
        void PrintMidOrder(Node node)
        {
            if (node.HasLeftChild()) PrintMidOrder(node.LEFTCHILD);
            Console.WriteLine(node.ITEM);
            if (node.HasRightChild()) PrintMidOrder(node.RIGHTCHILD);
        }

        /// <summary>
        /// 후위순회
        /// </summary>
        /// <param name="node">현재 노드</param>
        void PrintNextOrder(Node node)
        {
            if (node.HasLeftChild()) PrintNextOrder(node.LEFTCHILD);
            if (node.HasRightChild()) PrintNextOrder(node.RIGHTCHILD);
            Console.WriteLine(node.ITEM);
        }
    }
}
