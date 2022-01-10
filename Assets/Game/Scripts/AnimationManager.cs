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
        Observer.startAnimation += EnableInGameAnimation;
    }
    private void OnDisable()
    {
        Observer.startAnimation -= DisableInGameAnimation;
    }
    private void EnableInGameAnimation()
    {
        playerAnimator = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
        maleAnimator = GameObject.FindGameObjectWithTag("Male").GetComponent<Animator>();
        femaleAnimator = GameObject.FindGameObjectWithTag("Female").GetComponent<Animator>();
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

        femaleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, 90f, 0), 0.7f);
        maleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, -90f, 0), 0.7f);

        maleAnimator.SetBool("IsGameOver", true);
        femaleAnimator.SetBool("IsGameOver", true);

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

    public void EnableCoupleWinAnim()
    {
        femaleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, 80f, 0), 0.7f);
        maleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, -80f, 0), 0.7f);

        femaleAnimator.SetBool("IsWinState", true);
        maleAnimator.SetBool("IsWinState", true);
    }
    public void EnableReactions(GateType type)
    {
        femaleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, 45f, 0), 0.7f);
        maleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, -45f, 0), 0.7f);

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

        femaleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, 10, 0), 0.7f);
        maleAnimator.gameObject.transform.rotation = Quaternion.Lerp(femaleAnimator.gameObject.transform.rotation, Quaternion.Euler(0, -10, 0), 0.7f);

    }
}
