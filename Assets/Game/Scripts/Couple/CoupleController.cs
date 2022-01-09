using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleController : MonoBehaviour
{
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private Transform player;
    private bool reachedFinal = false;

    private void OnEnable()
    {
        Observer.coupleFinalWalk += FinalMoveAside;
    }

    private void OnDisable()
    {
        Observer.coupleFinalWalk -= FinalMoveAside;
    }
    void Update()
    {
        if(!reachedFinal) HandleSideMovements();
    }
    private void HandleSideMovements()
    {
        sideMovementRoot.position = Vector3.Lerp(player.position + Vector3.forward * 4f, sideMovementRoot.position, 0.6f);
    }

    private void FinalMoveAside()
    {
        reachedFinal = true;
        AnimationManager.Instance.StopCoupleAnimation();
    }
}
