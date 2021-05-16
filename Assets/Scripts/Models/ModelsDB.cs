using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Models/ModelsDataBase")]
public class ModelsDB : ScriptableObject
{
    public List<ParentModel> models;

    public ParentModel GetModel(int index)
    {
        if (index >= 0 && index < models.Count)
        {
            return models[index];
        }
        return null;
    }

    public int GetModelsCount()
    {
        return models.Count;
    }
}
