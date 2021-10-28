using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
[RequireComponent(typeof(PlayerController))]
public class ButtonFunction : PlayerController
{
    [SerializeField]
    //　ポーズした時に表示するUIのプレハブ
    private GameObject menuUIPrefab;
    //　ポーズUIのインスタンス
    private GameObject menuUIInstance;
    // Update is called once per frame
    static int scoreMax = 12;
    private void Start()
    {
        score = 0;
    }
    void Update()
    {
        //STRAT BUTTON が押されたら
        if (Input.GetKeyDown(KeyCode.JoystickButton7))
        {
            //メニューが出ていなかったら
            if (menuUIInstance == null)
            {
                menuUIInstance = GameObject.Instantiate(menuUIPrefab) as GameObject;
                //ゲーム画面を止める
                Time.timeScale = 0f;
            }
            //else if (score >= scoreMax && menuUIInstance == null)
            //{
            //    Time.timeScale = 0f;
            //}
            else
            {
                Destroy(menuUIInstance);
                Time.timeScale = 1f;
            }
        }
        else if (Time.timeScale == 0 && menuUIInstance == null && score > 1)
        {
            Time.timeScale = 1f;
        }
    }
}