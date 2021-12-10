using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ChangingObject
{
    public object Object;
    
    public T Get<T>()
    {
        return (T)Object;
    }

    public void Set<T>(T obj)
    {
        Object = obj;
    }
}
