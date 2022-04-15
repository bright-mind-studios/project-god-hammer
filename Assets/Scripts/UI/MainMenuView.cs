using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuView : View
{
    [SerializeField] private Button btn_jugar;
    [SerializeField] private Button btn_opciones;
    [SerializeField] private Button btn_salir;

    public override void Init()
    {
        btn_jugar.onClick.AddListener(GameManager.Instance.LoadGame);
        btn_opciones.onClick.AddListener(() => controller.Show<OptionsView>());
        btn_salir.onClick.AddListener(GameManager.Instance.ExitGame);
    }
}
