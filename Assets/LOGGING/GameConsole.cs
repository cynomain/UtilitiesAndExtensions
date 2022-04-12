using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using UnityEngine;

public class GameConsole : MonoBehaviour
{ 
    public string WindowTitle = "Game Console";
    public string WatchedFilePathAdditional = "Logs/latest.log";
    public bool StartOnAwake = true;
    public bool IgnoreDuplicates = true;
    public bool ExitOnApplicationExit = false;
    private bool Debug = false;

    private void Awake()
    {
        if (StartOnAwake)
        {
            StartConsole();
        }
    }

    private void OnApplicationQuit()
    {
        ExitConsole();
    }

    public void StartConsole()
    {
        if (File.Exists(GetFullExePath()))
        {
            Process.Start(GetFullExePath(), GetArguments());
        }
        else
        {
            UnityEngine.Debug.LogError("GameConsole.exe not found at path: " + GetFullExePath());
        }
    }

    public void ExitConsole()
    {
        Process[] prcs = Process.GetProcessesByName(WindowTitle);
        foreach (var item in prcs)
        {
            if (item.ProcessName == WindowTitle)
            {
                item.Kill();
            }
        }
    }

    private string GetArguments()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("-dir ");
        sb.Append('"' + Path.Combine(Application.persistentDataPath, WatchedFilePathAdditional) + '"' + " ");
        sb.Append("-title ");
        sb.Append('"' + WindowTitle + '"' + " ");
        if (IgnoreDuplicates)
        {
            sb.Append("-ignoredupes ");
        }
        if (Debug)
        {
            sb.Append("--debug ");
        }
        return sb.ToString();
    }

    private string GetFullExePath() => Path.Combine(Application.streamingAssetsPath, "GameConsole.exe");
}
