using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class StageSelect : MonoBehaviour
{
    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Cursor1;
    [SerializeField] public AudioClip Cursor2;

    public int number = 0;

    private float Trigger;
    private float Triggerx;

    public GameObject[] stage;
    int botanx,botany;
    private Transform stageposition;
    // Start is called before the first frame update
    void Start()
    {

        botanx = botany = 1;

    }

    // Update is called once per frame
    void Update()
    {
        var hori = Input.GetAxisRaw("Horizontal");
        var ver = Input.GetAxisRaw("Vertical");
        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;
        if (0 < ver && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.2f);
            botany--;
            //number = botany + botanx;
            //pos.y += 309;
            pos.y = 309*botany;
            if (botany < 1)
            {
                botany = 2;
            }

            //if (number < 0 || botany < 0)
            //{
            //    botany = 0;
            //    number = botanx+botany;
            //    pos.y = -313;
            //}
            //if (pos.y < -4)
            //{

            //    pos.y = -313; 

            //}
        }

        if (0 > ver && Trigger == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.2f);
            botany++;
            //number = botany + botanx;
            //pos.y -= 309;
            pos.y = 309*botany;

            if (botany > 2)
            {
                botany = 1;
            }

            //if (number >= 3 && botany > 1)
            //{
            //    botany = 0;
            //    number = botany;
            //    pos.y = -4;
            //}
            //if (pos.y > -313)
            //{

            //    pos.y = -4;

            //}
        }
        if (0 < hori && Triggerx == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.2f);

            botanx++;
            //number = botanx + botany;
            //pos.x += 361;
            pos.x = 361*botanx;

            if (botanx > 2)
            {
                botanx = 1;

            }

            //if (number >= 3 && botanx > 2)
            //{
            //    botanx = 0;
            //    number = botanx + botany;
            //    pos.x -= 3 * 361;
            //}
        }

        if (0 > hori && Triggerx == 0.0f)
        {
            //音を鳴らす
            audioSource.PlayOneShot(Cursor1, 0.2f);

            botanx--;
            //number=botanx+botany;
            //pos.x -= 361;
            pos.x = 361*botanx;

            if (botanx < 1)
            {

                botanx = 2;

            }

            //if (number < 0 || botanx < 0)
            //{
            //    botanx = 2;
            //    number = botanx+botany;
            //    pos.x += 3 * 361;
            //}
        }
        myTransform.position = pos;  // 座標を設定

        Trigger = Input.GetAxisRaw("Vertical"); //カーソルの移動速度制御
        Triggerx = Input.GetAxisRaw("Horizontal"); //カーソルの移動速度制御

        //if ()
        //{


        //}
    }
//    public class MenuSelect : MonoBehaviour
//    {

//        int number = 0;

//        private float Trigger;

//        // 使用する AudioSource をアタッチ
//        [SerializeField] private AudioSource audioSource = null;

//        // 使用する AudioClip をアタッチ
//        [SerializeField] public AudioClip Cursor1;
//        [SerializeField] public AudioClip Cursor2;

//        public bool DontDestroyEnabled = true;

//        void Quit()
//        {
//#if UNITY_EDITOR
//            UnityEditor.EditorApplication.isPlaying = false;
//#elif UNITY_STANDALONE
//      UnityEngine.Application.Quit();
//#endif
//        }

//        void Update()
//        {
//            var ver = Input.GetAxis("Vertical");

//            // transformを取得
//            Transform myTransform = this.transform;

//            // 座標を取得
//            Vector3 pos = myTransform.position;

//            if (0 < Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
//            {
//                //音を鳴らす
//                audioSource.PlayOneShot(Cursor1, 0.2f);

//                number--;
//                pos.y += 45;

//                if (number < 0)
//                {
//                    number = 2;
//                    pos.y -= 3 * 45;
//                }
//            }

//            if (0 > Input.GetAxisRaw("Vertical") && Trigger == 0.0f)
//            {
//                //音を鳴らす
//                audioSource.PlayOneShot(Cursor1, 0.2f);

//                number++;
//                pos.y -= 45;

//                if (number > 2)
//                {
//                    number = 0;
//                    pos.y += 3 * 45;
//                }
//            }

//            myTransform.position = pos;  // 座標を設定

//            Trigger = Input.GetAxisRaw("Vertical"); //カーソルの移動速度制御

//            if (Input.GetKeyDown(KeyCode.JoystickButton1) || Input.GetKeyDown(KeyCode.JoystickButton2))
//            {
//                audioSource.PlayOneShot(Cursor2, 0.2f); //音を鳴らす

//                if (SceneManager.GetActiveScene().name == "Stage0")
//                {
//                    switch (number)
//                    {
//                        case 0:
//                            SceneManager.LoadScene("Stage0");
//                            break;
//                        case 1:
//                            SceneManager.LoadScene("Menu");
//                            break;
//                        case 2:
//                            Quit();
//                            break;
//                    }
//                }
//                if (SceneManager.GetActiveScene().name == "Stage1")
//                {
//                    switch (number)
//                    {
//                        case 0:
//                            SceneManager.LoadScene("Stage1");
//                            break;
//                        case 1:
//                            SceneManager.LoadScene("Menu");
//                            break;
//                        case 2:
//                            Quit();
//                            break;
//                    }
//                }
//                if (SceneManager.GetActiveScene().name == "Stage2")
//                {
//                    switch (number)
//                    {
//                        case 0:
//                            SceneManager.LoadScene("Stage2");
//                            break;
//                        case 1:
//                            SceneManager.LoadScene("Menu");
//                            break;
//                        case 2:
//                            Quit();
//                            break;
//                    }
//                }
//                if (SceneManager.GetActiveScene().name == "Stage3")
//                {
//                    switch (number)
//                    {
//                        case 0:
//                            SceneManager.LoadScene("Stage3");
//                            break;
//                        case 1:
//                            SceneManager.LoadScene("Menu");
//                            break;
//                        case 2:
//                            Quit();
//                            break;
//                    }
//                }
//            }
//        }
//    }

}
