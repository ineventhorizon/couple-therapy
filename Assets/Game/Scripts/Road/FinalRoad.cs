using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalRoad : MonoBehaviour
{
    [SerializeField] private FinalRoadData roadData;
    [SerializeField] private Renderer finalRenderer;
    [SerializeField] private TextMeshPro multiplierText;
    [SerializeField] private TextMeshPro titleText;
    [SerializeField] public bool isFinal = false;

    private void Start()
    {
        if (roadData.multiplier % 3 == 0) titleText.SetText(FinalTitle.title[(roadData.multiplier/FinalTitle.title.Length)-1]);
    }
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
            if (isFinal)
            {
                Observer.playerFinalWalk?.Invoke(); 
                Observer.coupleFinalWalk?.Invoke();
            }
            Debug.Log($"Multiplier {roadData.multiplier}");
            
        }
    }
}

