using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownSynchroBall : MonoBehaviour
{
    [SerializeField] private float time = 4;//Goも含めたカウントダウンにかける時間
    //ボールに付ける
    //スクリプト実行順はフレームレート設定->このスクリプトの順になってる
    // Start is called before the first frame update
    void Start()
    {
        int fix=Application.targetFrameRate;//fixedupdate数値
        float gravity = Physics.gravity.y;//今回は下に掛かる力だけ取得

        float pos_y = 0;//位置、forを抜けた時のこの値が現在の重力ならカウントダウン0で床に付くyの値
        float force = 0;//力の状況を記憶

        Debug.Log(fix);
        for(int i = 0; i < fix * time; i++) {
            force += gravity / fix;
            pos_y += force / fix;
        }

        transform.position = new Vector3(transform.position.x, pos_y*-1 , transform.position.z);
    }


}
