using UnityEngine;
using System.Collections.Generic;

//查询，添加都比较快速。 Remove 较少，按照二分查找插入pool中
public class LuaObjectMap
{
    public class FastQueue
    {
        private List<int> pool;

        public FastQueue()
        {
            pool = new List<int>();
        }

        //lua 端destroy object 会gc
        //lua不会主动gc,设想在切场景时候手动调用lua gc函数
        //push 会在切换场景时大量调用，快慢影响不大
        //不是说次函数效率不高
        public void Push(int item)
        {
            if (pool.Count == 0)
            {
                pool.Add(item);
            }
            else if (item > pool[0])
            {
                pool.Insert(0, item);
            }
            else if (item < pool[pool.Count - 1])
            {
                pool.Add(item);
            }
            else if (item == pool[0] || item == pool[pool.Count - 1])
            {
                return;
            }
            else
            {
                int pos = FindPos(0, pool.Count - 1, item);

                if (pos != -1)
                {
                    pool.Insert(pos, item);
                }
            }
        }

        int FindPos(int l, int r, int val)
        {
            if (l == r - 1)
            {
                return r;
            }

            int pos = (r + 1 - l) / 2 + l;
            int pivot = pool[pos];

            if (pivot < val)
            {
                r = pos;
                return FindPos(l, r, val);
            }
            else if (pivot > val)
            {
                l = pos;
                return FindPos(l, r, val);
            }
            else
            {
                return -1;
            }
        }

        //重复使用list列表空位，避免链表变大
        public int Pop()
        {
            int index = -1;

            if (pool.Count > 0)
            {
                index = pool[pool.Count - 1];
                pool.RemoveAt(pool.Count - 1);
            }

            return index;
        }

        //public void Print()
        //{
        //    StringBuilder sb = new StringBuilder();
        //    int temp = pool[0];
        //    sb.Append(pool[0]);

        //    for (int i = 1; i < pool.Count - 1; i++)
        //    {
        //        sb.Append(" ");
        //        sb.Append(pool[i]);

        //        if (pool[i] >= temp)
        //        {
        //            Debugger.LogError("error ");
        //        }

        //        temp = pool[i];
        //    }

        //    Debugger.Log(sb.ToString());
        //}
    }

    //此表不能Remove
    private List<object> list;
    private FastQueue pool;

    public LuaObjectMap()
    {
        list = new List<object>();
        pool = new FastQueue();
    }

    public object this[int i]
    {
        get { return list[i]; }
        set { list[i] = value; }
    }

    public int Add(object obj)
    {
        int index = pool.Pop();

        if (index >= 0)
        {
            list[index] = obj;
        }
        else
        {
            list.Add(obj);
            index = list.Count - 1;
        }

        return index;
    }

    public bool TryGetValue(int index, out object obj)
    {
        if (index >= 0 && index <list.Count)
        {
            obj = list[index];
            return true;
        }

        obj = null;
        return false;
    }

    public void Remove(int index)
    {
        if (index >= 0 && index < list.Count)
        {
            list[index] = null;
            pool.Push(index);
        }
    }
}
