using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

public static class FileReadWrite
{
    //NOTE : PATH MUST ADD "/" first
    private static Encoding DEFAULTENCODING = Encoding.UTF8;

    #region OLDCODE
    /*
    public static bool WriteFile(string path, string text)
    {
        try
        {
            StreamWriter sw = new StreamWriter(path, true);
            sw.Write(text);
            sw.Close();
            Debug.Log("Saved File " + path);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("Failed saving file : " + path + " | ERROR : " + e.Message);
            return false;
        }
    }

    public static string ReadFile(string path)
    {
        try
        {
            StreamReader sr = new StreamReader(path);
            string s = sr.ReadToEnd();
            return s;
        }
        catch (System.Exception)
        {
            Debug.LogError("Failed reading file : " + path);
            throw;
        }
    }
    */
    #endregion

    public static bool WriteFile(string path, string text)
    {
        try
        {
            Util.CreateDirIfNotExist(path);
            StreamWriter sw = new StreamWriter(path, false, DEFAULTENCODING);
            sw.Write(text);
            sw.Close();
            Debug.Log("[FileReadWrite] Saved File " + path);
            return true;
        }
        catch (System.Exception e)
        {
            Debug.LogError("[FileReadWrite] Failed saving file : " + path);
            Debug.LogError("[FIleReadWrite] " + e.Message);
            return false;
        }
    }

    public static string ReadFile(string path)
    {
        try
        {
            return InternalReadFile(path);
        }
        catch (System.Exception)
        {
            Debug.LogError("[FileReadWrite] Failed reading file : " + path);
            throw;
        }
    }

    public static bool TryReadFile(string path, out string result)
    {
        try
        {
            result = InternalReadFile(path);
            return true;
        }
        catch (System.Exception)
        {
            Debug.LogError("[FileReadWrite] Failed reading file : " + path);
            result = "";
            return false;
        }
    }

    //Internal
    private static string InternalReadFile(string path)
    {
        StreamReader sr = new StreamReader(path);
        string s = sr.ReadToEnd();
        return s;
    }

    public static class PersistentDataPath
    {
        public static bool WriteFile(string extraPath, string text)
        {
            return FileReadWrite.WriteFile(Application.persistentDataPath + Util.SlashCheck(extraPath), text);
        }

        public static string ReadFile(string extraPath)
        {
            return FileReadWrite.ReadFile(Application.persistentDataPath + Util.SlashCheck(extraPath));
        }

        public static bool TryReadFile(string extraPath, out string result)
        {
            return FileReadWrite.TryReadFile(Application.persistentDataPath + Util.SlashCheck(extraPath), out result);
        }
    }

    public static class StreamingAssets
    {
        public static bool WriteFile(string extraPath, string text)
        {
            return FileReadWrite.WriteFile(Application.streamingAssetsPath + Util.SlashCheck(extraPath), text);
        }

        public static string ReadFile(string extraPath)
        {
            return FileReadWrite.ReadFile(Application.streamingAssetsPath + Util.SlashCheck(extraPath));
        }

        public static bool TryReadFile(string extraPath, out string result)
        {
            return FileReadWrite.TryReadFile(Application.streamingAssetsPath + Util.SlashCheck(extraPath), out result);
        }
    }

    public static class Binary
    {
        public static bool WriteFile(object obj, string path)
        {
            try
            {
                Util.CreateDirIfNotExist(path);
                using (FileStream fs = new FileStream(path, FileMode.Create, FileAccess.Write))
                {                    
                    BinaryFormatter bf = new BinaryFormatter();
                    bf.Serialize(fs, obj);
                    return true;
                }
            }
            catch (Exception e)
            {
                Debug.LogError("[FileReadWrite : Binary] Failed writing file. " + e.Message);
                return false;
                throw;
            }
        }

        public static T ReadFile<T>(string path)
        {
            try
            {
                return InternalReadFile<T>(path);
            }
            catch (Exception)
            {
                Debug.LogError("[FileReadWrite] Failed reading file as BINARY : " + path);
                throw;
            }

        }

        public static bool TryReadFile<T>(string path, out T result)
        {
            try
            {
                result = InternalReadFile<T>(path);
                return true;
            }
            catch (Exception)
            {
                Debug.LogError("[FileReadWrite] Failed reading file as BINARY : " + path);
                result = default(T);
                throw;
            }
        }

        //Internal
        private static T InternalReadFile<T>(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                BinaryFormatter bf = new BinaryFormatter();
                return (T)bf.Deserialize(fs);
            }
        }

        public class PersistentDataPath
        {
            public static T ReadFile<T>(string path)
            {
                return Binary.ReadFile<T>(Application.persistentDataPath + FileReadWrite.Util.SlashCheck(path));
            }

            public static bool TryReadFile<T>(string path, out T result)
            {
                return Binary.TryReadFile<T>(Application.persistentDataPath + FileReadWrite.Util.SlashCheck(path), out result);
            }

            public static bool WriteFile(object obj, string path)
            {
                return Binary.WriteFile(obj, Application.persistentDataPath + Util.SlashCheck(path));
            }
        }

        public class StreamingAssets
        {
            public static T ReadFile<T>(string path)
            {
                return Binary.ReadFile<T>(Application.streamingAssetsPath + FileReadWrite.Util.SlashCheck(path));
            }

            public static bool TryRead<T>(string path, out T result)
            {
                return Binary.TryReadFile<T>(Application.streamingAssetsPath + FileReadWrite.Util.SlashCheck(path), out result);
            }

            public static bool WriteFile(object obj, string path)
            {
                return Binary.WriteFile(obj, Application.streamingAssetsPath + Util.SlashCheck(path));
            }
        }
    }


    public static class Util
    {
        public static string SlashCheck(string s)
        {
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            if (!s.StartsWith("/")) //if doesnt start with /
            {
                sb.Append("/");
            }
            sb.Append(s);
            return sb.ToString();
        }

        public static string DirectoryWithoutFile(string path)
        {
            string[] strlist = path.Split('/');
            string news = path.Replace(strlist[strlist.Length - 1], "");
            return news;
        }

        public static void CreateDirIfNotExist(string path)
        {
            string nofile = Util.DirectoryWithoutFile(path);
            //Debug.Log(nofile);
            if (!Directory.Exists(nofile))
            {
                Debug.LogWarning("[FileReadWrite] Directory of path doesn't exist. Trying to create it");
                Directory.CreateDirectory(nofile);
                Debug.Log("[FileReadWrite] Directory created : " + nofile);
            }
        }
    }
}
