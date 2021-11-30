using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke; //smokeに床に接地したら起動したいパーティクルを入れてOnTriggerEnterで起動する奴
    [SerializeField] private AudioSource sound;
    private bool flg = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag=="Ground" && flg == false) {
            smoke.gameObject.SetActive(true);
            sound.gameObject.SetActive(true);
            flg = false;
        }
    }
}
