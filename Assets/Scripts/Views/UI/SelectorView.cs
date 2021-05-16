using System;
using UnityEngine;
using UnityEngine.UI;

public class SelectorView : MonoBehaviour
{
    [SerializeField] Button _next, _prev, _back;

    public Action onNext, onPrev, onBack;

    private void Start()
    {
        _next.onClick.AddListener(() => onNext.Invoke());
        _prev.onClick.AddListener(() => onPrev.Invoke());
        _back.onClick.AddListener(() => onBack.Invoke());
    }

    public void ShowArrows(bool show)
    {
        _next.gameObject.SetActive(show);
        _prev.gameObject.SetActive(show);
    }

    public void ShowBack(bool show)
    {
        _back.gameObject.SetActive(show);
    }
}
