using UnityEngine;
using System.Collections.Generic;

//忘了原来的设计了，不重复造轮子了. 用这个不能即时删除 Object 了
public class LuaObjectMap
{    
    private List<object> list;
    private Stack<int> pool;

    public LuaObjectMap()
    {
        list = new List<object>(1024);
        pool = new Stack<int>(1024);
    }

    public object this[int i]
    {
        get 
        {
            return list[i]; 
        }

        set
        {
            if (list[i] != null)
            {
                list[i] = value;
            }
        }
    }

    public int Add(object obj)
    {
        int index = -1;

        if (pool.Count > 0)
        {
            index = pool.Pop();
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

    public void Remove(int index)
    {
        if (index >= 0 && index < list.Count)
        {
            object o = list[index];

            if (o != null)
            {
                pool.Push(index);
            }

            list[index] = null;            
        }        
    }
}
