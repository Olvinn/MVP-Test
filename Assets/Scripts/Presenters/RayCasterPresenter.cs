using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCasterPresenter : MonoBehaviour
{
    public GameObject underRay;

    RaycastHit hit;

    private void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
        {
            underRay = hit.collider.gameObject;
        }
        else
        {
            underRay = null;
        }
    }
}
