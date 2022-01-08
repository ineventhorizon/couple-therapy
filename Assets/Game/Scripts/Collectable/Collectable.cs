using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Collectable : MonoBehaviour
{
    [SerializeField] private CollectableType type;
    [SerializeField] private float value;
    [SerializeField] Vector3 animationRot = new Vector3(0, 180, 0);

    private void Start()
    {
        HandleAnimation();
    }
    private void OnDestroy()
    {
        DOTween.Kill(this.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
            var tmpValue = type == CollectableType.Positive ? value : -value;
            Observer.updateLove?.Invoke(tmpValue);
            UIParticle.Instance.PlayParticle(type);
        }
    }

    private void HandleAnimation()
    {
        transform.DOLocalMoveY(2f, 1f, false).SetLoops(-1, LoopType.Yoyo);
        transform.DORotate(animationRot, 2f, RotateMode.Fast).SetLoops(-1).SetEase(Ease.Linear);
    }
}

