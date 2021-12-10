using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml.Serialization;
using System.IO;
using System.Text;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;

public static class FormatUtils : object
{
    public static class JSON
    {
        public static string Serialize(object obj, bool prettyprint)
        {
            return JsonUtility.ToJson(obj, prettyprint);
        }

        public static T Deserialize<T>(string json)
        {
            return JsonUtility.FromJson<T>(json);
        }
    }

    public static class XML
    {
        public static string Serialize<T>(T obj)
        {
            using (StringWriter sw = new StringWriter())
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                serializer.Serialize(sw, obj);
                string str = sw.ToString();
                return str;
            }
        }

        public static T Deserialize<T>(string xml)
        {
            using (StringReader sr = new StringReader(xml))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                object o = serializer.Deserialize(sr);
                return (T)o;
            }
        }
    }

    public static class XOREncryption
    {
        public static string EncryptDecrypt(string str, string key)
        {
           StringBuilder result = new StringBuilder();

            for (int c = 0; c < str.Length; c++)
                result.Append((char)((uint)str[c] ^ (uint)key[c % key.Length]));

            return result.ToString();
        }
    }

    public static class BINARY
    {
        public static byte[] Serialize(object obj)
        {
            using (MemoryStream ms  = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static T Deserialize<T>(byte[] data)
        {
            using (MemoryStream ms = new MemoryStream(data))
            {
                BinaryFormatter bf = new BinaryFormatter();
                object o = bf.Deserialize(ms);
                return (T)o;
            }
        }
    }

    public static class BASE64
    {
        public static string ByteArrayToBase64(byte[] bytes)
        {
            return Convert.ToBase64String(bytes);
        }

        public static byte[] ToByteArray(string str)
        {
            return Convert.FromBase64String(str);
        }
    }
}
