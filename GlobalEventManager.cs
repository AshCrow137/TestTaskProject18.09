using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager 
{
    public static UnityEvent FinishEvent = new UnityEvent();
    public static UnityEvent StartEvent = new UnityEvent();
    public static UnityEvent<int> PickUpEvent = new UnityEvent<int>();
    public static void InvokeFinishEvent()
    {
        FinishEvent.Invoke();
    }
    public static void InvokeStartEvent()
    {  
        StartEvent.Invoke();
    }
    public static void InvokePickUpEvent(int value)
    {
        PickUpEvent.Invoke(value);
    }

}
