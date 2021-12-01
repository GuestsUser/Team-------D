using UnityEngine;
using UnityEngine.UI; // 追加
using UnityEngine.SceneManagement;

class Clear2 : MonoBehaviour
{
    private AudioSource audioSource; // オーディオソース
    public AudioClip clearSound;
    public GameObject clearUI;
    public Text gameClearMessage; // 追加
    Transform myTransform;
    bool clearsound = false;
    private float step_time = 0;
    public ParticleSystem particle;
    private const int PARTICLE_LIMIT = 600;
    private int particle_limit = 0;

    void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        myTransform = transform;

    }

    void Update()
    {

        if (myTransform.childCount == 0)

        {

            if (Input.GetKeyDown("joystick button 0"))
            {
                SceneManager.LoadScene("result2");
            }

            if (!clearsound)
            {
                gameClearMessage.text = "Game Clear!  Aキーを押してください"; // 追加
                Time.timeScale = 0f;
                audioSource.Play();
                clearsound = true;

                clearUI.SetActive(false);
                Time.timeScale = 0f;
            }
            particle_limit++;
            if (particle_limit > 0 && particle_limit <= PARTICLE_LIMIT)
            {
                particle.Simulate(Time.unscaledDeltaTime, true, false);
            }
        }
    }

}
