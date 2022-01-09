using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Gate : MonoBehaviour
{
    //false if negative, true if positive
    [SerializeField] public GateType gateType;
    [SerializeField] private TextMeshProUGUI textUI;
    [SerializeField] private GateTexts gateText;
    [SerializeField] private TextType textType;
    // Start is called before the first frame update
    void Start()
    {
        GetTextType();
        //Get text at start
        GetText();
    }

    void GetText()
    {
        var randomString = gateText.GetTextWithType(textType);
        textUI.SetText(randomString);
    }

    void GetTextType()
    {
        switch (gateType)
        {
            case GateType.Negative:
                textType = TextType.Negative;
                break;
            case GateType.Positive:
                textType = TextType.Positive;
                break;
            case GateType.Random:
                textType = Random.Range(0, 1) == 0 ? TextType.Negative : TextType.Positive;
                break;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("Player"))
        {
            if (textType == TextType.Neutral) return;
            var point = textType == TextType.Positive ? 3 : -3;
            Observer.updateLove?.Invoke(point);
            Observer.PlayParticle?.Invoke(ParticleType.Gate, (int)gateType);
            AnimationManager.Instance.EnableReactions(gateType);
        }
    }
}
