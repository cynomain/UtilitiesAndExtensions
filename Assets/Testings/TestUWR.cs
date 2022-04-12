using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class TestUWR : MonoBehaviour
{
    string uri = @"https://cynomain.000webhostapp.com/";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Slash))
        {
            StartCoroutine(GetEnumerate());
        }
    }

    void Get()
    {

    }

    IEnumerator GetEnumerate()
    {
        Debug.Log("Getting...");
        var uwr = UnityWebRequest.Get(uri + "gameservice.php?intent=getdateepoch");
        yield return uwr.SendWebRequest();
        Debug.Log("Response : " + uwr.responseCode);
        Debug.Log("Result : " + uwr.result);
        DateTimeOffset epochtime = DateTimeOffset.FromUnixTimeMilliseconds(((long)uwr.result));
        DateTime dt = epochtime.DateTime;
        Debug.Log(dt);
        uwr.Dispose();
    }
}
