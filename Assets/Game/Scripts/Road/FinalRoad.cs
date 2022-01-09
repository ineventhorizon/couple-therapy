using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRoad : MonoBehaviour
{
    [SerializeField] private FinalRoadData roadData;
    [SerializeField] private Renderer finalRenderer;
    [SerializeField] private TextMeshProUGUI multiplierText;

    public void Initialize(FinalRoadData data)
    {
        roadData = data;
        finalRenderer.material = roadData.material;
        multiplierText.SetText(data.multiplier.ToString()+ "x");
        //SET TEXT
    }
}
