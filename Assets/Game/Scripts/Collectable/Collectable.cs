using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableType type;
    [SerializeField] private float value;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            var tmpValue = type == CollectableType.Positive ? value : -value;
            UIManager.Instance.UpdateLove(tmpValue);
        }
    }
}

