using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    private int number = 0;

    private float Trigger;

    public bool Select;
    public bool DontDestroyEnabled = true;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;
    
    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor1;
    [SerializeField] public AudioClip Cursor2;

    public bool stageflag = true;

    private void Start()
    {
        stageflag = true;
    }

    void Update()
    {
        var hori = Input.GetAxis("Horizontal");

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        if (stageflag)
        {
            //右
            if (0 < Input.GetAxisRaw("Horizontal") && Trigger == 0.0f)
            {
                //音を鳴らす
                audioSource.PlayOneShot(Cursor1, 0.1f);
                number++;
                pos.x += 270;

                if (number > 3)
                {
                    number -= 4;
                    pos.x -= 4 * 270;
                }
            }
            //左
            else if (0 > Input.GetAxisRaw("Horizontal") && Trigger == 0.0f)
            {
                //音を鳴らす
                audioSource.PlayOneShot(Cursor1, 0.1f);
                number--;
                pos.x -= 270;
                if (number < 0)
                {
                    number += 4;
                    pos.x += 4 * 270;
                }
            }
            myTransform.position = pos;  // 座標を設定
            Trigger = Input.GetAxisRaw("Horizontal");
        }

        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            stageflag = false;
            audioSource.PlayOneShot(Cursor2, 0.2f); //音を鳴らす
            if (stageflag == false)
            {
                Invoke("Call", 0.6f);
            }
        }
    }
    void Call()
    {
        switch (number)
        {
            case 0:
                SceneManager.LoadScene("Stage0");
                break;
            case 1:
                SceneManager.LoadScene("Stage1");
                break;
            case 2:
                SceneManager.LoadScene("Stage2");
                break;
            case 3:
                SceneManager.LoadScene("Stage3");
                break;
        }
        stageflag = true;
    }
}