using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
public class GameManager : Singleton<GameManager>
{
    private GameSettings settings;
    public static GameManager Instance => instance;
    public GameSettings Settings => settings;
    
    public override void Init()
    {
        base.Init();
        settings = new GameSettings();
    }

    public void SetSettings(DifficultyData d, IntensityData i) => settings = new GameSettings{difficulty = d, intensity = i};
    public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame() => Application.Quit();
}
