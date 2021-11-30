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

    private void Start()
    {
        if (DontDestroyEnabled)
        {
            // Sceneを遷移してもオブジェクトが消えないようにする
            DontDestroyOnLoad(this);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            audioSource.PlayOneShot(Cursor, 0.1f); //音を鳴らす
        }
    }
}
