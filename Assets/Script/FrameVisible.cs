using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameVisible : MonoBehaviour
{
    private string st= "FixedUpdate:";//"FPS:x"のFPS部分
    private float local_time = 0f;
    private int frame_count = 0;
    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        local_time += Time.deltaTime;
        frame_count++;
        if (local_time >= 1) {
            GetComponent<Text>().text =st+frame_count;
            local_time -= 1;
            frame_count = 0;
        }
    }
}
