using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoveBar : MonoBehaviour
{
    [SerializeField] private float maxLove;
    [SerializeField] private float currLove;
    [SerializeField] private Image loveBar;
    [SerializeField] private Gradient gradient;


    public void SetMaxLove(float value)
    {
        maxLove = value;
    }

    public void UpdateLoveBar(float value)
    {
        currLove += value;
        var loveAmount = currLove / maxLove;
        loveBar.fillAmount = loveAmount;
        loveBar.color = gradient.Evaluate(loveAmount);
    }
}
