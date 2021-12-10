using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/*
 *
 *                  UNUSABLE
 *
 */
[System.Serializable]
public struct Fraction
{
    //Private
    private int _whole;
    private int _numer;
    private int _denom;

    //Public
    public int WholeNumber { get => _whole; set => _whole = value; }
    public int Numerator { get => _numer; set => _numer = value; }
    public int Denominator { get => _denom; set => _denom = value; }

    public float Percent { get => GetPercent(); }

    public bool IsProper { get => _whole == 0 && _numer <= _denom; }
    public bool IsImproper { get => !IsProper; }
    public bool IsMixed { get => _whole != 0; }

    public Fraction Simplified { get {
            /*
            int gcd = Utilities.GCD(_numer, _denom);
            return new Fraction(this._whole, this._numer / gcd, this._denom / gcd);
            */
            return GetSimplified();
        } }

    public Fraction(int Whole, int Num, int Denom)
    {
        if (Denom == 0)
        {
            throw new System.ArgumentException("Denominator can't be zero", nameof(Denom));
        }
        this._whole = Whole;
        this._numer = Num;
        this._denom = Denom;
    }

    public Fraction(int Num, int Denom)
    {
        this._whole = 0;
        this._numer = Num;
        this._denom = Denom;
    }

    /*
    public Fraction(float Decimal)
    {
        Fraction f = Decimal.ToFraction();
        _numer = f._numer;
        _denom = f._denom;
        _whole = f._whole;
    }
    */

    public void Set(Fraction f)
    {
        _numer = f._numer;
        _denom = f._denom;
        _whole = f._whole;
    }

    public float GetPercent()
    {
        if (_numer == 0 || _denom == 0)
        {
            Debug.LogErrorFormat("Undefined Operation : {0}+({1}/{2})", _whole, _numer, _denom);
            return float.NaN;
        }
        return _whole + (_numer / _denom); //0 + 1/2 = 1/2(.5)   1 + 3/4 = 1,75
    }    

    public void Simplify()
    {
        Fraction f = GetSimplified();
        _numer = f._numer;
        _denom = f._denom;
    }

    private Fraction GetSimplified()
    {
        int gcd = Utilities.GCD(_numer, _denom);
        _numer /= gcd;
        _denom /= gcd;

        if (IsMixed)
        {
            //2 5/2

        }

        return new Fraction(
            this._numer / gcd,
            this._denom /gcd
            );
    }

    /*
    //1,25 => 125/100  ||   .Simplified => 5/4   || ToMixed().Simplified => 1 1/4
    public Fraction ToFraction(float f)
    {
        return f.ToFraction();
    }
    */
    #region ToMixedAndBack

    //125/100 => 1 25/100
    public Fraction ToMixedFraction()
    {
        if (IsImproper)
        {
            //IsImproper

            //3/2 . 3%2 = 1 . 
            int excessNum = (_numer % _denom);
            int tempWhole = (_numer - excessNum)/_denom;

            return new Fraction(tempWhole, excessNum, _denom);  //2 5/2 = 4 1/2
        }
        return this;
    }

    //1 25/100 => 125/100
    public Fraction ToImproperFraction()
    {
        int tempNum = _whole * _denom;
        return new Fraction(_numer + tempNum, _denom);
    }

    #endregion

    //Improper  1,25 => 125/100

    public static implicit operator float(Fraction f) => f.Percent;
    //public static implicit operator Fraction(float f) => f.ToFraction().ToImproperFraction().Simplified;

    public override string ToString()
    {
        if (!IsMixed)
        {
            return string.Format("({0}/{1})", _numer, _denom);
        }
        else
        {
            return string.Format("{0}({1}/{2})", _whole, _numer, _denom);
        }
    }

    public override bool Equals(object obj)
    {
        if (obj.GetType() == this.GetType())
        {
            //Same type
            Fraction f = (Fraction)obj;
            return Numerator == f.Numerator && Denominator == f.Denominator && WholeNumber == f.WholeNumber;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        Fraction aIm = a.ToImproperFraction();
        Fraction bIm = b.ToImproperFraction();
        Fraction res = new Fraction(aIm.Numerator * bIm.Denominator, aIm.Denominator * bIm.Denominator);
        if (a.IsMixed && b.IsMixed)
        {
            //Both is mixed
            return res.ToMixedFraction().GetSimplified();
        };
        return res.GetSimplified();
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        Fraction aIm = a.ToImproperFraction();
        Fraction bIm = b.ToImproperFraction();
        Fraction res = new Fraction(aIm.Numerator / bIm.Denominator, aIm.Denominator / bIm.Denominator);
        if (a.IsMixed && b.IsMixed)
        {
            //Both is mixed
            return res.ToMixedFraction().GetSimplified();
        };
        return res.GetSimplified();
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        Fraction aIm = a.ToImproperFraction();
        Fraction bIm = b.ToImproperFraction();
        Fraction res = new Fraction(aIm.Numerator * bIm.Denominator, aIm.Denominator * bIm.Denominator);
        if (a.IsMixed && b.IsMixed)
        {
            //Both is mixed
            return res.ToMixedFraction().GetSimplified();
        };
        return res.GetSimplified();
    }
}


