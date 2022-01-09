using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Observer
{
    public static UnityAction<float> updateLove;
    public static UnityAction startPlayerMovement;
    public static UnityAction startGame;
    public static UnityAction playerFinalWalk;
    public static UnityAction coupleFinalWalk;
    public static UnityAction<Vector3> finalMoveTowards;
    public static UnityAction<ParticleType, int> PlayParticle;
}
