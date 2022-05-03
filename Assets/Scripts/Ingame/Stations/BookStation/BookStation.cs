using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookStation : Station
{
    [SerializeField] List<ButtonInteractable> buttons;
    [SerializeField] List<Texture> pages;

    [SerializeField] private MeshRenderer pageRenderer;


    private void OnEnable() {
       
       for(int i = 0; i < Mathf.Min(buttons.Count, pages.Count); i++)
       {
           int idx = i;
           buttons[idx].OnPressButton += () => loadPage(idx);           
       }
    }

    private void OnDisable() {
        for(int i = 0; i < Mathf.Min(buttons.Count, pages.Count); i++)
        {
            int idx = i;
            buttons[idx].OnPressButton -= () => loadPage(idx);       
        }
    }

    private void loadPage(int idx)
    {
        Debug.Log("Change to page " + idx);
        pageRenderer.material.mainTexture = pages[idx];
    }
}
