using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerperFloat
{
    MonoBehaviour handle;

    public LerperFloat(MonoBehaviour handle, float begin, float end, float duration, Action<float> act)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
    }

    public LerperFloat(MonoBehaviour handle, float begin, float end, float duration, Action<float> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<float> act;

    float timeElapsed;
    float duration;
    float begin;
    float end;
    public float Value;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        Value = begin;
        act(Value);
        while (timeElapsed < duration)
        {
            Value = Mathf.Lerp(begin, end, timeElapsed / duration);
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        begin = 0f;
        end = 0f;
        Value = 0f;
    }
}

public class LerperInt
{
    MonoBehaviour handle;

    public LerperInt(MonoBehaviour handle, int begin, int end, float duration, Action<int> act)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
    }

    public LerperInt(MonoBehaviour handle, int begin, int end, float duration, Action<int> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<int> act;

    float timeElapsed;
    float duration;
    int begin;
    int end;
    public int Value;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        Value = begin;
        act(Value);
        while (timeElapsed < duration)
        {
            Value = (int)Mathf.Lerp(begin, end, timeElapsed / duration);
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        begin = 0;
        end = 0;
        Value = 0;
    }
}

public class LerperVector3
{
    MonoBehaviour handle;

    public LerperVector3(MonoBehaviour handle, Vector3 begin, Vector3 end, float duration, Action<Vector3> act)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
    }

    public LerperVector3(MonoBehaviour handle, Vector3 begin, Vector3 end, float duration, Action<Vector3> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<Vector3> act;

    float timeElapsed;
    float duration;
    Vector3 begin;
    Vector3 end;
    public Vector3 Value;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        Value = begin;
        act(Value);
        while (timeElapsed < duration)
        {
            Value = Vector3.Lerp(begin, end, timeElapsed / duration);
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        begin = Vector3.zero;
        end = Vector3.zero;
        Value = Vector3.zero;
    }
}

public class LerperVector2
{
    MonoBehaviour handle;

    public LerperVector2(MonoBehaviour handle, Vector2 begin, Vector2 end, float duration, Action<Vector2> act)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
    }

    public LerperVector2(MonoBehaviour handle, Vector2 begin, Vector2 end, float duration, Action<Vector2> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<Vector2> act;

    float timeElapsed;
    float duration;
    Vector2 begin;
    Vector2 end;
    public Vector2 Value;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        Value = begin;
        act(Value);
        while (timeElapsed < duration)
        {
            Value = Vector2.Lerp(begin, end, timeElapsed / duration);
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        begin = Vector2.zero;
        end = Vector2.zero;
        Value = Vector2.zero;
    }
}

public class LerperQuaternion
{
    MonoBehaviour handle;

    public LerperQuaternion(MonoBehaviour handle, Quaternion begin, Quaternion end, float duration, Action<Quaternion> act)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
    }

    public LerperQuaternion(MonoBehaviour handle, Quaternion begin, Quaternion end, float duration, Action<Quaternion> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<Quaternion> act;

    float timeElapsed;
    float duration;
    Quaternion begin;
    Quaternion end;
    public Quaternion Value;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        Value = begin;
        act(Value);
        while (timeElapsed < duration)
        {
            Value = Quaternion.Lerp(begin, end, timeElapsed / duration);
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        begin = Quaternion.identity;
        end = Quaternion.identity;
        Value = Quaternion.identity;
    }
}

public class LerperColor
{
    MonoBehaviour handle;

    public LerperColor(MonoBehaviour handle, Color begin, Color end, float duration, Action<Color> act)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
    }

    public LerperColor(MonoBehaviour handle, Color begin, Color end, float duration, Action<Color> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.begin = begin;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<Color> act;

    float timeElapsed;
    float duration;
    Color begin;
    Color end;
    public Color Value;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        Value = begin;
        act(Value);
        while (timeElapsed < duration)
        {
            Value = Color.Lerp(begin, end, timeElapsed / duration);
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        begin = Color.black;
        end = Color.black;
        Value = Color.black;
    }
}

public class LerperString
{
    MonoBehaviour handle;

    public LerperString(MonoBehaviour handle, string end, float duration, Action<string> act)
    {
        this.handle = handle;
        this.act = act;
        this.end = end;
        this.duration = duration;
    }

    public LerperString(MonoBehaviour handle, string end, float duration, Action<string> act, bool autoStart)
    {
        this.handle = handle;
        this.act = act;
        this.end = end;
        this.duration = duration;
        if (autoStart)
        {
            BeginLerp();
        }
    }

    public void BeginLerp()
    {
        handle.StartCoroutine(LerpSequence());
    }

    public void ForceStopLerp()
    {
        handle.StopCoroutine(LerpSequence());
    }

    Action<string> act;

    float timeElapsed;
    float duration;
    string end;
    public string Value;
    float interval;
    int currentIndex;

    public IEnumerator LerpSequence()
    {
        timeElapsed = 0f;
        interval = duration / end.Length; //10 secs / 10 letters = 1seconds\
        currentIndex = 0;
        Value = string.Empty;
        act(Value);
        while (timeElapsed < duration)
        {
            yield return new WaitForSeconds(interval);
            Value += end[currentIndex];
            currentIndex++;
            act(Value);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        Value = end;
        act(Value);
    }

    public void Reset()
    {
        act = null;
        timeElapsed = 0f;
        duration = 0f;
        end = string.Empty;
        currentIndex = 0;
        interval = 0f;
        Value = string.Empty;
    }
}
