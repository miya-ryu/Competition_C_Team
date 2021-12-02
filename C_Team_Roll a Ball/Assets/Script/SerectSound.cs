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

    GameObject Pc, Bt, Menu;
    PlayerController pc;
    ButtonFunction bt;
    MenuSelect menu;

    public bool soundflag;

    private void Start()
    {
        Pc = GameObject.Find("Ball");
        pc = Pc.GetComponent<PlayerController>();
        Bt = GameObject.Find("Main Camera");
        bt = Bt.GetComponent<ButtonFunction>();
        Menu = GameObject.Find("Change");
        menu = Menu.GetComponent<MenuSelect>();
        soundflag = false;
    }
    void Update()
    {
        if (Time.deltaTime == 0 && (pc.retryUIInstance || bt.menuUIInstance))
        {
            if (soundflag)
            {
                if (audioSource.isPlaying)
                {
                    soundflag = true;
                }
                else
                {
                    soundflag = false;
                }
            }
            else
            {
                soundflag = false;
                SelectSound();
            }
        }
    }
    void SelectSound()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioSource.PlayOneShot(Cursor, 0.1f); //音を鳴らす
            soundflag = true;
            menu.sceneflag = true;
        }
    }
}