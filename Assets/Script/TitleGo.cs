using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleGo : MonoBehaviour
{
    public void replay()
    {
        // LoadSceneの引数にシーンの名前を入れて読み込む
        SceneManager.LoadScene("Title");
        Time.timeScale = 1f;
    }
    public void replay2()
    {
        // LoadSceneの引数にシーンの名前を入れて読み込む
        SceneManager.LoadScene("Stage2");
        Time.timeScale = 1f;
    }
    public void replay01()
    {
        // LoadSceneの引数にシーンの名前を入れて読み込む
        SceneManager.LoadScene("GameMain");
        Time.timeScale = 1f;
    }
   
}
