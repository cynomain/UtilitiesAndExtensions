using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keybinds : MonoBehaviour
{
    public static Dictionary<string, Keybind> keybinds = new Dictionary<string, Keybind>();
    [SerializeField] EditorStuff.EditorKeybind[] presetKeybinds;

    public static Keybinds i;

    private void Awake()
    {
        i = this;
        for (int i = 0; i < presetKeybinds.Length; i++)
        {
            keybinds.Add(presetKeybinds[i].id, new Keybind(presetKeybinds[i].name, presetKeybinds[i].key));
        }
    }

    public void SetKey(string id, KeyCode key)
    {
        SetKey(id, key, id);
    }

    public void SetKey(string id, KeyCode key, string name)
    {
        if (keybinds.ContainsKey(id))
        {
            keybinds[id].key = key;
        }
        else
        {
            Debug.LogWarning($"Keybind with id : {id} doesn't exist. Creating it");
            keybinds.Add(id, new Keybind(name, key));            
        }
    }
    public bool KeyExists(string id)
    {
        return keybinds.ContainsKey(id);
    }

    [System.Serializable]
    public class Keybind
    {
        public string name;
        public KeyCode key;

        public Keybind(string n, KeyCode k)
        {
            name = n;
            key = k;
        }

        public static implicit operator KeyCode(Keybind k) => k.key;
    }

    public class EditorStuff
    {
        [System.Serializable]
        public class EditorKeybind
        {
            public string id;
            public string name;
            public KeyCode key;
        }
    }
}
