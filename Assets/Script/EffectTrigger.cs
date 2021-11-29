using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke; //smokeに床に接地したら起動したいパーティクルを入れてOnTriggerEnterで起動する奴
    [SerializeField] private AudioSource moveBoll;

    void Start()
    {
        smoke.gameObject.SetActive(false);
        moveBoll.gameObject.SetActive(false);
    }


    void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag=="Ground") {
            smoke.gameObject.SetActive(true);
            moveBoll.gameObject.SetActive(true);
        }
    }
}
