using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StageSelect : MonoBehaviour {

    int number = 0;

    private float Trigger;
    private float Trigger1;

    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor1;

    public bool DontDestroyEnabled = true;

//    void Quit()
//    {
//#if UNITY_EDITOR
//      UnityEditor.EditorApplication.isPlaying = false;
//#elif UNITY_STANDALONE
//      UnityEngine.Application.Quit();
//#endif
//    }

    void Update() {
        var ver = Input.GetAxis("Vertical");
        var hori = Input.GetAxis("Horizontal");

        // transformを取得
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;

        //up
        if (0 < Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.1f);

            number--;
            pos.y += 200;

            if (number < 0)
            {
                number = 1;
                pos.y -= 200;
            }
        }

        if (0 > Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.1f);

            number++;
            pos.y -= 200;

            if (number > 1)
            {
                number = 0;
                pos.y += 200;
            }
        }

        //if (0 < Input.GetAxisRaw("Horizontal") && Trigger1 == 0.0f){
        //    //音を鳴らす
        //    audioSource.PlayOneShot(Cursor1, 0.1f);

        //    if (number == 0 || number + 3  == 3)
        //    { 
        //        number += 2;
        //        pos.x += 3 * 295;
        //    }
        //}

        //if (0 > Input.GetAxisRaw("Horizontal") && Trigger1 == 0.0f){
        //    //音を鳴らす
        //    audioSource.PlayOneShot(Cursor1, 0.1f);

        //    if (number == 2 || number + 3 == 5)
        //    {
        //        number -= 2;
        //        pos.x -= 3 * 295;
        //    }
        //}

        myTransform.position = pos;  // 座標を設定

        Trigger = Input.GetAxisRaw("Vertical");//カーソルの移動速度制御
        Trigger1 = Input.GetAxisRaw("Horizontal");

        if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            switch(number){
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
}
