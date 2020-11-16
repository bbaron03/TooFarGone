using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Bars : MonoBehaviour
{
    public Slider slider;
    public float maxVal;
    public float startingVals;
    // Start is called before the first frame update
    void Start()
    {
        slider.maxValue = maxVal;
        slider.minValue = 0;
        if(this.gameObject.tag != "Clock")
            SetValue(startingVals);
        
       
    }


    public void IncreaseValue(float change)
    {
       
        slider.value += change;
    }

    public void DecreaseValue(float change)
    {
        
        slider.value -= change;
    }

    public void SetValue(float val)
    {
        slider.value = val;
    }

    public float GetValue()
    {
        return slider.value;
    }



}


