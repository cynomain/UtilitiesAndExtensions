using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

[RequireComponent(typeof(Renderer))]
public class ExposedShadow : MonoBehaviour
{
    Renderer sr = null;
    public ShadowCastingMode shadowCastingMode = ShadowCastingMode.On;
    public bool recieveShadow = true;

    private void Awake()
    {
        if (sr == null)
        sr = GetComponent<Renderer>();

        sr.shadowCastingMode = shadowCastingMode;
        sr.receiveShadows = recieveShadow;
    }

    private void OnValidate()
    {
        if (sr == null)
            sr = GetComponent<Renderer>();

        sr.shadowCastingMode = shadowCastingMode;
        sr.receiveShadows = recieveShadow;
    }
}
