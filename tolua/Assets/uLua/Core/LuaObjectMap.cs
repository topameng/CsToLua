using UnityEngine;
using System.Collections.Generic;

//忘了原来的设计了，还是用系统的吧
public class LuaObjectMap
{    
    private List<object> list;
    private Queue<int> pool;

    public LuaObjectMap()
    {
        list = new List<object>(1024);
        pool = new Queue<int>(1024);
    }

    public object this[int i]
    {
        get { return list[i]; }        
    }

    public int Add(object obj)
    {
        int index = -1;

        if (pool.Count > 0)
        {
            index = pool.Dequeue();
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
        if (index >= 0 && index < list.Count)
        {
            obj = list[index];
            return obj != null;
        }

        obj = null;
        return false;
    }

    public object Remove(int index)
    {
        if (index >= 0 && index < list.Count)
        {
            object o = list[index];

            if (o != null)
            {
                pool.Enqueue(index);
            }

            list[index] = null;

            return o;
        }

        return null;
    }
}
