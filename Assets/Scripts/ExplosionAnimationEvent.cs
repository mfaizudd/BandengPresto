using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionAnimationEvent : MonoBehaviour
{
    public void OnExplosionEnd()
    {
        Destroy(gameObject);
    }
}
