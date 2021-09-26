using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleSlider : MonoBehaviour
{
    public Slider slider;
    public Text text;
    private void Start()
    {
        slider = this.GetComponent<Slider>();
    }
    public void OnChangeSliderValue()
    {
        float val = slider.value;
        if (val >= 1 && val <= 2)
        {
            if (val == 1)
            {
                text.text = ("1.00 second/second");
                Gravity.ChangeTimeScale(1);
            }
            else
            {
                val--;
                text.text = ((val * 60).ToString("0.00") + " seconds/second");
                Gravity.ChangeTimeScale(val * 60);
            }
        }
        else if (val > 2 && val <= 3)
        {
            if (val == 2)
            {
                text.text = ("1.00 minute/second");
                Gravity.ChangeTimeScale(60);
            }
            else
            {
                val -= 2;
                text.text = (((val * 60) + 1).ToString("0.00") + " minutes/second");
                Gravity.ChangeTimeScale((val * 3600) + 60);
            }
        }
        else if (slider.value > 3 && slider.value <= 4)
        {
            if (val == 3)
            {
                text.text = ("1.00 hour/second");
                Gravity.ChangeTimeScale(3600);
            }
            else
            {
                val -= 3;
                text.text = (((val * 24) + 1).ToString("0.00") + " hour/second");
                Gravity.ChangeTimeScale((val * 86400) + 3600);
            }
        }
        else if (slider.value > 4 && slider.value <= 5)
        {
            if (val == 4)
            {
                text.text = ("1.00 day/second");
                Gravity.ChangeTimeScale(86400);
            }
            else
            {
                val -= 4;
                text.text = (((val * 7) + 1).ToString("0.00") + " days/second");
                Gravity.ChangeTimeScale(val * 604800);
            }
        }
        else if (slider.value > 5 && slider.value < 6)
        {
            if (val == 5)
            {
                text.text = ("1.00 week/second");
                Gravity.ChangeTimeScale(604800);
            }
            else
            {
                val -= 5;
                text.text = ((val * 4.2).ToString("0.00") + " weeks/second");
                Gravity.ChangeTimeScale(val * 2551443);
            }
        }
        else if (val == 6)
        {
            text.text = ("1.00 month/second");
            Gravity.ChangeTimeScale(2551443);
        }
        //60 s/min
        //3600 s/h
        //86400 s/day
        //604800 s/week
        //2551443 s/month
    }
}
