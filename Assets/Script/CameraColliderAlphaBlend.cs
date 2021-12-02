using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraColliderAlphaBlend : MonoBehaviour
{
    //つけるオブジェクトはvcameでもカメラでもどちらでもいいと思う

    [SerializeField] private GameObject sphere;
    [SerializeField] private LayerMask hit_layer;//ヒット判定を取るレイヤー

    [SerializeField] private int fade_in;//255-0までの時間
    [SerializeField] private int fade_out;//0-255の時間

    [SerializeField] private int min_alpha;//フェードインの透明度目標値、0-255で指定、0で透明、ここで指定した値ピッタリにはならない

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("MainLoop");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MainLoop()
    {
        List<RaycastHit> hit=new List<RaycastHit>(32);
        int alpha = 255 - min_alpha;//目標値
        while (true)
        {
            Vector3 line = sphere.transform.position - transform.position;
            Vector3 angle = line.normalized;
            Ray ray = new Ray(transform.position, angle);
            RaycastHit[] hit_base = Physics.RaycastAll(ray, line.magnitude, hit_layer);

            foreach(var child in hit_base) { hit.Add(child); }
            yield return StartCoroutine("TimeStop");//AlphaBlendに処理を回して重複チェックをしてもらう、その後リスト残ったraycasthitは新しい遮蔽物なのでコルーチン開始

            foreach (var child in hit) { StartCoroutine(ObjAlphaBlend(child)); }
            hit.Clear();

        }
        IEnumerator ObjAlphaBlend(RaycastHit obj)//透過処理
        {
            yield return StartCoroutine("TimeStop");//StartCorutine起動時に即座に消されないように
            int count = 0;
            Material origin = obj.transform.GetComponent<Renderer>().material;
            Material uniq_mat = new Material(origin);
            string obj_name = obj.transform.name;

            obj.transform.GetComponent<Renderer>().material = uniq_mat;//使用マテリアルを個別の物に変更
            while (true)
            {
                if (!DuplicateCheck(obj_name)) { break; }//自身がなかったら終了処理に移る

                if (count < fade_in) { uniq_mat.color = uniq_mat.color - new Color32(0, 0, 0, (byte)(alpha / fade_in)); }//透明度下げ
                count++;
                yield return StartCoroutine("TimeStop");
            }

            for(int i = 0; i < fade_out; i++) {
                DuplicateCheck(obj_name);//終了処理中に新しく透過を開始できてしまうと新しく開始した方のoriginがここで複製したマテリアルになり複製を消せなくなるのでこちらでも重複取り除き
                uniq_mat.color = uniq_mat.color + new Color32(0, 0, 0, (byte)(alpha / fade_out));//透明度戻し
                yield return StartCoroutine("TimeStop");
            }
            obj.transform.GetComponent<Renderer>().material = origin;//マテリアルを元に戻す
            Destroy(uniq_mat);
        }

        bool DuplicateCheck(string name){
            for (int i = 0; i < hit.Count; i++)
            {
                if (name == hit[i].transform.name)
                {//自身があった場合衝突し続けてると判断し、処理を続行
                    hit.RemoveAt(i);
                    return true;
                }
            }
            return false;
        }
    }

    IEnumerator TimeStop()
    {
        do { yield return null; } while (Time.timeScale == 0);
    }
}
