using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationManager : MonoBehaviour
{
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
        playerAnimator.SetBool("Move", true);
        maleAnimator.SetBool("Move", true);
        femaleAnimator.SetBool("Move", true);
    }
    private void DisableInGameAnimation()
    {
        playerAnimator.SetBool("Move", false);
        maleAnimator.SetBool("Move", false);
        femaleAnimator.SetBool("Move", false);
    }

    private void EnableGameOverAnim()
    {
        playerAnimator.SetBool("IsGameOver", true);
        femaleAnimator.SetBool("IsGameOver", true);
        maleAnimator.SetBool("IsGameOver", true);
    }

    private void EnableWinAnim()
    {
        int randReaction = Random.Range(0, 3);
        playerAnimator.SetFloat("Reaction", (float)randReaction);
        playerAnimator.SetBool("IsWinState", true);
    }

    private void EnableReactions(int type)
    {

        if (type == 0)
        {
            // play neg reactions
        }
            // play pos reaction
    }
}
