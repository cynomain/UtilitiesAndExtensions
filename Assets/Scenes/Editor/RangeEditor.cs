using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;

//namespace CynoMain.Editors;

/*
[CustomPropertyDrawer(typeof(Rangeint))]
public class RangeIntPropertyDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        EditorGUI.BeginProperty(position, label, property);
        EditorGUI.BeginChangeCheck();
        //position = EditorGUI.PrefixLabel(position, label);
        GUIContent lab = new GUIContent(label);
        TooltipAttribute tooltipAttribute = fieldInfo.GetCustomAttributes(typeof(TooltipAttribute), true).FirstOrDefault() as TooltipAttribute;
        lab.tooltip = tooltipAttribute != null ? tooltipAttribute.tooltip + " (%)" : "";
        //EditorGUI.LabelField()
        float temp = EditorGUI.FloatField(position, lab, property.FindPropertyRelative("Percent").floatValue);

        if (EditorGUI.EndChangeCheck())
        {
            property.FindPropertyRelative("Percent").floatValue = temp;
        }
        EditorGUI.EndProperty();
    }
}*/