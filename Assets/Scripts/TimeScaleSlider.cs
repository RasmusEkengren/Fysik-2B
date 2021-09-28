using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScaleSlider : MonoBehaviour
{
    public Slider slider;
    public Text text;
    public TrailRenderer moonTrailRenderer;
    private void Start()
    {
        slider = this.GetComponent<Slider>();
    }
    public void OnChangeSliderValue()
    {
        float snapPrecision = 0.04f;
        float snapVal = slider.value;
        snapVal -= Mathf.Floor(snapVal);
        if (snapVal >= 1 - snapPrecision || snapVal <= snapPrecision) slider.value = Mathf.Round(slider.value);
        float val = slider.value;
        if (val >= 1 && val < 2)
        {
            if (val == 1)
            {
                text.text = ("1.00 second/second");
                Gravity.ChangeTimeScale(1);
            }
            else
            {
                val--;
                text.text = (Mathf.Lerp(1, 60, val).ToString("0.00") + " seconds/second");
                Gravity.ChangeTimeScale(Mathf.Lerp(1, 60, val));
            }
        }
        else if (val >= 2 && val < 3)
        {
            if (val == 2)
            {
                text.text = ("1.00 minute/second");
                Gravity.ChangeTimeScale(60);
            }
            else
            {
                val -= 2;
                text.text = (Mathf.Lerp(1, 60, val).ToString("0.00") + " minutes/second");
                Gravity.ChangeTimeScale(Mathf.Lerp(60, 3600, val));
            }
        }
        else if (slider.value >= 3 && slider.value < 4)
        {
            if (val == 3)
            {
                text.text = ("1.00 hour/second");
                Gravity.ChangeTimeScale(3600);
            }
            else
            {
                val -= 3;
                text.text = (Mathf.Lerp(1, 24, val).ToString("0.00") + " hour/second");
                Gravity.ChangeTimeScale(Mathf.Lerp(3600, 86400, val));
            }
        }
        else if (slider.value >= 4 && slider.value < 5)
        {
            if (val == 4)
            {
                text.text = ("1.00 day/second");
                Gravity.ChangeTimeScale(86400);
            }
            else
            {
                val -= 4;
                text.text = (Mathf.Lerp(1, 7, val).ToString("0.00") + " days/second");
                Gravity.ChangeTimeScale(Mathf.Lerp(86400, 604800, val));
            }
        }
        else if (slider.value >= 5 && slider.value < 6)
        {
            if (val == 5)
            {
                text.text = ("1.00 week/second");
                Gravity.ChangeTimeScale(604800);
            }
            else
            {
                val -= 5;
                text.text = (Mathf.Lerp(1, 4.2f, val).ToString("0.00") + " weeks/second");
                Gravity.ChangeTimeScale(Mathf.Lerp(604800, 2551443, val));
            }
        }
        else if (val == 6)
        {
            text.text = ("1.00 month/second");
            Gravity.ChangeTimeScale(2551443);
        }
        moonTrailRenderer.time = 2551443 / Gravity.TimeScale;
		//60 s/min
		//3600 s/h
		//86400 s/day
		//604800 s/week
		//2551443 s/month
	}
}
