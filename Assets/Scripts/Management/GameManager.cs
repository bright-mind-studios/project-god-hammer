using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;
public class GameManager : Singleton<GameManager>
{
    public static GameManager Instance => instance;

    public void LoadGame()
    {
        Debug.Log("Aquí empezaría el juego");
        // Nueva partida
    }

    public void ExitGame() => Application.Quit();
}
