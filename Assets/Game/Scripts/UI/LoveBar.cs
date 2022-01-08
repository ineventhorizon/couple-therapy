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
    
    private void OnEnable()
    {
        Observer.updateLove += UpdateLoveBar;
    }
    private void OnDisable()
    {
        Observer.updateLove -= UpdateLoveBar;
    }

    private void Start()
    {
        SetMaxLove(30);
    }

    public void SetMaxLove(float value)
    {
        maxLove = value;
    }

    public void UpdateLoveBar(float value)
    {
        currLove += value;
        if (currLove < 0) currLove = 0;
        if (currLove > maxLove) currLove = maxLove;

        var loveAmount = currLove / maxLove;

        PopUpText(loveAmount);
        loveBar.fillAmount = loveAmount;
        loveBar.color = gradient.Evaluate(loveAmount);
    }

    private void PopUpText(float loveAmount)
    {

        if (loveAmount <= 0.2f)
        {
            loveBarText.text = "FLIRT";
            loveBarText.color = textColors[0];
        }
        else if (0.2 < loveAmount && loveAmount <= 0.4f)
        {
            loveBarText.text = "LOVERS";
            loveBarText.color = textColors[1];
        }
        else if (0.4f < loveAmount && loveAmount <= 0.7f)
        {
            loveBarText.text = "MOVE IN";
            loveBarText.color = textColors[2];
        }
        else if (0.7 < loveAmount && loveAmount <= 0.95f)
        {
            loveBarText.text = "ENGAGED";
            loveBarText.color = textColors[3];
        }
        else
        {
            loveBarText.text = "MARRIED";
            loveBarText.color = textColors[4];
        }

    }
}
