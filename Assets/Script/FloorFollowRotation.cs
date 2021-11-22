using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//付けたオブジェクトの回転を床の回転と同期する
public class FloorFollowRotation : MonoBehaviour
{
    [SerializeField] private GameObject panel;//床オブジェクト
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = panel.transform.rotation;
    }
}
