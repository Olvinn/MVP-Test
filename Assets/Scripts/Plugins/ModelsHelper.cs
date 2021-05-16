using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[EditorWindowTitle(title = "Models helper")]
public class ModelsHelper : EditorWindow
{
    public ModelsDB _db;

    [MenuItem("Utils/ModelsHelper")]
    static void Init()
    {
        ModelsHelper window = (ModelsHelper)EditorWindow.GetWindow(typeof(ModelsHelper));
        window.Show();
    }

    void OnGUI()
    {
        GUILayout.Space(20);
        _db = EditorGUILayout.ObjectField("Models database:", _db, typeof(ModelsDB), true) as ModelsDB;
        if (_db)
        {
            SerializedObject so = new SerializedObject(_db);
            SerializedProperty list = so.FindProperty("models");
            EditorGUILayout.PropertyField(list);
            GUILayout.Space(20);
            if (GUILayout.Button("Add all models"))
                FindAllModels();
            if (_db.models != null && _db.models.Count > 0)
                if (GUILayout.Button("Clear models"))
                    _db.models.Clear();
        }
    }

    void FindAllModels()
    {
        string[] res = AssetDatabase.FindAssets("t:scriptableobject", new[] { "Assets/ScriptableObjects" });
        List<Model> unidentified = new List<Model>();

        foreach (string s in res)
        {
            ParentModel m = AssetDatabase.LoadAssetAtPath(AssetDatabase.GUIDToAssetPath(s), typeof(ParentModel)) as ParentModel;
            if (m)
            {
                if (!_db.models.Contains(m))
                    _db.models.Add(m);
            }
        }
    }
}