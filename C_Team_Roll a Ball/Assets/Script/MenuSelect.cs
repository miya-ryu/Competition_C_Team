using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour
{
    int number = 0;
    private float Trigger;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor1;
    [SerializeField] public AudioClip Cursor2;

    public bool DontDestroyEnabled = true;
    public bool audioflag = false;

    void Quit()
    {
        if (audioflag)
        {
        }
        else
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
        }
    }

    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        if (0 < Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.2f);
            number--;
            pos.y += 45;
            if (number < 0)
            {
                number = 2;
                pos.y -= 3 * 45;
            }
        }
        if (0 > Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.2f);
            number++;
            pos.y -= 45;
            if (number > 2)
            {
                number = 0;
                pos.y += 3 * 45;
            }
        }

        myTransform.position = pos;  // 座標を設定
        Trigger = Input.GetAxisRaw("Vertical"); //カーソルの移動速度制御

        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioflag = true;
            if (audioflag)
            {
                if (audioSource.isPlaying)
                {
                    audioflag = true;
                }
                else
                {
                    audioSource.PlayOneShot(Cursor2, 0.2f); //音を鳴らす
                    audioflag = false;
                }
            }
            if (SceneManager.GetActiveScene().name == "Stage0")
            {
                switch (number)
                {
                    case 0:
                        SceneManager.LoadScene("Stage0");
                        break;
                    case 1:
                        SceneManager.LoadScene("Menu");
                        break;
                    case 2:
                        Quit();
                        break;
                }
            }
            if (SceneManager.GetActiveScene().name == "Stage1")
            {
                switch (number)
                {
                    case 0:
                        SceneManager.LoadScene("Stage1");
                        break;
                    case 1:
                        SceneManager.LoadScene("Menu");
                        break;
                    case 2:
                        Quit();
                        break;
                }
            }
            if (SceneManager.GetActiveScene().name == "Stage2")
            {
                switch (number)
                {
                    case 0:
                        SceneManager.LoadScene("Stage2");
                        break;
                    case 1:
                        SceneManager.LoadScene("Menu");
                        break;
                    case 2:
                        Quit();
                        break;
                }
            }
            if (SceneManager.GetActiveScene().name == "Stage3")
            {
                switch (number)
                {
                    case 0:
                        SceneManager.LoadScene("Stage3");
                        break;
                    case 1:
                        SceneManager.LoadScene("Menu");
                        break;
                    case 2:
                        Quit();
                        break;
                }
            }
        }
    }
}