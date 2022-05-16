using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameView : View
{
    [SerializeField] private Button diff_1, diff_2, diff_3;
    [SerializeField] private Button int_1, int_2, int_3;
    [SerializeField] private Button btn_play;
    [SerializeField] private Button btn_back;

    public IntensityData[] intensityDatas;
    public DifficultyData[] difficultyDatas;

    public int selected_intensity = 0, selected_difficulty = 0;

    public override void Init()
    {
        diff_1.onClick.AddListener(() => selected_difficulty = 0);
        diff_2.onClick.AddListener(() => selected_difficulty = 1);
        diff_3.onClick.AddListener(() => selected_difficulty = 2);
        int_1.onClick.AddListener(() => selected_intensity = 0);
        int_2.onClick.AddListener(() => selected_intensity = 1);
        int_3.onClick.AddListener(() => selected_intensity = 2); 
        btn_back.onClick.AddListener(() => controller.ShowLast());  
        btn_play.onClick.AddListener(StartGame);    
    }

    private void StartGame()
    {
        GameManager.Instance.SetSettings(difficultyDatas[selected_difficulty], intensityDatas[selected_intensity]);
        GameManager.Instance.LoadGame();
    }    
}
