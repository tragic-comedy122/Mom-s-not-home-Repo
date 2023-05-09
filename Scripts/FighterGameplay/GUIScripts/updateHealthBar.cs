using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class updateHealthBar : MonoBehaviour
{
    // Start is called before the first frame update

    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void InitializeHealth(int health){
        slider.maxValue = health;
        slider.value = health;
        fill.color = gradient.Evaluate(1f);
    }



    public void updateHealth(int health){
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
