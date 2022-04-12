using System;

public struct UnsetBool : IEquatable<bool>, IEquatable<UnsetBool>
{
    public UnsetBoolValue value;

    public UnsetBool(bool value)
    {
        this.value = value ? UnsetBoolValue.True : UnsetBoolValue.False;
    }

    public UnsetBool(UnsetBoolValue value)
    {
        this.value = value;
    }

    public byte ByteValue { get => (byte)value; }

    public bool IsUnset() => value == UnsetBoolValue.Unset;

    public bool IsTrue() => value == UnsetBoolValue.True;

    public bool IsFalse() => value == UnsetBoolValue.False;

    public static implicit operator bool(UnsetBool ub) => ub.value == UnsetBoolValue.True;

    public static implicit operator UnsetBool(bool b) => new UnsetBool(b);

    public static implicit operator byte(UnsetBool ub) => (byte)ub.value;

    public static implicit operator UnsetBool(byte b)
    {
        if (b == 0)
        {
            return False;
        }
        if (b == 1)
        {
            return True;
        }
        if (b == 2)
        {
            return Unset;
        }
        return Unset;
    }

    public static implicit operator UnsetBool(UnsetBoolValue ubv) => new UnsetBool(ubv);

    public static bool operator ==(UnsetBool ub1, UnsetBool ub2) => ub1.value == ub2.value;

    public static bool operator !=(UnsetBool ub1, UnsetBool ub2) => ub1.value != ub2.value;

    public override string ToString()
    {
        switch (value)
        {
            case UnsetBoolValue.Unset:
                return "Unset";
    
            case UnsetBoolValue.False:
                return "False";
 
            case UnsetBoolValue.True:
                return "True";
   
            default:
                return "Undefined";
        }
    }

    public bool Equals(bool other)
    {
        if (other)
        {
            return value == UnsetBoolValue.True;
        }
        else
        {
            return value == UnsetBoolValue.False || value == UnsetBoolValue.Unset;
        }
    }

    public bool Equals(UnsetBool other)
    {
        return this.value == other.value;
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static UnsetBool True = new UnsetBool(true);
    public static UnsetBool False = new UnsetBool(false);
    public static UnsetBool Unset = new UnsetBool(UnsetBoolValue.Unset);
}

public enum UnsetBoolValue : byte
{
    Unset = 2,
    False = 0,
    True = 1
}
