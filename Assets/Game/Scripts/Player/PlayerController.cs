using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerData playerData;
    [SerializeField] private Transform sideMovementRoot;
    [SerializeField] private float moveLimit;

    private void Start()
    {
        transform.DOPath(RoadManager.Instance.roadPath.ToArray(), playerData.forwardSpeed, PathType.Linear)
            .SetSpeedBased()
            .SetEase(Ease.Linear);
    }

    void Update()
    {
        HandleSideMovement();
    }

    private void HandleSideMovement()
    {
        float swerveAmount = playerData.swerveSpeed * InputManager.Instance.MoveFactorX;
        var currentPos = this.sideMovementRoot.localPosition;
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -moveLimit, moveLimit);
        this.sideMovementRoot.localPosition = currentPos;
    }

    // TODO : fix the hardcode 
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("GoodCollectable"))
        {
            // TODO Couple Progress Bar Increased
            UIManager.Instance.UpdateLove(4);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BadCollectable"))
        {
            // TODO Couple Progress Bar Decreased
            UIManager.Instance.UpdateLove(-2);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("GoodGift"))
        {
            UIManager.Instance.UpdateLove(3);
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("BadGift"))
        {
            UIManager.Instance.UpdateLove(-3);
            Destroy(other.gameObject);
        }
    }
}
