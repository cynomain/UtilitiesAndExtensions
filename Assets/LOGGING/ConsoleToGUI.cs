using UnityEngine;
using System;

namespace DebugStuff
{
    public class ConsoleToGUI : MonoBehaviour
    {
        public KeyCode debugKey = KeyCode.Space;
        string myLog = "*begin log";
        string filename = "";
        bool doShow = true;
        int kChars = 700;
        void OnEnable() { Application.logMessageReceived += Log; }
        void OnDisable() { Application.logMessageReceived -= Log; }
        void Update() { if (Input.GetKeyDown(debugKey)) { doShow = !doShow; } }
        public string folderAfterPersistentDataPath = "/Logs";
        public DateType datingType;

        public void Log(string logString, string stackTrace, LogType type)
        {
            // for onscreen...
            myLog = myLog + "\n" + logString;
            if (myLog.Length > kChars) { myLog = myLog.Substring(myLog.Length - kChars); }

            // for the file ...
            if (filename == "")
            {
                string d = Application.persistentDataPath + folderAfterPersistentDataPath;
                System.IO.Directory.CreateDirectory(d);
                //string r = Random.Range(1000, 9999).ToString();
                string r = determineDate(datingType);
                filename = d + "/log-" + r + ".txt";
            }
            try { System.IO.File.AppendAllText(filename, logString + "\n"); }
            catch { }
        }

        void OnGUI()
        {
            if (!doShow) { return; }
            GUI.matrix = Matrix4x4.TRS(Vector3.zero, Quaternion.identity,
               new Vector3(Screen.width / 1200.0f, Screen.height / 800.0f, 1.0f));
            GUI.TextArea(new Rect(10, 10, 540, 370), myLog);
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

        public enum DateType
        {
            Time,
            Full,
            None
        }
    }
}