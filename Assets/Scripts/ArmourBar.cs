using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ArmourBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public TextMeshProUGUI lifes;
    public TextMeshProUGUI level;

    public void SetSecondsOfArmour(float secondsOfArmour)
    {
        slider.value = secondsOfArmour;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetMaxSecondsOfArmour(float maxSecondsOfArmour)
    {
        slider.maxValue = maxSecondsOfArmour;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ReduceArmourBySeconds(float elapsed)
    {
        slider.value -= elapsed;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void ActivateArmour()
    {
        fill.color = new Color(142, 142, 142);
    }

    public void Disable()
    {
        gameObject.SetActive(false);
    }
}
