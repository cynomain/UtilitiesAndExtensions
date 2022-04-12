using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Logger : MonoBehaviour
{

    public bool StackTrace;
    public string AdditionalPath = "Logs/{0}.log";
    //string log = "";
    //DateTime applicationStart;
    public DateType datingType;


    public void Awake()
    {
        //applicationStart = DateTime.Now;
        //log += $"## DATE : {DateTime.Today.ToShortDateString()} ##\n";
        Application.logMessageReceived += OnLog;
    }

    private void Start()
    {
        if (File.Exists(GetFullLatestPath()))
        {
            File.WriteAllText(GetFullLatestPath(), "");
        }
        else
        {
            File.WriteAllText(GetFullLatestPath(), "");
        }
    }

    string determineDate(DateType type)
    {
        switch (datingType)
        {
            case DateType.Time:
                return DateTime.Now.ToString("HH:mm:ss");
            case DateType.Full:
                return DateTime.Now.ToString("yyyy:MM:dd/HH:mm:ss");
        }
        return "";
    }

    private void OnLog(string condition, string stackTrace, LogType type)
    {
        string date = "";
        if (datingType != DateType.None)
        {
            date = $"[{determineDate(datingType)}]";
        }
        string tobeadded = $"{date}[{type.ToString().ToUpper()}] {condition}";
        if (StackTrace && type == LogType.Exception)
        {
            tobeadded += $"\n        {stackTrace}";
        }
        AddToLogFile(tobeadded);
        //Debug.Log(tobeadded);
    }

    public void AddToLogFile(string s)
    {
        File.AppendAllText(GetFullPath(GetPathLatest()), "\n" + s);
    }

    public void OnApplicationQuit()
    {        
        if (File.Exists(GetFullLatestPath()))
         File.Copy(GetFullLatestPath(), GetFullPathDated());
    }

    public string GetPathLatest()
    {
        return string.Format(AdditionalPath, "latest");
    }

    public string GetFullPath(string added)
    {
        return Path.Combine(Application.persistentDataPath, added);
    }

    public string GetFullLatestPath() => GetFullPath(GetPathLatest());

    public string GetPathDated() => string.Format(AdditionalPath, DateTime.Now.ToString("dd-MM-yyyy#HH-mm-ss"));

    public string GetFullPathDated() => Path.Combine(Application.persistentDataPath, GetPathDated());

    public void OnEnable()
    {
        Application.logMessageReceived += OnLog;
    }

    public void OnDisable()
    {
        Application.logMessageReceived -= OnLog;
    }

    public enum DateType
    {
        Time,
        Full,
        None
    }
}
