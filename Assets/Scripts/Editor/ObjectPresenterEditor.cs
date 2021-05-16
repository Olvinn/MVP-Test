using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

[CustomEditor(typeof(ObjectPresenter))]
public class ObjectPresenterEditor : Editor
{
    public override void OnInspectorGUI()
    {
        ObjectPresenter myTarget = (ObjectPresenter)target;

        DrawDefaultInspector();

        if (GUILayout.Button("Apply Model"))
        {
            myTarget.ApplyModel();
        }

        if (myTarget.parts != null && myTarget.parts.Count > 0)
        {
            GUILayout.Label("Parts:");
            GameObject[] gos = myTarget.parts.Keys.ToArray();

            for (int i = 0; i< gos.Length; i++)
            {
                EditorGUILayout.ObjectField(gos[i], typeof(GameObject), true);
            }
        }
    }
}