using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectorPresenter : MonoBehaviour
{
    [SerializeField] SelectorView _view;
    [SerializeField] ObjectPresenter _op;
    [SerializeField] RayCasterPresenter _rc;
    [SerializeField] ModelsDB _db;

    int i = 0;

    private void Start()
    {
        _view.onNext += NextObject;
        _view.onPrev += PreviousObject;
        _view.onBack += BackToModel;
        _view.ShowBack(false);
        NextObject();
    }

    public void NextObject()
    {
        i++;
        if (_db.GetModelsCount() == i)
            i = 0;

        _op.model = _db.GetModel(i);
        _op.ApplyModel();
    }

    public void PreviousObject()
    {
        i--;
        if (i < 0)
            i = _db.GetModelsCount() - 1;

        _op.model = _db.GetModel(i);
        _op.ApplyModel();
    }

    public void BackToModel()
    {
        _op.BackToModel();
        _view.ShowArrows(true);
        _view.ShowBack(false);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && _rc.underRay)
        {
            if (_op.ApplyPart(_rc.underRay))
            {
                _view.ShowArrows(false);
                _view.ShowBack(true);
            }
            else if (_op.ApplyPart(_rc.underRay.transform.parent.gameObject))
            {
                _view.ShowArrows(false);
                _view.ShowBack(true);
            }
        }
    }
}
