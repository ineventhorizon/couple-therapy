using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleController : MonoBehaviour
{
    [SerializeField] private float coupleSpeed;
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private Transform player;

    void Update()
    {
        HandleSideMovements();
    }
    private void HandleSideMovements()
    {
        sideMovementRoot.position = Vector3.Lerp(player.position + Vector3.forward * 4f, sideMovementRoot.position, 0.7f);

    }
}
