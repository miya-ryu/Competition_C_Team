using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text CountText;
    public float countdown = 5f;
    public int count;

    public bool CountFlag;

    GameObject go;
    PlayerController gg;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Countdown;
    [SerializeField] public AudioClip Hoissuru;

    public void Start()
    {
        CountFlag = false;
    }

    void Update()
    {
        if (countdown > 1 && CountFlag == false)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Countdown);

            Time.timeScale = 0f;
            countdown -= Time.unscaledDeltaTime;
            count = (int)countdown;
            CountText.text = count.ToString();
        }
        else if (CountText.text == "0" && CountFlag == false)
        {
            countdown -= Time.unscaledDeltaTime;
            CountText.text = "スタート！";
            countdown = 0f;
        }
        else if (CountText.text == "スタート！" && CountFlag == false)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Hoissuru);

            countdown -= Time.unscaledDeltaTime;
            if (-countdown >= 0.5f && CountFlag == false)
            {
                CountText.text = "";
                CountFlag = true;
                Time.timeScale = 1f;
            }
        }
    }
}