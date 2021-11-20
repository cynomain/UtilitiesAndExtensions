using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

public static class StringEncryptor
{
    /*
    public static readonly Dictionary<char, char> encryptionKeys = new Dictionary<char, char>()
    {
        ['a'] = 'a',
        ['b'] = '?',
        ['c'] = '?',
        ['d'] = '?', //
        ['e'] = '?',
        ['f'] = '?',
        ['g'] = '?',
        ['h'] = '?',
        ['i'] = '?',
        ['j'] = '?',
        ['k'] = '?',
        ['l'] = '?',
        ['m'] = '?',
        ['n'] = '?',
        ['o'] = '?',
        ['p'] = '?',
        ['q'] = '?',
        ['r'] = '?',
        ['s'] = '?',
        ['t'] = '?',
        ['u'] = '?',
        ['v'] = '?',
        ['w'] = '?',
        ['x'] = '?',
        ['y'] = '?',
        ['z'] = '?',
    };
    */
    public const string alphabets = "abcdefghijklmnopqrstuvwxyz";
    public const string alphabetsShifted = "bcdefghijklmnopqrstuvwxyza";

    public static readonly Dictionary<char, char> encryptionKeys = new Dictionary<char, char>()
    {
        ['a'] = 'b',
        ['b'] = 'c',
        ['c'] = 'd',
        ['d'] = 'e', //
        ['e'] = 'f',
        ['f'] = 'g',
        ['g'] = 'h',
        ['h'] = 'i',
        ['i'] = 'j',
        ['j'] = 'k',
        ['k'] = 'l',
        ['l'] = 'm',
        ['m'] = 'n',
        ['n'] = 'o',
        ['o'] = 'p',
        ['p'] = 'q',
        ['q'] = 'r',
        ['r'] = 's',
        ['s'] = 't',
        ['t'] = 'u',
        ['u'] = 'v',
        ['v'] = 'w',
        ['w'] = 'x',
        ['x'] = 'y',
        ['y'] = 'z',
        ['z'] = 'a',
        //NUMBER
        ['0'] = '1',
        ['1'] = '2', 
        ['2'] = '3',
        ['3'] = '4',
        ['4'] = '5',
        ['5'] = '6',
        ['6'] = '7',
        ['7'] = '8',
        ['8'] = '9',
        ['9'] = '0',
    };

    public static readonly Dictionary<char, char> encryptionKeysReverse = new Dictionary<char, char>()
    {
        ['b'] = 'a',
        ['c'] = 'b',
        ['d'] = 'c',
        ['e'] = 'd', 
        ['f'] = 'e',
        ['g'] = 'f',
        ['h'] = 'g',
        ['i'] = 'h',
        ['j'] = 'i',
        ['k'] = 'j',
        ['l'] = 'k',
        ['m'] = 'l',
        ['n'] = 'm',
        ['o'] = 'n',
        ['p'] = 'o',
        ['q'] = 'p',
        ['r'] = 'q',
        ['s'] = 'r',
        ['t'] = 's',
        ['u'] = 't',
        ['v'] = 'u',
        ['w'] = 'v',
        ['x'] = 'w',
        ['y'] = 'z',
        ['z'] = 'y',
        ['a'] = 'z',
        //NUMBER
        ['1'] = '0',
        ['2'] = '1',
        ['3'] = '2',
        ['4'] = '3',
        ['5'] = '4',
        ['6'] = '5',
        ['7'] = '6',
        ['8'] = '7',
        ['9'] = '8',
        ['0'] = '9',
    };

    public static string Encrypt(string str)
    {
        char[] chrarr = str.ToCharArray();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < chrarr.Length; i++)
        {
            //If isnt letter
            bool issymbol = !char.IsLetterOrDigit(chrarr[i]);
            if (issymbol)
            {
                sb.Append(chrarr[i]);
                continue;
            }

            bool isUpper = char.IsUpper(chrarr[i]);
            char encrypted = '?';
            bool hasValue;
            if (isUpper)
            {
                hasValue = encryptionKeys.TryGetValue(char.ToLower(chrarr[i]), out encrypted);
            }
            else
            {
                hasValue = encryptionKeys.TryGetValue(chrarr[i], out encrypted);
            }
            if (!hasValue)
            {
                sb.Append(chrarr[i]);
            }
            else
            {
                char ch = isUpper ? char.ToUpper(encrypted) : encrypted;
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }


    public static string Decrypt(string str)
    {
        char[] chrarr = str.ToCharArray();
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < chrarr.Length; i++)
        {
            //If isnt letter
            bool issymbol = !char.IsLetterOrDigit(chrarr[i]);
            if (issymbol)
            {
                sb.Append(chrarr[i]);
                continue;
            }

            bool isUpper = char.IsUpper(chrarr[i]);
            char encrypted = '?';
            bool hasValue;
            if (isUpper)
            {
                hasValue = encryptionKeysReverse.TryGetValue(char.ToLower(chrarr[i]), out encrypted);
            }
            else
            {
                hasValue = encryptionKeysReverse.TryGetValue(chrarr[i], out encrypted);
            }
            if (!hasValue)
            {
                sb.Append(chrarr[i]);
            }
            else
            {
                char ch = isUpper ? char.ToUpper(encrypted) : encrypted;
                sb.Append(ch);
            }
        }
        return sb.ToString();
    }
}
