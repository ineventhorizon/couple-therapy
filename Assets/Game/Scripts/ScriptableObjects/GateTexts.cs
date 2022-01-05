using System.Collections;
using System.Collections.Generic;
using NaughtyAttributes;
using UnityEngine;

[CreateAssetMenu(fileName = "GateText", menuName = "ScriptableObjects/GateTexts", order = 1)]
public class GateTexts : ScriptableObject
{
    public GateTextDictionary textDictionary;

    public string GetTextWithType(TextType type)
    {
        int randomIndex;
        string randomText = "";
        switch (type)
        {
            case TextType.Positive:
                randomIndex = Random.Range(0, textDictionary.positiveText.Count-1);
                randomText = textDictionary.positiveText[randomIndex];
                return randomText;
            case TextType.Negative:
                randomIndex = Random.Range(0, textDictionary.negativeText.Count-1);
                randomText = textDictionary.negativeText[randomIndex];
                return randomText;
            case TextType.Neutral:
                randomIndex = Random.Range(0, textDictionary.neutralText.Count-1);
                randomText = textDictionary.neutralText[randomIndex];
                return randomText;
        }

        return "error";
    }

}

[System.Serializable]
public class GateTextDictionary
{
    public List<string> positiveText;
    public List<string> negativeText;
    public List<string> neutralText;

}


