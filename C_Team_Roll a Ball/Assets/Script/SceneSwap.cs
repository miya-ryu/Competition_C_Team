using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

<<<<<<< HEAD
public class SceneSwap : MonoBehaviour{
    // Update is called once per frame
    public bool Swap;

    public bool DontDestroyEnabled = true;
    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;
=======
public class SceneSwap : MonoBehaviour
{
    public bool Swap;
    public bool DontDestroyEnabled = true;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor;

    private void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
<<<<<<< HEAD
            //DontDestroyOnLoad(this);
        }

        Swap = false;

    }

    void Update(){


=======
            DontDestroyOnLoad(this);
        }
        Swap = false;
    }

    void Update()
    {
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
        if (Swap)
        {
            if (audioSource.isPlaying)
            {
<<<<<<< HEAD

=======
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
            }
            else
            {
                Swap = false;
<<<<<<< HEAD
                SceneManager.LoadScene("Stage0");
            }

        }
        else
        {

            SelectSound();

=======
                SceneManager.LoadScene("StageSelect");
            }
        }
        else
        {
            SelectSound();
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
        }
    }

    void SelectSound()
    {
<<<<<<< HEAD

        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Swap = true;
            audioSource.PlayOneShot(Cursor, 0.2f); //音を鳴らす

        }


    }


}
=======
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            Swap = true;
            audioSource.PlayOneShot(Cursor, 0.1f); //音を鳴らす
        }
    }
}
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
