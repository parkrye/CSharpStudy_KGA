namespace MyDataStructure
{
    public class LinkedListNode<T>
    {
        LinkedList<T>? list;
        LinkedListNode<T>? prev;
        LinkedListNode<T>? next;
        T item;

        public LinkedList<T> LIST 
        { 
            get { return list; } 
            set { list = value; }
        }

        public LinkedListNode<T>? PREV 
        {
            get { return prev; } 
            set { prev = value; }
        }

        public LinkedListNode<T>? NEXT
        {
            get { return next; }
            set { next = value; }
        }

        public T ITEM
        {
            get { return item; }
            set { item = value; }
        }

        public LinkedListNode(T _item) : this(_item, null) { }

        public LinkedListNode(T _item, LinkedList<T>? _list) : this(_item, _list, null, null) { }

        public LinkedListNode(T _item, LinkedList<T>? _list, LinkedListNode<T>? _prev, LinkedListNode<T>? _next)
        {
            item = _item;
            list = _list;
            prev = _prev;
            next = _next;
        }
    }

    public class LinkedList<T>
    {
        LinkedListNode<T>? head;
        LinkedListNode<T>? tail;
        int count;

        public LinkedListNode<T>? HEAD
        {
            get { return head; }
            set { head = value; }
        }

        public LinkedListNode<T>? TAIL
        {
            get { return tail; }
            set { tail = value; }
        }

        public int COUNT
        {
            get { return count; }
            set { count = value; }
        }

        public LinkedList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public LinkedList(IEnumerable<T> enumerable) : base()
        {
            foreach(T item in enumerable)
            {
                AddLast(new LinkedListNode<T>(item));
            }
        }

        public void AddAfter(LinkedListNode<T> criterion, T item)
        {
            AddAfter(criterion, new LinkedListNode<T>(item));
        }

        public void AddAfter(LinkedListNode<T> criterion, LinkedListNode<T> addNode)
        {
            if (criterion == null)
                throw new ArgumentNullException(nameof(criterion));
            if (!Contains(criterion))
                throw new InvalidOperationException(nameof(criterion));
            if (addNode == null)
                throw new ArgumentNullException(nameof(addNode));
            if (addNode.LIST != null)
                throw new InvalidOperationException(nameof(addNode));

            addNode.LIST = this;
            addNode.PREV = criterion;
            if (criterion.NEXT != null)
            {
                criterion.NEXT.PREV = addNode;
                addNode.NEXT = criterion.NEXT;
            }
            else
                tail = addNode;
            criterion.NEXT = addNode;
            count++;
        }

        public void AddBefore(LinkedListNode<T> criterion, T item)
        {
            AddBefore(criterion, new LinkedListNode<T>(item));
        }

        public void AddBefore(LinkedListNode<T> criterion, LinkedListNode<T> addNode)
        {
            if (criterion == null)
                throw new ArgumentNullException(nameof(criterion));
            if (!Contains(criterion))
                throw new InvalidOperationException(nameof(criterion));
            if (addNode == null)
                throw new ArgumentNullException(nameof(addNode));
            if (addNode.LIST != null)
                throw new InvalidOperationException(nameof(addNode));

            addNode.LIST = this;
            addNode.NEXT = criterion;
            if (criterion.PREV != null)
            {
                criterion.PREV.NEXT = addNode;
                addNode.PREV = criterion.PREV;
            }
            else
                head = addNode;
            criterion.PREV = addNode;
            count++;
        }

        public void AddFirst(T item)
        {
            AddFirst(new LinkedListNode<T>(item));
        }

        public void AddFirst(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (node.LIST != null)
                throw new InvalidOperationException(nameof(node));

            node.LIST = this;
            if (head == null)
                head = node;
            else
            {
                if (tail == null)
                    tail = head;
                head.PREV = node;
                node.NEXT = head;
                head = node;
            }
            count++;
        }

        public void AddLast(T item)
        {
            AddLast(new LinkedListNode<T>(item));
        }

        public void AddLast(LinkedListNode<T> node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));
            if (node.LIST != null)
                throw new InvalidOperationException(nameof(node));

            node.LIST = this;
            if (head == null)
                head = node;
            else
            {
                if(tail == null)
                {
                    head.NEXT = node;
                    node.PREV = head;
                }
                else
                {
                    tail.NEXT = node;
                    node.PREV = tail;
                }
                tail = node;
            }
            count++;
        }

        public void Clear()
        {
            while (count > 0)
                RemoveFirst();
        }

        public bool Contains(T item)
        {
            if (Find(item) == null)
                return false;
            return true;
        }

        public bool Contains(LinkedListNode<T> node)
        {
            return Contains(node.ITEM);
        }

        public void CopyTo(T[] array, int index = 0)
        {
            if (array == null)
                throw new ArgumentNullException(nameof(array));
            if (index < 0)
                throw new ArgumentOutOfRangeException(nameof(index));
            if (index + count > array.Length)
                throw new ArgumentException(nameof(array));

            LinkedListNode<T> now = head;
            for(int i = 0; i < count; i++)
            {
                array[i] = now.ITEM;
                now = now.NEXT;
            }
        }

        public LinkedListNode<T>? Find(T item)
        {
            if(head == null)
                return null;

            LinkedListNode<T> now = head;
            for (int i = 0; i < count; i++)
            {
                if (now.ITEM.Equals(item))
                    return now;
                now = now.NEXT;
            }

            return null;
        }

        public LinkedListNode<T>? FindLast(T item)
        {
            if (tail == null)
                return Find(item);

            LinkedListNode<T> now = tail;
            for (int i = 0; i < count; i++)
            {
                if (now.ITEM.Equals(item))
                    return now;
                now = now.PREV;
            }

            return null;
        }

        public bool Remove(T item)
        {
            return Remove(Find(item));
        }

        public bool Remove(LinkedListNode<T>? node)
        {
            if (node == null)
                throw new ArgumentNullException(nameof(node));

            if (!Contains(node))
                throw new InvalidOperationException(nameof(node));

            if (count == 0)
                return false;

            node.LIST = null;
            if (node == head)
                head = node.NEXT;
            if (node == tail)
                tail = node.PREV;
            if (node.NEXT != null)
                node.NEXT.PREV = node.PREV;
            if (node.PREV != null)
                node.PREV.NEXT = node.NEXT;
            count--;

            return true;
        }

        public bool RemoveFirst()
        {
            if (head == null)
                throw new InvalidOperationException(ToString());

            if (head.NEXT != null)
                head.NEXT.PREV = null;
            head = head.NEXT;
            if(head != null && tail == head)
            {
                head.NEXT = null;
                tail.PREV = null;
                tail = null;
            }
            count--;

            return true;
        }

        public bool RemoveLast()
        {
            if (tail == null)
                return RemoveFirst();

            if(tail.PREV != null)
                tail.PREV.NEXT = null;
            tail = tail.PREV;
            if (head != null && tail == head)
            {
                head.NEXT = null;
                tail.PREV = null;
                tail = null;
            }
            count--;

            return true;
        }

        public string SpreadValues()
        {
            if (head == null)
                return "Empty List";

            string spreaded = "[ ";
            LinkedListNode<T> now = head;

            for (int i = 0; i < count; i++)
            {
                spreaded += now.ITEM + ", ";
                now = now.NEXT;
            }

            return spreaded + "]";
        }
    }
}
