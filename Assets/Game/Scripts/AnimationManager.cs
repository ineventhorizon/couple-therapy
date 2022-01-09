using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
    #region Singleton
    private static AnimationManager instance;
    public static AnimationManager Instance => instance ?? (instance = FindObjectOfType<AnimationManager>());
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    #endregion
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator maleAnimator;
    [SerializeField] private Animator femaleAnimator;

    private void OnEnable()
    {
        Observer.startGame += EnableInGameAnimation;
    }
    private void OnDisable()
    {

        Observer.startGame -= DisableInGameAnimation;

    }
    private void EnableInGameAnimation()
    {
        StartCoupleAnimation();
        playerAnimator.SetBool("Move", true);
    }
    private void DisableInGameAnimation()
    {
        playerAnimator.SetBool("Move", false);
        StopCoupleAnimation();
    }
    public void EnableGameOverAnim()
    {
        playerAnimator.SetBool("IsGameOver", true);
    }

    public void StopCoupleAnimation()
    {
        maleAnimator.SetBool("Move", false);
        femaleAnimator.SetBool("Move", false);
        maleAnimator.SetLayerWeight(1, 0);
        femaleAnimator.SetLayerWeight(1, 0);
    }
    public void StartCoupleAnimation()
    {
        maleAnimator.SetBool("Move", true);
        femaleAnimator.SetBool("Move", true);
    }

    public void EnableWinAnim()
    {
        int randReaction = Random.Range(0, 3);
        playerAnimator.SetFloat("Reaction", (float)randReaction);
        playerAnimator.SetBool("IsWinState", true);
    }

    public void EnableReactions(GateType type)
    {
        if (type == GateType.Positive)
        {
            int randPosReaction = Random.Range(0, 2);
            femaleAnimator.SetFloat("Reaction", (float)randPosReaction);
            maleAnimator.SetFloat("Reaction", (float)randPosReaction);

        }
        else
        {
            femaleAnimator.SetFloat("Reaction", 3);
            maleAnimator.SetFloat("Reaction", 3);
        }

        StartCoroutine(ReactionsRoutine());
    }

    IEnumerator ReactionsRoutine()
    {
        maleAnimator.SetLayerWeight(1, 1);
        femaleAnimator.SetLayerWeight(1, 1);

        yield return new WaitForSeconds(2f);

        maleAnimator.SetLayerWeight(1, 0);
        femaleAnimator.SetLayerWeight(1, 0);
    }
}
