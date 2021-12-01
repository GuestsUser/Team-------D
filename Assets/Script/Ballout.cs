using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.UI;

public class Ballout : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private CinemachineVirtualCamera vCame;
    [SerializeField] private Camera came;

    [SerializeField] private int x_max;
    [SerializeField] private int x_min;
    [SerializeField] private int y_min;

    [SerializeField] private Image fade_img;//暗転に使うImageオブジェクト
    [SerializeField] private int fade_time;//暗転に掛ける時間
    [SerializeField] private int fade_stop_time;//暗転後リスタートまでの時間

    Vector3 ini_position;
    Color32 default_color;

    void Start()
    {
        default_color = new Color32(25, 0, 35, 0);//あんまり綺麗じゃないが透明度変更
        fade_img.material.color = default_color;

        //fade_img.material.color = new Color32(255,255,255,255);
        ini_position = ball.transform.position;

        StartCoroutine("MainLoop");
    }

    // Update is called once per frame
    void FixedUpdate(){}
    void PrefabCreate()
    {
        ball.GetComponent<BallSpeedDown>().check = false;//再出発時には特殊アイテム効果無効化
        ball.GetComponent<BallSpeedUp>().check = false;

        ball.GetComponent<Rigidbody>().velocity = Vector3.zero;
        ball.transform.position = ini_position;

        ball.GetComponent<EffectTrigger>().GetUseParticle().gameObject.SetActive(false);//砂ぼこりとSEの無効化
        ball.GetComponent<EffectTrigger>().GetUseSound().gameObject.SetActive(false);
    }


    IEnumerator MainLoop()
    {
        while(true){//updateではこういった書き方が有効ではないのでMainLoopコルーチンを用意した
            if (ball.transform.position.x > x_max || ball.transform.position.x < x_min || ball.transform.position.y < y_min) { 
                yield return StartCoroutine("RestartEffect");//フェード中こちらの実行を止める事でupdateで同じことをすると起こる毎フレーム条件を満たす事によるコルーチン大量開始を防ぐ
            }
            yield return StartCoroutine("TimeStop");
        }
        
    }

    IEnumerator RestartEffect()//フェード演出
    {
        Color32 fade_color = default_color;
        for (int i = 1; i < fade_time+1; i++)
        {
            fade_color.a = (byte)(255*Mathf.Sin(90f / fade_time * i * Mathf.Deg2Rad));
            fade_img.material.color = fade_color;
            yield return StartCoroutine("TimeStop");
        }

        for(int i = 0; i < fade_stop_time; i++) { yield return StartCoroutine("TimeStop"); }
        PrefabCreate();
        for (int i = 1; i < fade_time+1; i++)
        {
            fade_color.a = (byte)(255 * Mathf.Cos(90f / fade_time * i * Mathf.Deg2Rad));
            fade_img.material.color = fade_color;
            yield return StartCoroutine("TimeStop");
        }
    }

    //WaitFor系を使うと凄く遅くなったのが気に食わなかったのでtimescaleが0なら足止めする感じの関数を完了するまで止める風に実装
    IEnumerator TimeStop()
    {
        do { yield return null; } while (Time.timeScale == 0);
    }
}
