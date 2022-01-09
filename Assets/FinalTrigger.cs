using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Observer.playerFinalWalk?.Invoke();
            Observer.coupleFinalWalk?.Invoke();
        }
    }
}
