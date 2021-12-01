using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour
{
    int number = 0;

    private float Trigger;
    private float Trigger1;

    public bool Select;
    public bool DontDestroyEnabled = true;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;
    
    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor1;
    [SerializeField] public AudioClip Cursor2;

    private void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
        Select = false;
    }

    void Update()
    {   
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        //右
        if (0 < Input.GetAxisRaw("Horizontal") && Trigger1 == 0.0f)
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
        if (0 > Input.GetAxisRaw("Horizontal") && Trigger1 == 0.0f)
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
        Trigger1 = Input.GetAxisRaw("Horizontal");
        
        if (Select)
        {
            if (audioSource.isPlaying)
            {
            }
            else
            {
                Select = false;

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
            }
        }
        else
        {
            SelectSound();
        }
    }

    void SelectSound()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Select = true;
            audioSource.PlayOneShot(Cursor2, 0.1f); //音を鳴らす
        }
    }
}