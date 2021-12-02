using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedCap : MonoBehaviour
{
    private bool flg = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionStay(Collision hit)
    {
        if (hit.gameObject.tag == "Ground"&&flg==false)
        {
            StartCoroutine("CapFunc");
            flg = true;
        }
    }

    IEnumerator CapFunc()//フェード演出
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        while (true)
        {
            Vector3 accel = rb.velocity;
            if (Mathf.Abs(accel.x) > 10) { accel.x = 10; }
            //if (Mathf.Abs(accel.y) > 10) { accel.y = 10; }
            if (Mathf.Abs(accel.z) > 10) { accel.z = 10; }

            rb.velocity = accel;
            yield return StartCoroutine("TimeStop");
        }
        
    }

    //WaitFor系を使うと凄く遅くなったのが気に食わなかったのでtimescaleが0なら足止めする感じの関数を完了するまで止める風に実装
    IEnumerator TimeStop()
    {
        do { yield return null; } while (Time.timeScale == 0);
    }
}
