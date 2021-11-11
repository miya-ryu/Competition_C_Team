﻿using System.Collections;
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
    public Text Button;
    public Text PlayCount;
    public Text CountTimeText;
    public Text ResultScore;
    private Rigidbody rb; // Rididbody

    public int score; // スコア
    public int scoreMax;
    
    public static float CountTime;
    public static float CountTimeM;
    public static float ResultTime;
    [SerializeField] GameObject resultPanel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] public AudioClip Item; //SE
    [SerializeField] public AudioClip Wall; //SE

    public GameObject retryUIPrefab;
    public GameObject retryUIInstance;
    
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
            audioSource.PlayOneShot(Item);
            
            // その収集アイテムを非表示にします
            other.gameObject.SetActive(false);
            
            // スコアを加算します
            score = score + 1;
            
            // UI の表示を更新します
            SetCountText();
        }
    }
    
    void Update()
    {
        if (score >= scoreMax)
        {
            ResultTime += Time.unscaledDeltaTime;
            if (ResultTime >= 1f)
            {
                resultPanel.SetActive(true);
                ResultTime = 1f;
                ResultText.text = "ゲームリザルト";
                ResultScore.text = "獲得したコイン　" + score.ToString() + "枚";
                PlayCount.text = "かかった時間 ";
                CountTimeText.text = CountTimeM.ToString("F0") + ":" + CountTime.ToString("F0");
                ClearText.text = "";
                scoreText.text = "";
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

            // リザルトの表示を更新
            ClearText.text = "GAME CLEAR!";
        }
    }
}