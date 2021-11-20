using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button), typeof(Outline))]
public class OutlinedButton : MonoBehaviour
{
    private Outline outline;
    public Color outlineColor;
    public Vector2 effectDistance;
    
}