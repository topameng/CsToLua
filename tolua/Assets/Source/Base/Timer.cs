using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer:MonoBehaviour
{
    public static Timer Instance
    {
        get;
        private set;
    }

    protected class TimerProc
    {
        public float duration;
        public float time;
        public int loop = -1;
        //后面加上是否受timescale影响
        public bool beScale = true;
        public Action Call = delegate { };

        public void SubTime(float deltaTime, float noScaleTime)
        {
            float t = beScale ? deltaTime : noScaleTime;
            this.time -= t;
        }
    }

    List<TimerProc> list = null;        

    public void Awake()
    {
        Instance = this;
        list = new List<TimerProc>();                
    }

    public void OnDestroy()
    {
        Instance = null;
        list.Clear();
    }

    public object AddTimer(float duration, int loop, Action call, bool beScale)
    {
        TimerProc proc = new TimerProc();
        proc.duration = duration;
        proc.time = duration;
        proc.loop = loop;
        proc.Call = call;
        proc.beScale = beScale;
        list.Add(proc);

        return proc;
    }

    public object AddTimer(float duration, int loop, Action call)
    {
        return AddTimer(duration, loop, call, false);
    }

    public void Yield(int frame, Action action)
    {
        StartCoroutine(YieldByFrame(frame, action));
    }

    IEnumerator YieldByFrame(int frame, Action call)
    {
        while (frame > 0)
        {
            yield return null;
            --frame;
        }

        call();
    }

    public void WaitEndOfFrame(Action action)
    {
        StartCoroutine(CoWaitEndFrame(action));
    }

    IEnumerator CoWaitEndFrame(Action action)
    {
        yield return new WaitForEndOfFrame();
        action();
    }

    public void ResetTimer(object timer, float duration, int loop, Action call, bool beScale)
    {
        TimerProc proc = timer as TimerProc;
        proc.duration = duration;
        proc.time = duration;
        proc.loop = loop;
        proc.Call = call;
        proc.beScale = beScale;

        if (!list.Contains(proc))
        {
            list.Add(proc);
        }        
    }

    public void StopTimer(object proc)
    {
        TimerProc tp = proc as TimerProc;
        list.Remove(tp);
    }

    public void OnUpdate(float deltaTime)
    {
        float fixTime = deltaTime / Time.timeScale;

        for (int i = 0; i < list.Count; i++)
        {
            TimerProc proc = list[i];
            proc.SubTime(deltaTime, fixTime);

            if (proc.time <= 0)
            {
                try
                {
                    proc.Call();
                }
                catch(Exception e)
                {
                    list.RemoveAt(i);
                    //Debugger.threadStack = e.StackTrace;
                    Debugger.LogError("timer call exception: {0}", e.Message);
                    continue;
                }
                

                if (proc.loop > 0)
                {
                    --proc.loop;
                    proc.time += proc.duration;
                }

                if (proc.loop == 0)
                {
                    list.RemoveAt(i--);
                }
                else if (proc.loop < 0)
                {
                    proc.time += proc.duration;
                }
            }
        }
    }
}
