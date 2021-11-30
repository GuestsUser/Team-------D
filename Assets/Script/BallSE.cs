using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSE : MonoBehaviour
{
    [SerializeField]
    private ParticleSystem _particleSystem;

    AudioSource audioSource;
    public AudioClip move;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        var particleCount = _particleSystem.particleCount;
        if (particleCount == 0)
        {
            Debug.Log($"粒子が出ていません");
            return;
        }

        //各粒子を取得
        ParticleSystem.Particle[] particles = new ParticleSystem.Particle[particleCount];
        _particleSystem.GetParticles(particles);

        //1個目の粒子の座標取得、ワールド座標に変換
        var particleLocalPosition = particles[0].position;
        var particleWorldPosition = _particleSystem.transform.TransformPoint(particleLocalPosition);

        //1個目のパーティクルのワールド座標表示
        Debug.Log($"1個目の粒子の座標 {particleWorldPosition}");
    }

}
