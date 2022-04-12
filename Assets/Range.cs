using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CynoMain 
{
    public struct RangeInt : IEquatable<int>
    {
        public int Begin;
        public int End;

        public RangeInt(int begin, int end)
        {
            this.Begin = begin;
            this.End = end;
        }

        public bool Equals(int other)
        {
            return IsBetweenOrEqual(other);
        }

        public bool IsBetween(int number)
        {
            return number > Begin && number < End;
        }

        public bool IsBetweenOrEqual(int number)
        {
            return number >= Begin && number <= End;
        }

        public override bool Equals(object obj)
        {
            if (obj.GetType() == typeof(int))
            {
                return Equals((int)obj);
            }
            else if (obj.GetType() == typeof(float))
            {
                return Equals((int)obj);
            }
            else
            {
                return false;
            }
        }

        public override int GetHashCode()
        {
            return this.Begin.GetHashCode() * 17 + this.End.GetHashCode();
        }

        public override string ToString()
        {
            return $"[{Begin}, {End}]";
        }
    }
}