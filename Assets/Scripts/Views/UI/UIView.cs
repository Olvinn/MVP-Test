using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIView : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _name, _description;

    public void SetUpName(string name)
    {
        _name.text = name;
    }

    public void SetUpDescription(string description)
    {
        _description.text = description;
    }

    public void SetUpData(string name, string description)
    {
        SetUpName(name);
        SetUpDescription(description);
    }

    public void Clear()
    {
        _name.text = "";
        _description.text = "";
    }
}
