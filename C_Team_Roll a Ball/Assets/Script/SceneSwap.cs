using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwap : MonoBehaviour{
    // Update is called once per frame
    public bool Swap;

    public bool DontDestroyEnabled = true;
    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;
    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor;

    private void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }

        Swap = false;

    }

    void Update(){


        if (Swap)
        {
            if (audioSource.isPlaying)
            {

            }
            else
            {
                Swap = false;
                SceneManager.LoadScene("Stage0");
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
            Swap = true;
            audioSource.PlayOneShot(Cursor, 0.2f); //音を鳴らす

        }


    }


}
