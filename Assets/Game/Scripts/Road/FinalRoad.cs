using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRoad : MonoBehaviour
{
    [SerializeField] private FinalRoadData roadData;
    [SerializeField] private Renderer finalRenderer;
    [SerializeField] private TextMeshPro multiplierText;
    [SerializeField] public bool isFinal = false;

    public void Initialize(FinalRoadData data)
    {
        roadData = data;
        finalRenderer.material = roadData.material;
        multiplierText.SetText(data.multiplier.ToString()+ "x");
        //SET TEXT
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log($"Multiplier {roadData.multiplier}");
            if (isFinal) Debug.Log("Game Ended");  
        }
    }
}

