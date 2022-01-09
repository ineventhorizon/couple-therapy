using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoupleController : MonoBehaviour
{
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private Transform player;
    [SerializeField] private float gapWithPlayer = 4f;
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
        transform.position = Vector3.Lerp(player.position+Vector3.forward*gapWithPlayer, transform.position, 0.7f);
    }

    private void FinalMoveAside()
    {
        reachedFinal = true;
        transform.position = Vector3.Lerp(sideMovementRoot.position + Vector3.back * 5f, sideMovementRoot.position, 0.6f);
        AnimationManager.Instance.StopCoupleAnimation();
    }
}
