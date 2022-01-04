using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform sideMovementRoot;

    void Update()
    {
        HandleSideMovement();
    }
    private void Start()
    {
        transform.DOPath(RoadManager.Instance.roadPath.ToArray(), playerData.forwardSpeed, PathType.Linear)
            .SetSpeedBased()
            .SetEase(Ease.Linear);
    }

    private void HandleSideMovement()
    {
        float swerveAmount = playerData.swerveSpeed * InputManager.Instance.MoveFactorX;
        var currentPos = this.sideMovementRoot.localPosition;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -4, 4f);
        this.sideMovementRoot.localPosition = currentPos;
    }
}
