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