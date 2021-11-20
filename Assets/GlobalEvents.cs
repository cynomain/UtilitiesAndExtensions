using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GlobalEvents
{
    public static GlobalEventCollection eventCol;

    public class GlobalEventObject
    {
        public string id;
        public GlobalEventDelegate eventDelegate;
    }

    public class GlobalEventCollection
    {
        public List<GlobalEventObject> eventObjects;

        public GlobalEventObject this[string id]
        {
            get => eventObjects.Find(GlobalEventData => GlobalEventData.id == id);
            set => eventObjects[eventObjects.IndexOf(eventObjects.Find(GlobalEventData => GlobalEventData.id == id))] = value;
        }

        public void Execute(string s)
        {
            this[s].eventDelegate.Invoke();
        }
    }

    public delegate void GlobalEventDelegate();

    public static bool ContainsEvent(string id)
    {
        return eventCol[id] != null;
    }

    static GlobalEvents()
    {
        MonoBehaviour[] behaviors = Resources.FindObjectsOfTypeAll<MonoBehaviour>();
        foreach (var item in behaviors)
        {
            
        }
    }
}

[System.AttributeUsage(System.AttributeTargets.Method, Inherited = true, AllowMultiple = true)]
public sealed class GlobalEventListenerAttribute : System.Attribute
{
    public readonly string id;
    public GlobalEventListenerAttribute(string eventId)
    {
        id = eventId;
    }
}
