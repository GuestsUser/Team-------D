using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BallSpeedUp : MonoBehaviour
{
    [SerializeField] private int limit=450; //ボールが早くなっている時間 

    [SerializeField] private Material speedcolor;   //早くなっているときのボールの色

    [SerializeField] private int blinking=330;   //点滅し始める時間

    [SerializeField] private int tenmetu=5;    //点滅する間隔

    private Material nowcolor;

    IEnumerator sbup;

    bool check=false;     //コルーチンが実行されているかいないかをチェック

    // Start is called before the first frame update
    void Start()
    {
        nowcolor = GetComponent<Renderer>().material;
       
        sbup = Speedup();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ojamamusi"))
        {
            if (check)
            {
                StopCoroutine(sbup);
                sbup = null;
                check = false;
            }
            
        }
        if (other.CompareTag("Tokusyuitem"))
        {
            StartCoroutine(sbup);

        }
    }

    IEnumerator Speedup()
    {
        check= true;
        Vector3 oldposition= transform.position;

        this.GetComponent<Renderer>().material = speedcolor;

        for (int i = 0; i < limit; i++)
        {
            if (i > blinking)
            {
                if (i % tenmetu == 0)
                {
                    if (i % 2 == 0)
                    {
                        this.GetComponent<Renderer>().material = nowcolor;
                    }
                    else
                    {
                        this.GetComponent<Renderer>().material = speedcolor;
                    }
                    
                }
            }
            Vector3 nowmovement;

            nowmovement = transform.position-oldposition;

            transform.position += nowmovement;
            oldposition = transform.position;

            yield return StartCoroutine("TimeStop");
        }
        Debug.Log("終了");
        check = false;
        this.GetComponent<Renderer>().material = nowcolor;
    }
    IEnumerator TimeStop()
    {
        do { yield return null; } while (Time.timeScale == 0);
    }
}
