using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultedList<T> : List<T>
{
    public T defaultObject;

    public DefaultedList(T defaultObject, int capacity)
    {
        this.defaultObject = defaultObject;
        
    }

    public DefaultedList(IList<T> collection, T defaultObject)
    {

    }

    public void SetDefault(int index)
    {

    }
}
