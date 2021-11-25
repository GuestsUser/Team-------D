using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*  このスクリプトは特殊アイテムに入れるスクリプトです
    特殊アイテムを取得したときに特殊アイテムを消します
*/

public class TokusyuitemSakujo : MonoBehaviour
{
    private void OnTriggerEnter(Collider hit)
    {
       //gameObject.GetComponent<Ballspeedx2>();

        if (hit.CompareTag("Ball")){
             Destroy(gameObject);
        }

    }

}
