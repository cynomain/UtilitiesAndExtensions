using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
/// <summary>
/// Data list that can be scrolled through
/// </summary>
/// <typeparam name="T"></typeparam>
public class DataBuffer<T>
{
    /// <summary>
    /// List of items in buffer
    /// </summary>
    public List<T> buffer;

    /// <summary>
    /// Current item in buffer
    /// </summary>
    public T CurrentItem { get { return buffer[CurrentIndex]; } }

    /// <summary>
    /// Current item index
    /// </summary>
    public int CurrentIndex;

    /// <summary>
    /// Cycles current item forward
    /// </summary>
    public virtual void CycleForward()
    {
        int nextInd = CurrentIndex + 1;
        if (nextInd >= buffer.Count)
        {
            CurrentIndex = 0;
        }
        else
        {
            CurrentIndex = nextInd;
        }
    }

    /// <summary>
    /// Cycles current item backward
    /// </summary>
    public virtual void CycleBackward()
    {
        int nextInd = CurrentIndex - 1;
        if (nextInd < 0)
        {
            CurrentIndex = buffer.Count - 1;
        }
        else
        {
            CurrentIndex = nextInd;
        }
    }

    /// <summary>
    /// Cycles current item forward
    /// </summary>
    /// <param name="times">How many times</param>
    public virtual void CycleForward(int times)
    {
        for (int i = 0; i < times; i++)
        {
            CycleForward();
        }
    }

    /// <summary>
    /// Cycles current item backward
    /// </summary>
    /// <param name="times">How many times</param>
    public virtual void CycleBackward(int times)
    {
        for (int i = 0; i < times; i++)
        {
            CycleBackward();
        }
    }
    
    /// <summary>
    /// Access an item in buffer
    /// </summary>
    /// <param name="index"></param>
    /// <returns></returns>
    public virtual T this[int index]
    {
        get { return buffer[index]; }
        set { buffer[index] = value; }
    }

    public DataBuffer(IList<T> items)
    {
        buffer = new List<T>(items);
        CurrentIndex = 0;
    }

    public DataBuffer(IList<T> items, int startIndex)
    {
        buffer = new List<T>(items);
        CurrentIndex = startIndex;
    }

    public DataBuffer()
    {
        buffer = new List<T>();
        CurrentIndex = 0;
    }

    /// <summary>
    /// Checks if index is overflow and corrects it
    /// </summary>
    public virtual void IndexCheck()
    {
        if (CurrentIndex >= buffer.Count)
        {
            //Overflow too much
            CurrentIndex = 0;
        }
        else
        {
            if (CurrentIndex < 0)
            {
                //Overflow negative
                CurrentIndex = buffer.Count - 1;
            }
        }
    }

    /// <summary>
    /// Checks if index is overflow
    /// </summary>
    public virtual bool IndexCheck(int index)
    {
        /*
        if (index >= buffer.Count)
        {
            //Overflow too much
            return false;
        }
        else
        {
            if (index < 0)
            {
                //Overflow negative
                return false;
            }
            return true;
        }
        return true;
        */
        return index < buffer.Count && index > 0; //index is not overflow, index is not negative
    }

    /// <summary>
    /// Converts buffer to array
    /// </summary>
    public virtual T[] ToArray()
    {
        return buffer.ToArray();
    }

    public bool Equals(T other)
    {
        return other.Equals(CurrentItem);
    }

    public static implicit operator T[](DataBuffer<T> db) => db.ToArray();
    public static implicit operator DataBuffer<T>(T[] arr) => new DataBuffer<T>(arr);

    public static implicit operator List<T>(DataBuffer<T> db) => db.buffer;
    public static implicit operator DataBuffer<T>(List<T> l) => new DataBuffer<T>(l);

}

/// <summary>
/// Data list of enum values
/// </summary>
/// <typeparam name="T"></typeparam>
public class EnumDataBuffer<T> : DataBuffer<string>    where T : System.Enum 
{
    public EnumDataBuffer()
    {
        string[] enumNames = System.Enum.GetNames(typeof(T));
        this.buffer = enumNames.ToList();
        this.CurrentIndex = 0;
        this.IndexCheck();
    } 
    
    public EnumDataBuffer(int defaultIndex)
    {
        string[] enumNames = System.Enum.GetNames(typeof(T));
        this.buffer = enumNames.ToList();
        this.CurrentIndex = defaultIndex;
        this.IndexCheck();
    }

    /// <summary>
    /// Current enum as string in buffer
    /// </summary>
    public string CurrentItemRaw { get { return buffer[CurrentIndex]; } }

    /// <summary>
    /// Current enum in buffer
    /// </summary>
    public new T CurrentItem { get { return buffer[CurrentIndex].ToEnum<T>(); } } 

    public static implicit operator T(EnumDataBuffer<T> edb) => edb.CurrentItem;
}

