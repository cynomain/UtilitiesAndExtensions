using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestKeybindUI : MonoBehaviour
{
    public Text keyname;
    public Text keyKeycode;
    public Button keybutton;
    public KeyListener keylistener;
    //public GameObject popup;

    private void Start()
    {
        UpdateUI();
    }

    public void OnButton()
    {
        keylistener.StartListening(10f, OnKey, OnStop);
        keybutton.interactable = false;
    }

    void OnKey(KeyCode kc)
    {
        Debug.Log("ONKey " + kc);
        Keybinds.i.SetKey("test1", kc);
        UpdateUI();
    }

    void UpdateUI()
    {
        KeyCode k = Keybinds.keybinds["test1"].key;
        keyKeycode.text = k.ToString();
        keyname.text = Keybinds.keybinds["test1"].name;
    }

    void OnStop()
    {
        Debug.Log("OnStop");
        keybutton.interactable = true;
    }
}
