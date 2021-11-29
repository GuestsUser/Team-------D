using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Reset : MonoBehaviour
{
   
    public void replay(int num)
    {
        Time.timeScale = 1f;
        switch (num)
        {
            case 0: SceneManager.LoadScene("GameMain"); break;
            case 1: SceneManager.LoadScene("Stage2"); break;
        }
        
    }
    public void select()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("select");
    }

    // Update is called once per frame
    void Update()
    {
        //Time.timeScale = 1f;
    }
}
