using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debugsss : MonoBehaviour
{
    public StringStorage ss = new StringStorage();
    public StringStorage ssNew = new StringStorage();

    public Transform lerpTest;
    public float lerpedFloat;

    // Start is called before the first frame update
    void Start()
    {
        Debug.LogError("TEST ERROR");
        Debug.LogWarning("TEST WARN");
        Debug.LogException(new Exception("Test exception"));
        UnsetBool ubF = false;
        Debug.Log(ubF);
        UnsetBool ubT = true;
        Debug.Log(ubT);
        UnsetBool ubU = UnsetBool.Unset;
        Debug.Log(ubU);
        
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.L))
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                LerperFloat lf = new LerperFloat(this, -5f, 5f, 5f, (f) => { lerpedFloat = f; });
                lf.BeginLerp();
                Debug.Log("LF");
            }

            if (Input.GetKeyDown(KeyCode.V))
            {
                LerperVector3 lv3 = new LerperVector3(this, new Vector3(-10f, -10f, -10f), new Vector3(10f, 10f, 10f), 10, (v3) => { lerpTest.transform.position = v3; });
                lv3.BeginLerp();
                Debug.Log("LV");
            }

            if (Input.GetKeyDown(KeyCode.B))
            {
                LerperVector2 lv2 = new LerperVector2(this, new Vector2(-10f, -10f), new Vector2(10f, 10f), 10, (v2) => { lerpTest.transform.position = v2; });
                lv2.BeginLerp();
                Debug.Log("LB");
            }

            if (Input.GetKeyDown(KeyCode.Q))
            {
                LerperQuaternion lq = new LerperQuaternion(this, new Quaternion(0f, 0f, 0f, 0f), new Quaternion(1f, 1f, 1f, 1f), 10f ,(q) => { lerpTest.localRotation = q; });
                lq.BeginLerp();
                Debug.Log("LQ");
            }

            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            StrSaveTest();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            WriteTest();
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            XORTest();
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            BinaryTest();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            XMLTest();
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            BinaryBase64Test();
        }
        if (Input.GetKeyDown(KeyCode.M))
        {
            TestMsgBox();
        }
    }

    void XMLTest()
    {
        Debug.Log("----BEGIN XML");
        var tc =  new TestClass("PAIMON", 10, 1000);
        string xmled = FormatUtils.XML.Serialize(tc);
        Debug.Log(xmled);
        TestClass result = FormatUtils.XML.Deserialize<TestClass>(xmled);
        Debug.Log(result);
    }

    void XORTest()
    {
        Debug.Log("---- BEGIN XOR ----");
        string xored = FormatUtils.XOREncryption.EncryptDecrypt(ss.ToString(), "SDSD");
        Debug.Log(xored);
        string unxored = FormatUtils.XOREncryption.EncryptDecrypt(xored, "SDSD");
        Debug.Log(unxored);
        Debug.Log("BEGIN ERRORS");
        Debug.Log(FormatUtils.XOREncryption.EncryptDecrypt(xored, "SAISJIAJSIJAI"));
    }

    void BinaryTest()
    {
        Debug.Log("----BINARY TEST");
        string path = "/Binary/strsave.dat";
        Debug.Log("!WRITING!");
        FileReadWrite.Binary.PersistentDataPath.WriteFile(ss, path);
        Debug.Log("!READING!");
        Debug.Log(FileReadWrite.Binary.PersistentDataPath.ReadFile<StringStorage>(path));
    }

    void BinaryBase64Test()
    {
        Debug.Log("----BINARY TEST : BASE64");
        string base64 = FormatUtils.BASE64.ByteArrayToBase64(FormatUtils.BINARY.Serialize(ss));
        Debug.Log(base64);
        StringStorage ss2 = FormatUtils.BINARY.Deserialize<StringStorage>(FormatUtils.BASE64.ToByteArray(base64));
        Debug.Log(ss2);
    }

    void StrSaveTest()
    {
        int i = 12121;
        ss.Set("testint", i);
        string str = "strerere";
        ss.Set("teststring", str);
        float f = 1.23243434545f;
        ss.Set("testfloat", f);
        long l = 1210291029L;
        ss.Set("testlong", l);
        bool b = true;
        ss.Set("testbool", b);
        Vector2 v2 = new Vector2(2f, 3f);
        ss.Set("testvec2", v2);
        Vector3 v3 = new Vector3(4f, 5f, 6f);
        ss.Set("testvec3", v3);
        short s = 2;
        ss.Set("testshort", s);
        TestClass tc = new TestClass("namaaa", 6, 13);
        ss.Set("testclass", tc);
        ss.Set("testend", "END");
        string parsedtoString = StringSaveParser.StrStorageToText(ss);
        Debug.Log(parsedtoString);
        Debug.Log("---BEGIN PARSING BACK");
        ssNew = StringSaveParser.TextToStrStorage(parsedtoString);
        foreach (var item in ssNew.database)
        {
            Debug.Log(item.Key + ":" + item.Value);
        }
        Debug.Log("---BEGIN CONVERT TEST");
        Debug.Log(ssNew["testint"].AsInt());
        Debug.Log(ssNew["teststring"].AsString());
        Debug.Log(ssNew["testfloat"].AsFloat());
        Debug.Log(ssNew["testlong"].AsLong());
        Debug.Log(ssNew["testbool"].AsBool());
        Debug.Log(ssNew["testvec2"].AsVector2());
        Debug.Log(ssNew["testvec3"].AsVector3());
        Debug.Log(ssNew["testshort"].AsShort());
        Debug.Log(ssNew["testclass"].AsTypeJSON<TestClass>());
        Debug.Log(ssNew["testend"].AsString());
    }

    void WriteTest()
    {
        string extrPath = "/StrSave/strsave1.ss";
        Debug.Log("---WRITE TEST");
        FileReadWrite.PersistentDataPath.WriteFile(extrPath, ss.ToString());
    }

    void ReadTest()
    {
        string extrPath = "/StrSave/strsave1.ss";
        Debug.Log("---READ TEST");
        string read = FileReadWrite.PersistentDataPath.ReadFile(extrPath);
        Debug.Log(read);
        Debug.Log("---BEGIN PARSING FILE");
        StringStorage ssFromFile = new StringStorage(read);
        foreach (var item in ssNew.database)
        {
            Debug.Log(item.Key + ":" + item.Value);
        }
        Debug.Log(ssFromFile["testint"].AsInt());
        Debug.Log(ssFromFile["teststring"].AsString());
        Debug.Log(ssFromFile["testfloat"].AsFloat());
        Debug.Log(ssFromFile["testlong"].AsLong());
        Debug.Log(ssFromFile["testbool"].AsBool());
        Debug.Log(ssFromFile["testvec2"].AsVector2());
        Debug.Log(ssFromFile["testvec3"].AsVector3());
        Debug.Log(ssFromFile["testshort"].AsShort());
        Debug.Log(ssFromFile["testclass"].AsTypeJSON<TestClass>());
        Debug.Log(ssFromFile["testend"].AsString());
    }

    void TestMsgBox()
    {
        MsgBox.Show("Test TEXT", "Test CAPTION", "YesNoCancel");
    }

    [System.Serializable]
    public class TestClass
    {
        public string name;
        public int classnum;
        public int absen;

        public TestClass()
        {

        }

        public TestClass(string n, int c, int a)
        {
            name = n;
            classnum = c;
            absen = a;
        }

        public override string ToString()
        {
            return $"nama : {name} | kelas {classnum} | absen {absen}";
        }
    }
}
