using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SerectSound : MonoBehaviour
{
    public bool DontDestroyEnabled = true;
    // 使用する AudioSource をアタッチ
    [SerializeField] public AudioSource audioSource = null;
    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor;
<<<<<<< HEAD

=======
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
    GameObject Pc, Bt, Menu;
    PlayerController pc;
    ButtonFunction bt;
    MenuSelect menu;
<<<<<<< HEAD


    public bool soundflag;

    private void Start()
    {

=======
    public bool soundflag;
    private void Start()
    {
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
        Pc = GameObject.Find("Ball");
        pc = Pc.GetComponent<PlayerController>();
        Bt = GameObject.Find("Main Camera");
        bt = Bt.GetComponent<ButtonFunction>();
<<<<<<< HEAD
        Menu = GameObject.Find("Change");
        menu = Menu.GetComponent<MenuSelect>();


        soundflag = false;

=======
        Menu = GameObject.Find("Change1");
        menu = Menu.GetComponent<MenuSelect>();
        soundflag = false;
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }
    void Update()
    {
<<<<<<< HEAD

        if (Time.deltaTime == 0 && (pc.retryUIInstance || bt.menuUIInstance ))
        {
            if (soundflag)
            {

=======
        if (Time.deltaTime == 0 && (pc.retryUIInstance || bt.menuUIInstance))
        {
            if (soundflag)
            {
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
                if (audioSource.isPlaying)
                {
                    soundflag = true;
                }
                else
                {
                    soundflag = false;
                }
<<<<<<< HEAD

=======
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
            }
            else
            {
                soundflag = false;
                SelectSound();
            }
<<<<<<< HEAD

        }


    }

    void SelectSound()
    {

=======
        }
    }
    void SelectSound()
    {
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioSource.PlayOneShot(Cursor, 0.1f); //音を鳴らす
            soundflag = true;
            menu.sceneflag = true;
        }
<<<<<<< HEAD


    }

=======
    }
>>>>>>> 2ed9ad0429bf089cf429d3413200390ceddd7840
}