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
        Observer.playerFinalWalk += FinalMoveTowards;
    }

    private void OnDisable()
    {
        Observer.startPlayerMovement -= StartMovement;
        Observer.playerFinalWalk -= FinalMoveTowards;
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

    private void FinalMoveTowards()
    {
        GameManager.Instance.GameEnded();
        Debug.Log("Game ended!");
        var posOffSet = LoveBar.currLove * 1.75f;
        var newPos = posOffSet * Vector3.forward;
        var targetPosition = newPos;
        targetPosition += transform.position;
        StartCoroutine(MoveTowardsRoutine(targetPosition));
        
    }

    IEnumerator MoveTowardsRoutine(Vector3 targetPosition)
    {
        if (LoveBar.currLove == 0)
        {
            GameManager.Instance.GameOver();
            AnimationManager.Instance.EnableGameOverAnim();
            yield break;
        }
        while (true)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * playerData.forwardSpeed);
            float distanceLeft = (transform.position - targetPosition).magnitude;
            if (distanceLeft < 0.001f)
            {
                break;
            }
            yield return null;
        }
        GameManager.Instance.NextLevel();
    }
}
