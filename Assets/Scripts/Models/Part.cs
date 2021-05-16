using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Models/Part")]
public class Part : Model
{
    public Model parent;
    public Vector3 localPos;
    public Quaternion localRot;
}
