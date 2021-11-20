using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

[System.Serializable]
public struct Percentage
{
    /// <summary>
    /// Percent per 100
    /// </summary>
    public float Percent;
    /// <summary>
    /// Percent if 100 is 1 (example : 0.2 = 20%)
    /// </summary>
    public float Value { get => Percent / 100; }

    #region ctor
    public Percentage(float f)
    {
        Percent = f;
    }

    public Percentage(int i)
    {
        Percent = i;
    }
    #endregion    

    /// <summary>
    /// Returns Percent percentage of float
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public float PercentageOf(float f)
    {
        return f * Value;
    }

    public static implicit operator float(Percentage p) => p.Value;
    public static implicit operator Percentage(float f) => ToPercentage(f);

    //Percentage
    /// <summary>
    /// Returns a new percentage based on Float
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Percentage ToPercentage(float f)
    {
        return new Percentage(f * 100);
    }

    #region Operators
    public static Percentage operator +(Percentage a, Percentage b)
    {
        return new Percentage(a.Percent + b.Percent);
    }

    public static Percentage operator -(Percentage a, Percentage b)
    {
        return new Percentage(a.Percent - b.Percent);
    }

    public static Percentage operator *(Percentage a, Percentage b)
    {
        return new Percentage(a.Percent * b.Percent);
    }

    public static Percentage operator /(Percentage a, Percentage b)
    {
        return new Percentage(a.Percent / b.Percent);
    }

    public static bool operator ==(Percentage a, Percentage b)
    {
        return a.Percent == b.Percent;
    }

    public static bool operator !=(Percentage a, Percentage b)
    {
        return a.Percent != b.Percent;
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == this.GetType())
        {
            return ((Percentage)obj).Percent == this.Percent;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override string ToString()
    {
        return $"{Percent}%";
    }

    public static Percentage StringToPercent(string str)
    {
        if (str.EndsWith("%"))
        {
            //Valid
            try
            {
                string numinstr = str.Replace("%",string.Empty);
                float value = float.Parse(numinstr);
                return new Percentage(value);
            }
            catch (System.Exception)
            {
                Debug.LogError("Can't convert string to percentage");
                throw;
            }
        }
        else
        {
            throw new System.InvalidCastException("String not formatted as a percentage. (Must end with %)");
        }
    }


    #endregion
}