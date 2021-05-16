using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(SelectorPresenter))]
public class SelectorPresenterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        SelectorPresenter myTarget = (SelectorPresenter)target;

        DrawDefaultInspector();

        GUILayout.BeginHorizontal();

        if (GUILayout.Button("Previous Model"))
        {
            myTarget.PreviousObject();
        }
        if (GUILayout.Button("Next Model"))
        {
            myTarget.NextObject();
        }

        GUILayout.EndHorizontal();
    }
}