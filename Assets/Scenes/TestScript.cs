using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestScript : MonoBehaviour
{
    public int one = 1;
    public int two = 2;

    public int[] shuffle = new int[] { 0, 1, 2, 3, 4, 5 };

    [Tooltip("EEEEEE")]
    public Percentage p1;
    public float toadd;
    public float percentOf;

    [Space(5)]
    [TextArea(3, 10)]
    public string toencrypt;
    [Space(5)]
    [TextArea(3, 10)]
    public string todecrypt;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Utilities.Swap<int>(ref one, ref two);
        }

        if (Input.GetKeyDown(KeyCode.H))
        {
            shuffle.Shuffle();
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            Debug.Log(Utilities.Random.RandomString(20));
        }

        if(Input.GetKeyDown(KeyCode.W))
        {
            Debug.Log(shuffle.RandomElement());
        }

        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log(shuffle.ToStringAlt());
        }

        if (Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("Is 39 betweeen 1 and 30? : " + /*ExtensionsNumeric.IsBetween(39, 1, 30)*/ Utilities.NewInt(39).IsBetween(1,30));
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log(Utilities.Random.RandomBool());
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            int enumI = 0;
            string enumS = "b";
            Debug.Log(enumS.ToEnum<TestEnum>());
            Debug.Log((int)TestEnum.c);
            Debug.Log(enumI.ToEnum<TestEnum>());
            
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            EnumDataBuffer<TestEnum> edb = new EnumDataBuffer<TestEnum>();
            edb.CycleForward(2);
            Debug.Log(edb.CurrentItem);

            DataBuffer<string> db = new DataBuffer<string>(new string[] { "aaaaaaaaa", "bbbbbbbbbbb", "cccccccccccccc", "dddddddddd" });
            db.CycleForward(6);
            Debug.Log(db.CurrentItem);
        }

        /*
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Fraction f = new Fraction(3.5f).ToMixedFraction();
            f.Simplify();
            Debug.Log(f);
        }
        */

        if (Input.GetKeyDown(KeyCode.P))
        {
            Debug.Log(p1 + toadd);
            Debug.Log(p1.PercentageOf(percentOf));
        }

        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Debug.Log("XOR ENCRYPTION");
            string val = "EHE DE NANDAYO19281928198291828&";
            string key = "PaimonTheEmergencyFood1";
            Debug.Log($"val : [{val}]");
            Debug.Log($"key : [{key}]");
            string xor = FormatUtils.XOREncryption.EncryptDecrypt(val, key);
            Debug.Log(xor);
            string back = FormatUtils.XOREncryption.EncryptDecrypt(xor, key);
            Debug.Log(back);
        }
    }
}

public enum TestEnum
{
    a,
    b,
    c
}
