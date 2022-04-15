using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    [SerializeField] protected RectTransform rectTransform;
    [SerializeField] protected ViewController controller;
    public abstract void Init();

    public void HideInstant() => rectTransform.gameObject.SetActive(false);
    public void ShowInstant() =>  rectTransform.gameObject.SetActive(true);
    
    public virtual void Hide() => HideInstant();
    public virtual void Show() => ShowInstant();
}
