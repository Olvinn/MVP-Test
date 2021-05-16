using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPresenter : MonoBehaviour
{
    [SerializeField] PhysView physView;
    [SerializeField] UIView uiView;

    public ParentModel model;

    public Dictionary<GameObject, Part> parts;

    public void ApplyModel()
    {
        if (model)
        {
            parts = new Dictionary<GameObject, Part>();
            physView.SetUpModel(model.prefab);
            foreach (Part p in model.parts)
            {
                parts.Add(physView.SetUpPart(p.prefab, p.localPos, p.localRot), p);
            }
            uiView.SetUpData(model.name, model.description);
        }
    }

    public bool ApplyPart(GameObject part)
    {
        if (parts.ContainsKey(part))
        {
            physView.SelectPart(part);
            uiView.SetUpData(parts[part].modelName, parts[part].description);
            return true;
        }
            return false;
    }

    public void BackToModel()
    {
        physView.UnselectPart();
        uiView.SetUpData(model.name, model.description);
    }
}
