using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSpeedDown : MonoBehaviour
{
    [SerializeField] private int limit = 120; //ボールが遅くなっている時間 

    [SerializeField] private Material speedcolor;   //遅くなっているときのボールの色

    [SerializeField] private int blinking = 90;   //点滅し始める時間

    [SerializeField] private int tenmetu = 5;    //点滅する間隔

    private Material nowcolor;

    IEnumerator sbdw;

    [HideInInspector] public bool check = false;     //コルーチンが実行されているかいないかをチェック

    int elapsedtime =0 ;
    // Start is called before the first frame update
    void Start()
    {
        sbdw = SpeedDown();
        nowcolor = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tokusyuitem"))
        {
            if (check)
            {
                StopAllCoroutines();
                //sbdw = null;
                check = false;
                elapsedtime = 0;
            }
        }
        if (other.CompareTag("Ojamamusi"))
        {
            
            if (check == false)
            {
                StartCoroutine("SpeedDown");

            }
            else
            {
                this.GetComponent<Renderer>().material = speedcolor;
                elapsedtime = 0;
            }
        }
    }

    IEnumerator SpeedDown()
    {
        check = true;
        Vector3 oldposition = transform.position;;

        this.GetComponent<Renderer>().material = speedcolor;

        for (elapsedtime = 0; elapsedtime < limit; elapsedtime++)
        {
            if (!check) { break; }//checkが外部からfalseにされた場合強制終了
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

            nowmovement = transform.position - oldposition;

            transform.position -= nowmovement/2;
            oldposition = transform.position;

            yield return StartCoroutine("TimeStop");
        }
        elapsedtime = 0;
        check = false;
        Debug.Log("終了");
        this.GetComponent<Renderer>().material = nowcolor;
    }
    IEnumerator TimeStop()
    {
        do { yield return null; } while (Time.timeScale == 0);
    }
}