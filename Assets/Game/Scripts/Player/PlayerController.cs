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
        Vector3 forwardMove = Vector3.forward * playerData.forwardSpeed * Time.deltaTime;
        float swerveAmount = Time.deltaTime * playerData.swerveSpeed * inputManager.MoveFactorX;

        swerveAmount = Mathf.Clamp(swerveAmount, -playerData.maxSwerveAmount, playerData.maxSwerveAmount);
        transform.Translate(swerveAmount, 0, forwardMove.z);
        couple.transform.Translate(swerveAmount,0,forwardMove.z);

    }
}
