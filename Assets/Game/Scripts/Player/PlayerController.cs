using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private float moveLimit;
    private void OnEnable()
    {
        Observer.startPlayerMovement += StartMovement;
    }

    private void OnDisable()
    {
        Observer.startPlayerMovement -= StartMovement;
    }

    void Update()
    {
        if (GameManager.Instance.isGameRunning)
        {
            HandleSideMovement();
            HandleForwardMovement();
        }
    }

    private void HandleSideMovement()
    {
        float swerveAmount = playerData.swerveSpeed * InputManager.Instance.MoveFactorX;
        var currentPos = this.sideMovementRoot.localPosition;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -moveLimit, moveLimit);
        this.sideMovementRoot.localPosition = currentPos;
    }

   private void StartMovement()
    {
        //FollowPath();
    }

    private void HandleForwardMovement()
    {
        var forward = Vector3.forward * playerData.forwardSpeed * Time.deltaTime;
        transform.position += forward;
    }

    private void FollowPath()
    {
        transform.DOPath(RoadManager.Instance.roadPath.ToArray(), playerData.forwardSpeed, PathType.Linear)
            .SetSpeedBased()
            .SetEase(Ease.Linear);
    }
}
