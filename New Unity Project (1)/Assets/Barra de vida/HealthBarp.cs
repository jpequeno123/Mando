using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarp : MonoBehaviour
{
    public Slider slider;

    public void Sethealth(int health1)
    {
        slider.maxValue = health1;
        slider.value = health1;
    }

    public void SetHealth(int health1)
    {
        slider.value = health1;
    }
}
