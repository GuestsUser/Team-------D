using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSE : MonoBehaviour
{
    Rigidbody rigid;
    AudioSource audio;
    public AudioClip move;

    float speed;
    public float speed_limit;
    public float volume;

    void Start()
    {
        rigid = GameObject.Find("Sphere").GetComponent<Rigidbody>();
        //アタッチされているAudioSource取得
        audio = GetComponent<AudioSource>();
    }

    void Update()
    {
        SoundVolume();
        audio.volume = volume;
    }

    void SoundVolume()
    {
        speed = rigid.velocity.magnitude;
        if (speed >= speed_limit)
        {
            volume = (speed - speed_limit);
        }
        else
        {
            while (volume >= 0) {
                volume--;
            }
        }
    }
}
