using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SliderUI : MonoBehaviour
{
    public Slider slider;
    public void SetSliderValue(int value)
    {
        slider.value = value;
    }  
    public void SetSliderMaxValue(int value)
    {
        slider.maxValue = value;
        slider.value = value;
    }

}
