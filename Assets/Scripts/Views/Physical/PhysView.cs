using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PhysView : MonoBehaviour
{
    [SerializeField] Transform _spawn;
    GameObject _modelPhys;
    List<GameObject> _parts;

    private void Start()
    {
        _parts = new List<GameObject>();
    }

    public void SetUpModel(GameObject model)
    {
        ClearModel();
        _modelPhys = Instantiate(model, _spawn.position, _spawn.rotation, _spawn);
    }

    public GameObject SetUpPart(GameObject part, Vector3 locPos, Quaternion locRot)
    {
        GameObject obj = Instantiate(part, _modelPhys.transform.position + locPos, _modelPhys.transform.rotation * locRot, _modelPhys.transform);
        _parts.Add(obj);
        return obj;
    }

    public void SelectPart(GameObject part)
    {
        if (_parts.Contains(part))
        {
            foreach (Renderer r in _modelPhys.GetComponentsInChildren<Renderer>())
                r.enabled = false;

            foreach (Renderer r in part.GetComponentsInChildren<Renderer>())
                r.enabled = true;
        }
    }

    public void UnselectPart()
    {
        foreach (Renderer r in _modelPhys.GetComponentsInChildren<Renderer>())
            r.enabled = true;
    }

    public void ClearModel()
    {
        if (_modelPhys)
            Destroy(_modelPhys);
        foreach (GameObject obj in _parts)
            Destroy(obj);
        _parts.Clear();
    }
}
