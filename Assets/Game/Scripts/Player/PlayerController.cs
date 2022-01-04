using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform sideMovementRoot;
    //[SerializeField] private Transform couple;


    void Update()
    {
        //HandleMovements();
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
    private void HandleMovements()
    {
        float forwardMove = playerData.forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * playerData.swerveSpeed * InputManager.Instance.MoveFactorX;

        Vector3 position = CalculatePosition(forwardMove, swerveAmount);

        transform.position = position;
        //couple.transform.position = position;

    }

    private Vector3 CalculatePosition(float forward, float xSwerve)
    {
        var currentPos = this.transform.position;
        currentPos.z += forward;

        currentPos.x += xSwerve;
        currentPos.x = Mathf.Clamp(currentPos.x, -4, 4f);
        
        return currentPos;
    }
}
