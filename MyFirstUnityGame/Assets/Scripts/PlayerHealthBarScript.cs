using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxHealth(int Health)
    {
        slider.maxValue = Health;
        slider.value = Health;

        fill.color = gradient.Evaluate(1f);
    }
    public void SetHealth(int hp)
    {
        slider.value = hp;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }



}
