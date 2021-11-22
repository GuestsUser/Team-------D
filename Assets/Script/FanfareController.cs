using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanfareController : MonoBehaviour
{
    ParticleSystem fan;

    void Start()
    {
        fan = this.GetComponent<ParticleSystem>();
    }

    void Update()
    {
        if (fan.isStopped)
        {
        }
    }
}
