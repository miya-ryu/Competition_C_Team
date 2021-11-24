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
    public Text ResultGuide;
    private Rigidbody rb; // Rididbody

    public int score; // スコア
    public int scoreMax;

    public static float CountTime;
    public static float CountTimeM;
    public static float ResultTime;

    [SerializeField] GameObject resultPanel = null;

    public GameObject retryUIPrefab;
    public GameObject retryUIInstance;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Item;
    [SerializeField] public AudioClip Speed;

    // Particle のオブジェクト
    [SerializeField] public GameObject particle;
    float particletime;

    public float turboforce = 1f;
    public float turbotime;
    public float turbomax = 7.5f;
    bool turboflag;
    Vector3 turbo;

    //トゲトゲのオブジェクト
    float enemyTime;
    public float enemyTimer = 10f;
    bool enemy;

    public GameObject Panel;

    void Start()
    {
        //SE の Component を取得
        audioSource = GetComponent<AudioSource>();
        
        // Rigidbody を取得
        rb = GetComponent<Rigidbody>();
        
        resultPanel.SetActive(false);
        
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
        ResultGuide.text = "";

        // Particle の取得と非表示
        particle = GameObject.Find("Paper");
        particle.SetActive(false);
        particletime = 0;
        turbotime = 0;
        turboflag = false;

        //トゲトゲのオブジェクト
        enemyTime = enemyTimer;
        enemy = false;
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

        if (turboflag)
        {
            turbotime += Time.deltaTime;
            if (turbotime >= turbomax && turboflag)
            {
                turbo = rb.velocity;
                rb.velocity = new Vector3(turbo.x / turboforce, turbo.y / turboforce, turbo.z / turboforce);
                turbotime = 0;
                turboflag = false;
            }
        }

        if (enemy == true)
        {
            if (enemyTime > 0)
            {
                Debug.Log(enemyTime);
                rb.velocity = Vector3.zero;
                enemyTime -= Time.deltaTime;
            }
            else if (enemyTime < 0)
            {
                enemy = false;
                enemyTime = enemyTimer;
            }
        }
    }
    
    // 玉が他のオブジェクトにぶつかった時に呼び出される
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Item"))
        {
            //音を鳴らす(sound1)
            audioSource.PlayOneShot(Item, 0.3f);

            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);
            
            // スコアを加算します
            score = score + 1;
            
            // UI の表示を更新します
            SetCountText();
        }

        //ぶつかったオブジェクトがターボアイテムだった場合
        if (other.gameObject.CompareTag("TurboItem"))
        {
            //音を鳴らす(sound1)
            audioSource.PlayOneShot(Speed, 0.3f);

            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            turbotime = 0;
            turbo = rb.velocity;
            turboflag = true;
            rb.velocity = new Vector3(turbo.x * turboforce, turbo.y * turboforce, turbo.z * turboforce);
        }

        //ぶつかったオブジェクトがエネミーだった場合
        if (other.gameObject.CompareTag("enemy"))
        {
            enemy = true;
            other.gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (score >= scoreMax)
        {
            ResultTime += Time.unscaledDeltaTime;

            if (particle.GetComponent<ParticleSystem>().isPlaying)
            {
                particletime += Time.unscaledDeltaTime;
                if (particletime >= 10f)
                {
                    particle.GetComponent<ParticleSystem>().Stop();
                }
            }

            if (ResultTime >= 1f)
            {
                resultPanel.SetActive(true);
                ResultTime = 1f;
                ResultText.text = "ゲームリザルト";
                ResultScore.text = "取得したコイン　" + score.ToString() + "枚";
                PlayCount.text = "かかった時間 ";
                CountTimeText.text = CountTimeM.ToString("F0") + ":" + CountTime.ToString("F0");
                ClearText.text = "";
                scoreText.text = "";
                ResultGuide.text = "～B or X ボタンを押してください～";
                if ((Input.GetKeyUp(KeyCode.JoystickButton1)) || (Input.GetKeyUp(KeyCode.JoystickButton2)))
                {
                    retryUIInstance = GameObject.Instantiate(retryUIPrefab) as GameObject;
                    if (Input.GetKeyDown(KeyCode.JoystickButton1) || (Input.GetKeyDown(KeyCode.JoystickButton2)))
                    {
                        Destroy(retryUIInstance);
                    }
                }
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

            particle.transform.position = new Vector3(0, 14, 0);
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Play();

            // リザルトの表示を更新
            ClearText.text = "ゲームクリア！";
        }
    }
}