using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugStuff
{
    public class Logger : MonoBehaviour
    {
        public bool StackTrace;
        public string AdditionalPath = "/Logs/{0}.txt";
        string log = "";
        DateTime applicationStart;
        public DateType datingType;

        public void Awake()
        {
            applicationStart = DateTime.Now;
            log += $"## DATE : {DateTime.Today.ToShortDateString()} ##\n";
            Application.logMessageReceived += OnLog;
        }

        string determineDate(DateType type)
        {
            switch (datingType)
            {
                case DateType.Time:
                    return DateTime.Now.ToString("HH:mm:ss");
                case DateType.Full:
                    return DateTime.Now.ToString("dd:MM:yyyy/HH:mm:ss");
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
            log += tobeadded + "\n";
            //Debug.Log(tobeadded);
        }

        public void OnApplicationQuit()
        {
            string addPath = string.Format(AdditionalPath, applicationStart.ToString("dd-MM-yyyy#HH-mm-ss"));
            FileReadWrite.PersistentDataPath.WriteFile(addPath, log);
        }

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
}