using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SerectSound : MonoBehaviour
{
    public bool DontDestroyEnabled = true;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor;

    GameObject Pc, Bt;
    PlayerController pc;
    ButtonFunction bt;

    private void Start()
    {
        Pc = GameObject.Find("Ball");
        pc = Pc.GetComponent<PlayerController>();
        Bt = GameObject.Find("Main Camera");
        bt = Bt.GetComponent<ButtonFunction>();
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        if (Time.deltaTime == 0 && (pc.retryUIInstance != null || bt.menuUIInstance != null))
        {
            SelectSound();
        }
    }

    void SelectSound()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioSource.PlayOneShot(Cursor, 0.1f); //音を鳴らす
        }
    }
}