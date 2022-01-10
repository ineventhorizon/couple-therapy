using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIParticle : MonoBehaviour
{
    #region Singleton
    private static UIParticle instance;
    public static UIParticle Instance => instance ?? (instance = FindObjectOfType<UIParticle>());
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
    [SerializeField] ParticleSystem brokenHeart;
    [SerializeField] ParticleSystem heart;

    [SerializeField] private ParticleSystem[] gatePosParticles;
    [SerializeField] private ParticleSystem[] gateNegParticles;

    [SerializeField] private bool isParticlePlay;

    private void OnEnable()
    {
        Observer.PlayParticle += Play;
    }
    private void OnDisable()
    {
        Observer.PlayParticle -= Play;

    }
    public void Play(ParticleType type, int particleIndex)
    {
        switch (type)
        {
            case ParticleType.Gate:
                PlayGateParticle(particleIndex);
                break;
            case ParticleType.Collectable:
                PlayCollectableParticle(particleIndex);
                break;
        }
    }

    private void PlayGateParticle(int particleIndex)
    {
        if (particleIndex == (int)CollectableType.Positive)
        {
            var rand = Random.Range(0, gatePosParticles.Length - 1);
            gatePosParticles[rand].Play();

        }
        else
        {
            var rand = Random.Range(0, gateNegParticles.Length - 1);
            gateNegParticles[rand].Play();
        }
    }
    private void PlayCollectableParticle(int particleIndex)
    {
        if (particleIndex == (int)GateType.Positive)
        {
            heart.Play();
        }
        else
        {
            brokenHeart.Play();
        }
    }
}