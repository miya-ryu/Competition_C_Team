using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour {

    int number = 0;

    private float Trigger;

    public AudioClip sound1; //SE
    public AudioClip sound2;
    private AudioSource audioSource;

    void Start()
    {
        //Component を取得
        audioSource = GetComponent<AudioSource>();
    }

    void Quit()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }

    void Update() {
        var ver = Input.GetAxis("Vertical");

        // transformを取得
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;

        if (0 < Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(sound1);

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
            audioSource.PlayOneShot(sound1);

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

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            audioSource.PlayOneShot(sound2); //音を鳴らす

            switch (number)
            {
                case 0:
                    SceneManager.LoadScene("SampleScene");
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
