using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Models/Model")]
public class Model : ScriptableObject
{
    public string modelName;
    public string description;
    public GameObject prefab;
}
