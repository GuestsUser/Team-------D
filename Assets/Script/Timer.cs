using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class Timer : MonoBehaviour
{
    [SerializeField]
    private Text _textCountdown;
    [SerializeField]
    private Text _textTimer;

    //[SerializeField] 
    private AudioClip audiosource;

    void Start()
    {
        _textCountdown.text = "";
        //gameObject.GetComponent<AudioSource>().PlayOneShot(audiosource);
        StartCoroutine(CountdownCoroutine());
    }

    public void OnClickButtonStart()
    {
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        GameObject inputObj = GameObject.Find("UI_pause");
        UI_pause inputScript = inputObj.GetComponent<UI_pause>();
        inputScript.enabled = false;
        _textCountdown.gameObject.SetActive(true);

        _textCountdown.text = "";
       // Time.timeScale = 0;


        _textCountdown.text = "3";
        
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "2";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "1";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "GO!";
        yield return new WaitForSeconds(1.0f);

        _textCountdown.text = "";
        inputScript.enabled = true;
        Time.timeScale = 1f;
        _textCountdown.gameObject.SetActive(false);
        _textTimer.gameObject.SetActive(true);
        //audiosource = gameObject.GetComponent<AudioSource>();
    }

  public   void OnEnable()
    {
        //Time.timeScale = 0f;
    }
   public  void OnDisable()
    {
        Time.timeScale = 1f;
    }

}
