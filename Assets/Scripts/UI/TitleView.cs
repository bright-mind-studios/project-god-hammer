using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleView : View
{
    [SerializeField] private Button btn_menuprincipal;
    public override void Init()
    {
        btn_menuprincipal.onClick.AddListener(() => controller.Show<MainMenuView>());
    }
}
