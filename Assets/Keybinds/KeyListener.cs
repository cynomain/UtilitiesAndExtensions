using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyListener : MonoBehaviour
{
    KeyCode[] keycodes;

    public KeyCode CancelKey = KeyCode.Escape;

    public bool IsListening { get; private set; } = false;

    public OnKeyPressed onKeyPressed = (key) => { };
    public KeyListenerCallback onStartListening = () => { };
    public KeyListenerCallback onStopListening = () => { };
    public UnityEvent permanentOnStartListening;
    public UnityEvent permanentOnStopListening;

    public delegate void KeyListenerCallback();
    public delegate void OnKeyPressed(KeyCode kcode);


    private void Awake()
    {
        keycodes = System.Enum.GetValues(typeof(KeyCode)) as KeyCode[];       
    }

    private void Update()
    {
        if (!IsListening)
        {
            return;
        }

        if (Input.GetKeyDown(CancelKey))
        {
            StopListening();
            return;
        }

        if (Input.anyKey)
        {
            for (int i = 0; i < keycodes.Length; i++)
            {
                if (Input.GetKeyDown(keycodes[i]))
                {                    
                    onKeyPressed(keycodes[i]);
                    StopListening();
					break;
                }
            }
        }
    }

    public void StartListening(float duration, OnKeyPressed onkeypressed, KeyListenerCallback onStopListening)
    {
        StartListening(duration, onkeypressed);
        this.onStopListening += onStopListening;        
    }

    public void StartListening(float duration, OnKeyPressed onkeypressed)
    {
        IsListening = true;
        permanentOnStartListening.Invoke();
        onKeyPressed += onkeypressed;
        Invoke(nameof(StopListening), duration);
    }

    public void StopListening()
    {
        if (IsListening)
        {
            IsListening = false;
            permanentOnStopListening.Invoke();
            onStopListening();
            onKeyPressed = (key) => { }; //ResetOnKeyPressed
            onStopListening = () => { };
            onStartListening = () => { };
        }
        CancelInvoke();
    }
}
