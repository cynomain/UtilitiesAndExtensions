using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class RadialSlider : MonoBehaviour
{
    [SerializeField] Image img;
    public Image.Origin360 origin = Image.Origin360.Top;
    public bool clockwise = true;
    [Tooltip("Value (0 - 1)"), Range(0f, 1f)]
    public float value = 1f;

    private void Awake()
    {
        if (!img) img = GetComponent<Image>();

        if (!img) { Debug.LogError("Image not attached to RadialSlider",this); Destroy(this); }

        img.type = Image.Type.Filled;
        img.fillMethod = Image.FillMethod.Radial360;
        img.fillOrigin = (int)origin;
        img.fillClockwise = clockwise;
    }

    private bool havebeenchangedtodefaults;
    private void OnValidate()
    {
        UpdateImage();
        OnValueChanged();
    }

    Image.Origin360 _oldorigin = Image.Origin360.Top;
    bool _oldclockwise = true;
    float _oldvalue = 1f;
    private void Update()
    {
        if (origin != _oldorigin)
        {
            UpdateImage();
            _oldorigin = origin;
        }

        if (clockwise != _oldclockwise)
        {
            UpdateImage();
            _oldclockwise = clockwise;
        }

        if (value != _oldvalue)
        {
            OnValueChanged();
            _oldvalue = value;
        }
    }

    void UpdateImage()
    {
        img.fillOrigin = (int)origin;
        img.fillClockwise = clockwise;
    }

    void OnValueChanged()
    {
        if (!img) img = GetComponent<Image>();
        img.fillAmount = value;
    }

    public void SetValue(float v)
    {
        value = v;
    }
}
