using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GateText", menuName = "ScriptableObjects/ParticleData", order = 1)]
public class ParticleData : ScriptableObject
{
    public ParticleSystem[] gatePosParticles;
    public ParticleSystem[] gateNegParticles;

    public ParticleSystem heart;
    public ParticleSystem brokenHeart;

}
