using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {//fixedupdateの値を60に固定
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
