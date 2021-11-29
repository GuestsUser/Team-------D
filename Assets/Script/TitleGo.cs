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
    }
    public void replay2()
    {
        // LoadSceneの引数にシーンの名前を入れて読み込む
        SceneManager.LoadScene("Stage2");
    }
    public void replay01()
    {
        // LoadSceneの引数にシーンの名前を入れて読み込む
        SceneManager.LoadScene("GameMain");
    }
}
