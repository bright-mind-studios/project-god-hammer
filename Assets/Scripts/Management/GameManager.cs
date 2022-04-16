using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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
    public void LoadGame()
    {
        Debug.Log("Aquí empezaría el juego");
        // Nueva partida
    }

    public void ExitGame() => Application.Quit();
}
