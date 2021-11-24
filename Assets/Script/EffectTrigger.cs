using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTrigger : MonoBehaviour
{
    [SerializeField] private ParticleSystem smoke; //smokeに床に接地したら起動したいパーティクルを入れてOnTriggerEnterで起動する奴
    private bool flg=true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter(Collision hit)
    {
        if (hit.gameObject.tag=="Ground"&&flg) {
            smoke.gameObject.SetActive(true);
            flg = false;
        }
    }
}
