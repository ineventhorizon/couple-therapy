using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class LoveBar : MonoBehaviour
{
    // Love Bar Variables
    [SerializeField] private float maxLove;
    [SerializeField] private float currLove;

    // Love Bar fill color variables
    [SerializeField] private Image loveBar;
    [SerializeField] private Gradient gradient;

    // Love Bar Text Variables
    [SerializeField] private TMP_Text loveBarText;
    [SerializeField] private List<Color> textColors;


    public void SetMaxLove(float value)
    {
        maxLove = value;
    }

    public void UpdateLoveBar(float value)
    {
        currLove += value;
        if (currLove > maxLove) currLove = maxLove;
        var loveAmount = currLove / maxLove;

        PopUpText(loveAmount);
        loveBar.fillAmount = loveAmount;
        loveBar.color = gradient.Evaluate(loveAmount);
    }

    // TODO : fix the hardcode (Yemekten sonra duzelticem :)
    private void PopUpText(float loveAmount)
    {

        if (0.0f < loveAmount && loveAmount <= 0.2f)
        {
            loveBarText.text = "HATRED";
            loveBarText.color = textColors[0];
        }
        else if (0.2 < loveAmount && loveAmount <= 0.4f)
        {
            loveBarText.text = "DOUBTFUL";
            loveBarText.color = textColors[1];
        }
        else if (0.4f < loveAmount && loveAmount <= 0.7f)
        {
            loveBarText.text = "CASUAL";
            loveBarText.color = textColors[2];
        }
        else if (0.7 < loveAmount && loveAmount <= 0.95f)
        {
            loveBarText.text = "LIKING";
            loveBarText.color = textColors[3];
        }
        else
        {
            loveBarText.text = "IN LOVE";
            loveBarText.color = textColors[4];
        }

    }
}
