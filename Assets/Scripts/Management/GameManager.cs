using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;
public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance => instance;

    private GameSettings settings;
    public GameSettings Settings => settings;

    private GameResults results;
    public GameResults Results => results;
    
    
    
    public override void Init()
    {
        base.Init();
        settings = new GameSettings();
        results = new GameResults();
    }

    public void SetSettings(DifficultyData d, IntensityData i) => settings = new GameSettings{difficulty = d, intensity = i};

    public void SetResults(bool w, int l, int t) => results = new GameResults{win = w, total = t, lives = l};

    public void LoadMenu() =>  SceneManager.LoadScene(0);
    public void LoadGame() =>  SceneManager.LoadScene(1);
    public void LoadResults() => SceneManager.LoadScene(2);

    public void ExitGame() => Application.Quit();
}
