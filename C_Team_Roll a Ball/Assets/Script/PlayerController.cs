using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    ButtonFunction gg;

    public float speed; // 動く速さ

    public Text scoreText; // スコアの UI
    public Text ClearText; // リザルトの UI
    public Text ResultText;
    public Text PlayCount;
    public Text CountTimeText;
    public Text ResultScore;

    private Rigidbody rb; // Rididbody

    public int score; // スコア
    public int scoreMax;

    public static float CountTime;
    public static float CountTimeM;
    public static float ResultTime;

    [SerializeField] AudioSource audioSource;

    [SerializeField] AudioClip sound1;
    [SerializeField] AudioClip sound2;

    void Start()
    {
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();

        // UI を初期化
        score = 0;
        CountTime = 0;
        CountTimeM = 0;
        ResultTime = 0;
        SetCountText();
        ClearText.text = "";
        ResultText.text = "";
        ResultScore.text = "";
        PlayCount.text = "";
        CountTimeText.text = "";
    }

    void FixedUpdate()
    {
        if (CountTime >= 60f)
        {
            CountTime = 0;
            CountTimeM++;
        }
        else
        {
            CountTime += Time.deltaTime;
        }
    }

    // 玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            //音を鳴らす(sound1)
            audioSource.PlayOneShot(sound1);

            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            // スコアを加算します
            score = score + 1;

            // UI の表示を更新します
            SetCountText();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            audioSource.PlayOneShot(sound2);
        }
    }

    void Update()
    {
        if (score >= scoreMax)
        {
            ResultTime += Time.unscaledDeltaTime;
            if (ResultTime >= 1f)
            {
                ResultTime = 1f;
                ResultText.text = "ゲームリザルト";
                ResultScore.text = "獲得したコイン　" + score.ToString() + "枚";
                PlayCount.text = "かかった時間 ";
                CountTimeText.text = CountTimeM.ToString("F0") + ":" + CountTime.ToString("F0");
                ClearText.text = "";
                scoreText.text = "";
            }
        }
    }

    // UI の表示を更新する
    void SetCountText()
    {
        // スコアの表示を更新
        scoreText.text = score.ToString() + "/" + scoreMax.ToString();

        // すべての収集アイテムを獲得した場合
        if (score >= scoreMax)
        {
            Time.timeScale = 0f;

            // リザルトの表示を更新
            ClearText.text = "GAME CLEAR!";
        }
    }
}