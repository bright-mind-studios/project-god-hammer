using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultsView : MonoBehaviour
{
    [SerializeField] private Button btn_menu, btn_replay;
    [SerializeField] private TextMeshProUGUI text;

    private void Awake() => Init();
    private void Start() 
    {
        if(GameManager.Instance != null) 
        {
            GameResults results = GameManager.Instance.Results;

        if (results.win)
            text.text = "VICTORY: " + results.lives + " VILLAGE/S OF " + results.total +" SURVIVED";
        else
            text.text = "DEFEAT: ALL VILLAGE WERE DESTROYED";
        }        
    }
    public void Init()
    {
        btn_menu.onClick.AddListener(() => GameManager.Instance?.LoadMenu());
        btn_replay.onClick.AddListener(() => GameManager.Instance?.LoadGame());
    }
}
