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

    int elapsedtime=0;
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
                StopAllCoroutines();
                //sbup = null;
                check = false;
                elapsedtime = 0;
            }
            
        }
        if (other.CompareTag("Tokusyuitem"))
        {

            if (check == false)
            {
                StartCoroutine("Speedup");

            }
            else
            {
                this.GetComponent<Renderer>().material = speedcolor;
                elapsedtime = 0;
            }
        }
        
    }

    IEnumerator Speedup()
    {
        check= true;
        Vector3 oldposition= transform.position;

        this.GetComponent<Renderer>().material = speedcolor;

        for ( elapsedtime = 0; elapsedtime < limit; elapsedtime++)
        {
            if (elapsedtime > blinking)
            {
                if (elapsedtime % tenmetu == 0)
                {
                    if (elapsedtime % 2 == 0)
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
        elapsedtime = 0;
        Debug.Log("終了");
        check = false;
        this.GetComponent<Renderer>().material = nowcolor;
    }
    IEnumerator TimeStop()
    {
        do { yield return null; } while (Time.timeScale == 0);
    }
}
