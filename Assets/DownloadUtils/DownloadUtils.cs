using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public static class WebUtils
{
    public static string GetRequest(string url)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Get(url))
        {
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (GET) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
                return null;
            }
            return uwr.downloadHandler.text;
        }
    }

    public static void PostRequest(string url, Dictionary<string, string> formFields)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Post(url, formFields))
        {
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (POST) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
            }
        }
    }

    public static void PostRequest(string url, string formFields)
    {
        using (UnityWebRequest uwr = UnityWebRequest.Post(url, formFields))
        {
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (POST) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
            }
        }
    }

    public static void DownloadFile(string url, string path, bool append = false)
    {
        using (UnityWebRequest uwr = new UnityWebRequest(url))
        {
            uwr.downloadHandler = new DownloadHandlerFile(path, append);
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (DownloadFile) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
                return;
            }            
        }
    }

    public static Texture2D DownloadTexture(string url, bool readable = false)
    {
        using (UnityWebRequest uwr = UnityWebRequestTexture.GetTexture(url))
        {
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (DownloadTexture) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
                return null;
            }
            //return ((DownloadHandlerTexture)uwr.downloadHandler).texture;
            return DownloadHandlerTexture.GetContent(uwr);
        }
    }

    public static byte[] DownloadBuffer(string url)
    {
        using (UnityWebRequest uwr = new UnityWebRequest(url))
        {
            uwr.downloadHandler = new DownloadHandlerBuffer();
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (DownloadBuffer) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
                return null;
            }
            return uwr.downloadHandler.data;
        }
    }

    public static AssetBundle DownloadAssetBundle (string url)
    {
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(url))
        {
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (DownloadAssetBundle) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
                return null;
            }
            return DownloadHandlerAssetBundle.GetContent(uwr);
        }
    }

    public static AudioClip DownloadAudioClip(string url, AudioType type)
    {
        using (UnityWebRequest uwr = UnityWebRequestMultimedia.GetAudioClip(url, type))
        {            
            uwr.SendWebRequest();
            if (uwr.result != UnityWebRequest.Result.Success)
            {
                Debug.LogError($"UnityWebRequest (DownloadAudioClip) failed with result [{uwr.result}] and response code [{uwr.responseCode}]");
                return null;
            }
            return DownloadHandlerAudioClip.GetContent(uwr);
        }
    }
}
