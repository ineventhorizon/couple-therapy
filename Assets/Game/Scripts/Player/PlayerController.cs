using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Transform couple;

    void Update()
    {
        HandleMovements();
    }

    private void HandleMovements()
    {
        float forwardMove = playerData.forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * playerData.swerveSpeed * inputManager.MoveFactorX;

        Vector3 position = CalculatePosition(forwardMove, swerveAmount);

        transform.position = position;
        couple.transform.position = position;

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
