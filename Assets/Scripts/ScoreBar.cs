using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    public void SetMaxScore(int score)
    {
        slider.maxValue = score;
        slider.value = 0;

        gradient.Evaluate(1f);
    }

    public void SetScore(int score)
    {
        slider.value = score;

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
