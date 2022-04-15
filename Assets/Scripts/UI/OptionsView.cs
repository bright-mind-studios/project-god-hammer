using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionsView : View
{
    [SerializeField] private Button btn_atras;
    public override void Init()
    {
        btn_atras.onClick.AddListener(() => controller.ShowLast());
    }

    
}
