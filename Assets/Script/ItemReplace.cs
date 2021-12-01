using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//現在は不要という事で最初から床に傾きがあった場合配置が床に接地しない、必要があれば初期角度による配置も追記する
public class ItemReplace : MonoBehaviour
{
    [SerializeField] private GameObject panel;//床
    // Start is called before the first frame update
    void Start()
    {
        Vector3 panel_scale = panel.transform.localScale;
        for (int i = 0; i < transform.childCount; i++)
        {
            Vector3 obj_posi=transform.GetChild(i).transform.position;
            transform.GetChild(i).transform.position = new Vector3(obj_posi.x*panel_scale.x, obj_posi.y, obj_posi.z * panel_scale.z);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}
