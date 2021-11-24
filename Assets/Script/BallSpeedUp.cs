using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedUp : MonoBehaviour
{
    [SerializeField] private int limit; //ボールが早くなっている時間 
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tokusyuitem"))
        {
            StartCoroutine("Speedup");
        }
    }

    IEnumerator Speedup()
    {
        Vector3 oldposition= transform.position; 
        for (int i = 0; i < limit; i++)
        {
            Vector3 nowmovement;

            nowmovement = transform.position-oldposition;

            transform.position += nowmovement;
            oldposition = transform.position;

            yield return null;
        }
        Debug.Log("終了");
        
    }
}
