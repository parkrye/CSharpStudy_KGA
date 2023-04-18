using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Homerwork_01
{
    internal class List<T>
    {
        T[] items;
        int size;
        const int defaultCapacity = 10;

        public T this[int index]
        {
            get 
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException();
                return items[index]; 
            }
            set
            {
                if (index < 0 || index >= items.Length)
                    throw new IndexOutOfRangeException(); 
                items[index] = value; 
            }
        }

        public int Capacity
        {
            get { return items.Length; }
        }

        public int Count
        {
            get { return size; }
        }

        /// <summary>
        /// 리스트를 초기화하는 기본적인 생성자
        /// </summary>
        public List()
        {
            size = 0;
            items = new T[defaultCapacity];
        }

        /// <summary>
        /// 지정된 컬렉션의 요소를 복사하여 리스트를 초기화하는 생성자
        /// </summary>
        /// <param name="collection">컬렉션</param>
        public List(IEnumerable<T> collection)
        {
            size = 0;
            items = new T[defaultCapacity];
            AddRange(collection.ToArray());
        }

        /// <summary>
        /// 요소를 리스트의 끝부분에 추가하는 함수
        /// </summary>
        /// <param name="add">추가할 요소</param>
        public void Add(T add)
        {
            if (size == Capacity)
                Grow();
            items[size++] = add;
        }

        /// <summary>
        /// 하나 이상의 요소를 리스트의 끝부분에 추가하는 함수
        /// </summary>
        /// <param name="adds">추가할 요소들</param>
        public void AddRange(params T[] adds)
        {
            foreach(T add in adds)
                Add(add);
        }

        /// <summary>
        /// 리스트의 요소를 모두 제거하는 함수
        /// </summary>
        public void Clear()
        {
            size = 0;
            items = new T[defaultCapacity];
        }

        /// <summary>
        /// 리스트에서 요소의 존재 여부를 반환하는 함수
        /// </summary>
        /// <param name="item">확인할 요소</param>
        /// <returns>요소가 리스트에 존재하는지 여부</returns>
        public bool Contains(T item)
        {
            return items.Contains(item);
        }

        /// <summary>
        /// 다른 형식으로 변환한 리스트를 반환하는 함수
        /// </summary>
        /// <typeparam name="TOutput">변환시킬 형식</typeparam>
        /// <param name="converter">각 요소의 형식을 변환시키는 델리게이트</param>
        /// <returns>각 요소의 형식을 변환한 리스트</returns>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public List<TOutput> ConvertAll<TOutput>(Converter<T, TOutput> converter)
        {
            if (converter == null)
                throw new ArgumentNullException("converter");
            List<TOutput> converted = new List<TOutput>();
            for(int i = 0; i < size; i++)
            {
                converted.Add(converter(items[i]));
            }
            return converted;
        }

        /// <summary>
        /// 대상 배열에 리스트의 요소들을 복사하는 함수
        /// </summary>
        /// <param name="array">리스트를 복사할 배열</param>
        public void CopyTo(T[] array)
        {
            Array.Copy(items, array, size);
        }

        /// <summary>
        /// 대상 배열의 특정 위치에 리스트의 특정 위치의 요소들을 복사하는 함수
        /// </summary>
        /// <param name="index">리스트에서 복사할 위치</param>
        /// <param name="array">리스트를 복사할 배열</param>
        /// <param name="arrayIndex">복사한 값을 저장할 배열의 위치</param>
        /// <param name="count">복사할 값의 개수</param>
        public void CopyTo(int index, T[] array, int arrayIndex, int count)
        {
            Array.Copy(items, index, array, size, arrayIndex + count);
        }

        /// <summary>
        /// 용량이 지정된 값 이상이 될 때까지 용량을 증가시키는 함수
        /// </summary>
        /// <param name="capacity">용량의 하한값</param>
        /// <returns>증가된 용량</returns>
        public int EnsureCapacity(int capacity)
        {
            while(items.Length < capacity)
            {
                Grow();
            }
            return items.Length;
        }

        /// <summary>
        /// 리스트에서 지정된 조건과 일치하는 요소의 존재 여부를 반환하는 함수
        /// </summary>
        /// <param name="match">조건자</param>
        /// <returns>조건이 일치하는 요소의 존재 여부</returns>
        /// <exception cref="ArgumentNullException">조건자가 null일 경우</exception>
        public bool Exist(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            foreach (T item in items)
                if (match(item))
                    return true;
            return false;
        }

        /// <summary>
        /// 리스트에서 지정된 조건과 일치하는 요소를 반환하는 함수
        /// </summary>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <returns>조건이 일치하는 요소. 없을 경우 디폴트 값을 반환</returns>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public T? Find(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            foreach (T item in items)
                if (match(item))
                    return item;
            return default(T);
        }        
        
        /// <summary>
        /// 리스트에서 지정된 조건과 일치하는 요소들을 포함하는 리스트를 반환하는 함수
        /// </summary>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <returns>조건이 일치하는 요소 리스트. 없을 경우 빈 리스트를 반환</returns>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public List<T>? FindAll(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            List<T> found = new List<T>();
            foreach (T item in items)
                if (match(item))
                    found.Add(item);
            return found;
        }

        /// <summary>
        /// 리스트에서 지정된 조건과 일치하는 요소의 위치를 반환하는 함수
        /// </summary>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <returns>조건이 일치하는 요소의 위치. 없을 경우 -1 반환</returns>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public int FindIndex(Predicate<T> match)
        {
            return FindIndex(0, match);
        }

        /// <summary>
        /// 리스트에서 지정된 인덱스부터 지정된 조건과 일치하는 요소의 위치를 반환하는 함수
        /// </summary>
        /// <param name="startIndex">조건을 검색하기 시작할 위치</param>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <returns>조건이 일치하는 요소의 위치. 없을 경우 -1 반환</returns>
        /// <exception cref="IndexOutOfRangeException">지정한 위치가 범위를 벗어나면 발생</exception>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public int FindIndex(int startIndex, Predicate<T> match)
        {
            return FindIndex(startIndex, size - startIndex, match);
        }

        /// <summary>
        /// 리스트에서 지정된 인덱스부터 지정된 횟수까지 지정된 조건과 일치하는 요소의 위치를 반환하는 함수
        /// </summary>
        /// <param name="startIndex">조건을 검색하기 시작할 위치</param>
        /// <param name="count">탐색할 횟수</param>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <returns></returns>
        /// <exception cref="IndexOutOfRangeException">지정한 위치가 범위를 벗어나면 발생</exception>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public int FindIndex(int startIndex, int count, Predicate<T> match)
        {
            if (startIndex < 0 || startIndex >= size || startIndex + count < 0 || startIndex + count >= size)
                throw new IndexOutOfRangeException();
            if (match == null)
                throw new ArgumentNullException("match");
            for (int i = startIndex; i < startIndex + count; i++)
                if (match(items[i]))
                    return i;
            return -1;
        }

        /// <summary>
        /// 리스트를 확장시키는 함수
        /// </summary>
        void Grow()
        {
            T[] newItems = new T[items.Length * 2];
            Array.Copy(items, newItems, size);
            items = newItems;
        }

        /// <summary>
        /// 지정된 요소를 검색하고 그 위치를 반환하는 함수
        /// </summary>
        /// <param name="item">검색할 요소</param>
        /// <returns>요소의 위치. 없을 경우 -1 반환</returns>
        public int IndexOf(T item)
        {
            return IndexOf(item, 0);
        }

        /// <summary>
        /// 지정된 요소를 지정된 위치부터 검색하고 그 위치를 반환하는 함수
        /// </summary>
        /// <param name="item">검색할 요소</param>
        /// <param name="index">지정할 위치</param>
        /// <returns>요소의 위치. 없을 경우 -1 반환</returns>
        public int IndexOf(T item, int index)
        {
            return IndexOf(item, index, size);
        }

        /// <summary>
        /// 지정된 요소를 지정된 위치부터 일정 횟수 검색하고 그 위치를 반환하는 함수
        /// </summary>
        /// <param name="item">검색할 요소</param>
        /// <param name="index">지정할 위치</param>
        /// <param name="count">지정한 횟수</param>
        /// <returns>요소의 위치. 없을 경우 -1 반환</returns>
        /// <exception cref="IndexOutOfRangeException">지정된 위치가 범위를 벗어나면 발생</exception>
        public int IndexOf(T item, int index, int count)
        {
            if (index < 0 || index >= size || index + count < 0 || index + count >= size)
                throw new IndexOutOfRangeException();
            for (int i = index; i < index + count; i++)
            {
                if ((items[i].Equals(item)))
                {
                    return i;
                }
            }
            return -1;
        }

        /// <summary>
        /// 지정된 요소를 삭제하는 함수
        /// </summary>
        /// <param name="item">삭제할 요소</param>
        /// <exception cref="ArgumentException">존재하지 않는 요소를 삭제할 경우 발생</exception>
        public void Remove(T item)
        {
            int index = IndexOf(item);
            if (index < 0 || index >= size)
                throw new ArgumentException();
            size--;
            Array.Copy(items, index + 1, items, index, size - index);
        }

        /// <summary>
        /// 조건이 일치하는 요소를 전부 삭제하는 함수
        /// </summary>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public void RemoveAll(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            foreach (T item in items)
                if (match(item))
                    Remove(item);
        }

        /// <summary>
        /// 리스트의 특정 위치의 요소를 삭제하는 함수
        /// </summary>
        /// <param name="index">삭제할 위치</param>
        /// <exception cref="IndexOutOfRangeException">지정한 위치가 범위를 벗어나면 발생</exception>
        public void Remove(int index)
        {
            RemoveRange(index, 1);
        }

        /// <summary>
        /// 지정한 위치로부터 지정환 횟수만큼 요소를 삭제하는 함수
        /// </summary>
        /// <param name="startIndex">삭제할 위치</param>
        /// <param name="count">삭제할 횟수</param>
        /// <exception cref="IndexOutOfRangeException">삭제할 위치가 범위를 벗어나면 발생</exception>
        public void RemoveRange(int startIndex, int count)
        {
            if (startIndex < 0 || startIndex >= size || startIndex + count < 0 || startIndex + count >= size)
                throw new IndexOutOfRangeException();
            for (int i = startIndex; i < startIndex + count; i++)
            {
                size--;
                Array.Copy(items, i + 1, items, i, size - i);
            }
        }

        /// <summary>
        /// 리스트를 거꾸로 뒤집는 함수
        /// </summary>
        public void Reverse()
        {
            Array.Reverse(items);
        }
        
        /// <summary>
        /// 지정한 위치부터 지정한 길이의 요소를 뒤집는 함수
        /// </summary>
        /// <param name="index">뒤집기 시작할 위치</param>
        /// <param name="length">뒤집을 위치까지의 길이</param>
        /// <exception cref="IndexOutOfRangeException">뒤집을 위치가 범위를 벗어나면 발생</exception>
        public void Reverse(int index, int length)
        {
            if (index < 0 || index >= size || index + length < 0 || index + length >= size)
                throw new IndexOutOfRangeException();
            Array.Reverse(items, index, length);
        }

        /// <summary>
        /// 리스트를 오름차순으로 정렬하는 함수
        /// </summary>
        public void Sort()
        {
            Sort(null);
        }

        /// <summary>
        /// 지정된 비교자를 사용하여 리스트를 정렬하는 함수
        /// </summary>
        /// <param name="comparer">요소를 비교할 비교자. 기본 비교자를 사용할 경우 null 입력</param>
        public void Sort(Comparer<T> comparer)
        {
            Sort(0, size, comparer);
        }

        /// <summary>
        /// 지정한 범위의 요소를 지정한 비교자를 사용하여 정렬하는 함수
        /// </summary>
        /// <param name="index">정렬할 위치</param>
        /// <param name="length">정렬할 길이</param>
        /// <param name="comparer">요소를 비교할 비교자. 기본 비교자를 사용할 경우 null 입력</param>
        /// <exception cref="IndexOutOfRangeException">정렬 범위가 리스트 범위를 벗어날 경우 발생</exception>
        public void Sort(int index, int length, Comparer<T> comparer)
        {
            if (index < 0 || index >= size || index + length < 0 || index + length >= size)
                throw new IndexOutOfRangeException();
            Array.Sort(items, index, length, comparer);
        }

        /// <summary>
        /// 리스트를 배열로 반환하는 함수
        /// </summary>
        /// <returns>리스트를 변환시킨 배열</returns>
        public T[] ToArray()
        {
            return items.ToArray();
        }

        /// <summary>
        /// 리스트에 있는 요소의 수가 용량보다 작을 때 용량을 요소 수로 설정하는 함수
        /// </summary>
        public void TrimExcess()
        {
            if(size < items.Length)
            {
                T[] newItems = new T[size];
                Array.Copy(items, newItems, size);
                items = newItems;
            }
        }

        /// <summary>
        /// 리스트의 모든 요소가 지정된 조건자에 정의된 조건과 일치하는지 여부를 반환하는 함수
        /// </summary>
        /// <param name="match">조건을 정의하는 델리게이트</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">델리게이트가 null일 경우 발생</exception>
        public bool TrueForAll(Predicate<T> match)
        {
            if (match == null)
                throw new ArgumentNullException("match");
            foreach (T item in items)
                if (!match(item))
                    return false;
            return true;
        }
    }
}
