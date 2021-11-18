using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Timer : MonoBehaviour
{
    public Text CountText;
    public float countdown = 5f;
    public int count;

    public bool CountFlag;
    public bool CountFlag2;

    GameObject go;
    PlayerController gg;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Countdown;

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
            if(count.ToString() != "0")
            {
                CountText.text = count.ToString();
            }
            else
            {
                CountText.text = "";
            }
        }
        else if (CountText.text == "" && CountFlag == false)
        {
            countdown -= Time.unscaledDeltaTime;
            CountText.text = "スタート！";
        }
        else if (CountText.text == "スタート！" && CountFlag == false)
        {
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