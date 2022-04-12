using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TestBinaryWriter : MonoBehaviour
{
    public struct teststruct
    {
        public string str;
        public int i;
        public bool b;
        public float f;
        public decimal d;

        public override string ToString()
        {
            return $"{str}, {i}, {b}, {f}, {d}";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        string path = Path.Combine(Application.persistentDataPath, "binarytest.bin");
        string path2 = Path.Combine(Application.persistentDataPath, "jsonest.json");
        Debug.Log("Binarypath : " + path);
        using (var fs = File.Open(path, FileMode.Create))
        {
            using (BinaryWriter bw = new BinaryWriter(fs))
            {
                bw.Write("Thing1");
                bw.Write(120);
                bw.Write(true);
                bw.Write(100.25f);
                bw.Write(25.25m);
            }
        }

        teststruct ts = new teststruct() { str = "Thing1", i = 120, b = true, f = 100.25f, d = 25.25m };
        string json = JsonUtility.ToJson(ts);

        File.WriteAllText(path2, json);

        using (var fs = File.Open(path, FileMode.Open))
        {
            using (BinaryReader br = new BinaryReader(fs))
            {
                Debug.Log(br.ReadString());
                Debug.Log(br.ReadInt32());
                Debug.Log(br.ReadBoolean());
                Debug.Log(br.ReadSingle());
            }
        }

        Debug.Log(JsonUtility.FromJson<teststruct>(File.ReadAllText(path2)));
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
