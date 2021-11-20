﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

//V1
/*
 * Contains : Shuffle, AltToList, AltIListToString(), IsOdd & IsEven, RandomElement, IsBetween, ToEnum, IsNegative&Positive&Zero, ToFraction
*/
/// <summary>
/// Class of extensions
/// </summary>
public static class Extensions
{
    #region Unused
    /*
    /// <summary>
    /// Shuffles this collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="col"></param>
    public static void Shuffle<T>(this IList<T> col)
    {
        
        List<T> temp = new List<T>(col);
        List<T> temp2 = new List<T>();
        for (int i = 0; i < temp.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, temp.Count);
            temp2.Add(temp[rand]);
            temp.RemoveAt(rand);
        }
        //col = temp2;
        for (int i = 0; i < temp2.Count; i++)
        {
            col[i] = temp2[i];
        }
        //return temp2;
        

    }
    */
    #endregion



    #region UNUED FRACTION
    /*
    //Fraction
    /// <summary>
    /// Converts Float to Improper Unsimplified Fraction
    /// </summary>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Fraction ToFraction(this float f)
    {
        if (f % 1 == 0)
        {
            //IsWhole
            return new Fraction((int)f, 1);
        }

        int pow = 1;
        int ten = 10;
        while ((f * Mathf.Pow(ten, pow) % 1) != 0) //1,25 * 10^1 = 12,5 % 1 = .5
        {
            pow++;
        }
        return new Fraction(
            (int)(f * Mathf.Pow(ten, pow)), //1,25 * 10^2 = 1,25 * 100 = 125
            (int)Mathf.Pow(ten, pow) //pow:2    10^2 = 100
            );
    }
    */
    #endregion
}

/// <summary>
/// Class of extensions : Numeric
/// </summary>
public static class ExtensionsNumeric
{
    /// <summary>
    /// Returns true if Int is odd
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsOdd(this int i) => (i % 2) != 0;

    /// <summary>
    /// Returns true if Int is Even
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsEven(this int i) => (i % 2) == 0;

    /// <summary>
    /// Returns true if Float is odd
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsOdd(this float i) => (i % 2) != 0;

    /// <summary>
    /// Returns true if Float is Even
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsEven(this float i) => (i % 2) == 0;

    /// <summary>
    /// Returns true if Int is between two numbers
    /// </summary>
    /// <param name="i"></param>
    /// <param name="first">First number</param>
    /// <param name="second">Second number</param>
    /// <returns></returns>
    public static bool IsBetween(this int i, int first, int second) => (i >= first && i <= second);

    /// <summary>
    /// Returns true if Float is between two numbers
    /// </summary>
    /// <param name="i"></param>
    /// <param name="first">First number</param>
    /// <param name="second">Second number</param>
    /// <returns></returns>
    public static bool IsBetween(this float i, float first, float second) => (i >= first && i <= second);

    /// <summary>
    /// Returns true if Int is negative (below 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsNegative(this int i) => i < 0;

    /// <summary>
    /// Returns true if Int is positive (above 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsPositive(this int i) => i > 0;

    /// <summary>
    /// Returns true if Int is positive or zero (above or equals to 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsPositiveOrZero(this int i) => i >= 0;

    /// <summary>Returns true if Int is 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsZero(this int i) => i == 0;


    /// <summary>
    /// Returns true if Float is negative (below 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsNegative(this float i) => i < 0;

    /// <summary>
    /// Returns true if Float is positive (above 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsPositive(this float i) => i > 0;

    /// <summary>
    /// Returns true if Float is positive or zero (above or equals to 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsPositiveOrZero(this float i) => i >= 0;

    /// <summary>Returns true if Float is 0)
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool IsZero(this float i) => i == 0;

    /// <summary>
    /// Truncates a string
    /// </summary>
    /// <param name="value"></param>
    /// <param name="maxLength"></param>
    /// <returns></returns>
    public static string Truncate(this string value, int maxLength)
    {
        if (string.IsNullOrEmpty(value)) return value;
        return value.Length <= maxLength ? value : value.Substring(0, maxLength);
    }
}

/// <summary>
/// Class of extensions : Collection
/// </summary>
public static class ExtensionsCollection
{
    /// <summary>
    /// Returns a random element of this collection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="col"></param>
    /// <returns></returns>
    public static T RandomElement<T>(this IList<T> col)
    {
        int rand = UnityEngine.Random.Range(0, col.Count);
        return col[rand];
    }

    /// <summary>
    /// Shuffles an IList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    public static void Shuffle<T>(this IList<T> arr)
    {
        List<T> temp1 = arr.ToList();
        List<T> temp2 = new List<T>();

        for (int i = 0; i < arr.Count; i++)
        {
            int rand = UnityEngine.Random.Range(0, temp1.Count);
            temp2.Add(temp1[rand]);
            temp1.RemoveAt(rand);
        }

        for (int i = 0; i < temp2.Count; i++)
        {
            arr[i] = temp2[i];
        }
    }

    /// <summary>
    /// Alternative ToList()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="arr"></param>
    /// <returns></returns>
    public static List<T> ToListAlt<T>(this T[] arr)
    {
        /*
        List<T> temp = new List<T>();
        for (int i = 0; i < arr.Length; i++)
        {
            temp.Add(arr[i]);
        }
        */
        List<T> temp = new List<T>(arr);
        return temp;
    }

    /// <summary>
    /// Alternative IList ToString()
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="col"></param>
    /// <returns></returns>
    public static string ToStringAlt<T>(this IList<T> col)
    {
        StringBuilder sb = new StringBuilder("{ ");
        for (int i = 0; i < col.Count; i++)
        {
            if (i == col.Count - 1)
            {
                //Akhiran
                sb.Append(col[i].ToString());
                continue;
            }
            sb.Append(col[i].ToString());
            sb.Append(", ");
        }
        sb.Append(" }");
        return sb.ToString();
    }
}

/// <summary>
/// Class of extensions : Conversion
/// </summary>
public static class ExtensionsConversion
{
    /// <summary>
    /// Converts Bool to Int. true = 1, false = 0;
    /// </summary>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int ToInt(this bool b) => b ? 1 : 0;

    /// <summary>
    /// Converts Int to Bool. true : >= 1, false : < 1;
    /// </summary>
    /// <param name="i"></param>
    /// <returns></returns>
    public static bool ToBool(this int i) => i >= 1;

    /// <summary>
    /// Converts string to enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="s"></param>
    /// <returns></returns>
    public static T ToEnum<T>(this string s) where T : System.Enum
    {
        try
        {
            return (T)System.Enum.Parse(typeof(T), s);
        }
        catch (System.Exception)
        {
            throw;
        }
    }

    /// <summary>
    /// Converts int to enum
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="i"></param>
    /// <returns></returns>
    public static T ToEnum<T>(this int i) where T : System.Enum
    {
        try
        {
            return (T)System.Enum.ToObject(typeof(T), i);
        }
        catch (System.Exception)
        {

            throw;
        }
    }
}

/// <summary>
/// Class of extensions : Complementary of custom classes
/// </summary>
public static class ExtensionsComplementary
{

}

//V1
/*
 * Contains : Swap, RandomBool, RandomString, WeightedFunction, 50/50Function, NewIntRangeArray, NewIntListArray, CombineArray&List, GCD
 *              
 */
/// <summary>
/// Class of utilities
/// </summary>
public class Utilities
{
    public static readonly char[] uppercaseLetters = new char[26]
    {
        'A',
        'B',
        'C',
        'D',
        'E',
        'F',
        'G',
        'H',
        'I',
        'J',
        'K',
        'L',
        'M',
        'N',
        'O',
        'P',
        'Q',
        'R',
        'S',
        'T',
        'U',
        'V',
        'W',
        'X',
        'Y',
        'Z'
    };
    public static readonly char[] numbers = new char[10]
    {
        '0',
        '1',
        '2',
        '3',
        '4',
        '5',
        '6',
        '7',
        '8',
        '9'
    };

    /// <summary>
    /// Swaps one object with another
    /// </summary>
    /// <typeparam name="T">Type</typeparam>
    /// <param name="one">First object</param>
    /// <param name="two">Second object</param>
    public static bool Swap<T>(ref T one, ref T two)
    {
        try
        {
            T temp2 = two;
            T temp1 = one;
            one = temp2;
            two = temp1;
            return true;
        }
        catch (System.Exception)
        {
            return false;
            throw;
        }
    }

    public static class Random
    {

        /// <summary>
        /// Returns a random bool
        /// </summary>
        /// <returns></returns>
        public static bool RandomBool()
        {
            int rand = UnityEngine.Random.Range(0, 2); //0-1
            return rand == 1;
        }

        /// <summary>
        /// Returns a random bool based on middle and max value
        /// </summary>
        /// <param name="middle">Division between true or false</param>
        /// <param name="max">Max value</param>
        /// <returns></returns>
        public static bool RandomBool(float middle, float max)
        {
            if (middle > max || middle < 0f)
            {
                Debug.LogError("Failed to randomize bool");
                throw new System.ArgumentOutOfRangeException("Middle is more than Max, or Middle is less than 0");
            }
            float rand = UnityEngine.Random.Range(0f, max);
            return rand >= middle;
        }

        /// <summary>
        /// Returns a randomized string
        /// </summary>
        /// <param name="length">Length of string</param>
        /// <param name="uppercase">Is uppercase included</param>
        /// <param name="lowercase">Is lowercase included</param>
        /// <param name="number">Is number included</param>
        /// <returns></returns>
        public static string RandomString(int length, bool uppercase, bool lowercase, bool number)
        {
            List<char> pool = new List<char>();
            string result = "";
            if (uppercase)
            {
                pool.AddRange(uppercaseLetters);
            }
            if (lowercase)
            {
                for (int i = 0; i < uppercaseLetters.Length; i++)
                {
                    pool.Add(char.ToLower(uppercaseLetters[i]));
                }
            }
            if (number)
            {
                pool.AddRange(numbers);
            }

            for (int i = 0; i < length; i++)
            {
                int rand = UnityEngine.Random.Range(0, pool.Count);
                result += pool[rand];
            }

            return result;
        }

        /// <summary>
        /// Returns a randomized Alphanumeric string with uppercase and lowercase
        /// </summary>
        /// <param name="length">Length of string</param>
        /// <returns></returns>
        public static string RandomString(int length)
        {
            return RandomString(length, true, true, true);
        }

        /// <summary>
        /// Executes the function with a percentage of chance
        /// </summary>
        /// <param name="act">Function to run</param>
        /// <param name="percentage">Chance percentage (0-100)</param>
        public static void WeightedFunction(System.Action act, int percentage)
        {
            if (percentage > 100 || percentage < 0)
            {
                throw new System.ArgumentOutOfRangeException();
            }
            //int otherPercent = 100 - percentage;

            int rand = UnityEngine.Random.Range(0, 101); //0 - 100

            if (rand.IsBetween(0, percentage)) //if ex:rand=12, percent=30, 0 < 12 < 30  ||  if ex:rand=35 0 < 35 < 30 == false
            {
                act();
            }
        }

        /// <summary>
        /// Executes the function with a 50/50 chance
        /// </summary>
        /// <param name="act">Function to run</param>
        public static void CoinFlipFunction(System.Action act)
        {
            if (RandomBool()) //50/50
            {
                act();
            }
        }

        /// <summary>
        /// Returns a random object from the parameters
        /// </summary>
        /// <typeparam name="T">Type of object</typeparam>
        /// <param name="objects">Objects to be picked</param>
        /// <returns>Picked object</returns>
        public static T RandomObject<T>(params T[] objects)
        {
            return objects.RandomElement();
        }
    }


    /// <summary>
    /// Returns an Int Array consisting of numbers ranged from min to max
    /// </summary>
    /// <param name="min">Range min</param>
    /// <param name="max">Range max</param>
    /// <returns>Int Array</returns>
    public static int[] NewIntRangeArray(int min, int max)
    {
        return NewIntRangeList(min, max).ToArray();
    }

    /// <summary>
    /// Returns an Int List consisting of numbers ranged from min to max
    /// </summary>
    /// <param name="min">Range min</param>
    /// <param name="max">Range max</param>
    /// <returns>Int List</returns>
    public static List<int> NewIntRangeList(int min, int max)
    {
        List<int> l = new List<int>();
        for (int i = min; i < max + 1; i++)
        {
            l.Add(i);
        }
        return l;
    }

    /// <summary>
    /// Returns a combined List of collection1 and 2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection1">First collection</param>
    /// <param name="collection2">Second collection</param>
    /// <returns></returns>
    public static List<T> CombineList<T>(IList<T> collection1, IList<T> collection2)
    {
        List<T> l1 = new List<T>(collection1);
        l1.AddRange(collection2);
        return l1;
    }

    /// <summary>
    /// Returns a combined Array of collection1 and 2
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="collection1">First collection</param>
    /// <param name="collection2">Second collection</param>
    /// <returns></returns>
    public static T[] CombineArray<T>(IList<T> collection1, IList<T> collection2)
    {
        List<T> l1 = new List<T>(collection1);
        l1.AddRange(collection2);
        return l1.ToArray();
    }

    /// <summary>
    /// Returns the total value of an int array
    /// </summary>
    /// <param name="intArray">The Int Array</param>
    /// <returns></returns>
    public static int TotalInt(int[] intArray)
    {
        int temp = 0;
        for (int i = 0; i < intArray.Length; i++)
        {
            temp += intArray[i];
        }
        return temp;
    }

    /// <summary>
    /// Returns the total value of an float array
    /// </summary>
    /// <param name="floatArray">The Float Array</param>
    /// <returns></returns>
    public static float TotalFloat(float[] floatArray)
    {
        float temp = 0;
        for (int i = 0; i < floatArray.Length; i++)
        {
            temp += floatArray[i];
        }
        return temp;
    }

    /// <summary>
    /// Returns the Greatest Common Divisor of Ints
    /// </summary>
    /// <param name="numbers"></param>
    /// <returns></returns>
    public static int GCD(int[] numbers)
    {
        return numbers.Aggregate(GCD);
    }

    /// <summary>
    /// Returns the Greatest Common Divisor of two Ints
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static int GCD(int a, int b)
    {
        return b == 0 ? a : GCD(b, a % b);
    }

    /// <summary>
    /// Returns the average value of an int array as an int
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static int AverageToInt(int[] array)
    {
        return Utilities.TotalInt(array) / array.Length;
    }

    /// <summary>
    /// Returns the average value of an float array
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static float Average(int[] array)
    {
        return Utilities.TotalInt(array) / array.Length;
    }

    /// <summary>
    /// Returns the average value of an float array
    /// </summary>
    /// <param name="array"></param>
    /// <returns></returns>
    public static float Average(float[] array)
    {
        return Utilities.TotalFloat(array) / array.Length;
    }

    /// <summary>
    /// Converts 2Dimensional Array Index into a 1Dimensional Array Index
    /// </summary>
    /// <param name="x">Column/X index</param>
    /// <param name="y">Row/Y index</param>
    /// <param name="maxY">Row/Y Length</param>
    /// <returns></returns>
    public static int BiToUnidimensionalIndex(int x, int y, int maxY)
    {
        return x * maxY + y; 
    }

    /// <summary>
    /// Returns value as a variable (Not recommended to use)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static int NewInt(int value) => value;

    /// <summary>
    /// Returns value as a variable (Not recommended to use)
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static float NewFloat(float value) => value;

    /// <summary>
    /// Returns a new array from params parameter
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="objs"></param>
    /// <returns></returns>
    public static T[] NewArray<T>(params T[] objs) => objs;
}

public delegate void VoidDelegate();
public delegate bool BoolDelegate();
public delegate int IntDelegate();
public delegate float FloatDelegate();
public delegate string StringDelegate();