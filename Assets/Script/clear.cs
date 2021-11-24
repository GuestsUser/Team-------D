using UnityEngine;
using UnityEngine.UI; // 追加
using UnityEngine.SceneManagement;

class clear : MonoBehaviour
{
    private AudioSource audioSource; // オーディオソース
    public AudioClip clearSound;
    public GameObject clearUI;
    public Text gameClearMessage; // 追加
    Transform myTransform;
    bool clearsound = false;
    private float step_time = 0;
    public ParticleSystem fan;
    private const int DISPLAY_FRAME = 600;
    private int displayFrame = DISPLAY_FRAME;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        myTransform = transform;
       
    }

    void Update()
    {

        if (myTransform.childCount == 0)
            
        {

            if (Input.GetKeyDown("joystick button 2"))
            {
                SceneManager.LoadScene("result");
            }

            if (!clearsound)
            {
                gameClearMessage.text = "Game Clear!  Xキーを押してください"; // 追加
                Time.timeScale = 0f;
                audioSource.Play();
                clearsound = true;
                //Particle();
                if (--displayFrame >= 0) {
                   Debug.Log("おめでと");
                    fan.Simulate(Time.unscaledDeltaTime, true, false);
                }
                clearUI.SetActive(false);
                Time.timeScale = 0f;
            }           
        }
    }

    //void Particle()
    //{
    //}
}
