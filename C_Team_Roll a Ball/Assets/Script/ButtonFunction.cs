using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonFunction : MonoBehaviour
{
    //　ポーズした時に表示するUIのプレハブ
    public GameObject menuUIPrefab;
    //　ポーズUIのインスタンス
    public GameObject menuUIInstance;

    GameObject go;
    PlayerController gm;

    // Update is called once per frame
    void Update()
    {
        go = GameObject.Find("Ball");
        gm = go.GetComponent<PlayerController>();

        //STRAT ボタンが押されたら
        if ((Input.GetKeyDown(KeyCode.JoystickButton7)) && gm.score < gm.scoreMax)
        {
            //メニューが出ていなかったら
            if (menuUIInstance == null)
            {
                menuUIInstance = GameObject.Instantiate(menuUIPrefab) as GameObject;
                //ゲーム画面を止める
                Time.timeScale = 0f;
            }
            else
            {
                Destroy(menuUIInstance);
                Time.timeScale = 1f;
            }
        }
        else if (Time.timeScale == 0 && menuUIInstance == null && gm.score == 0)
        {
            Time.timeScale = 1f;
        }
        else if (gm.score >= gm.scoreMax)
        {
            //ゲーム画面を止める
            Time.timeScale = 0f;
        }
    }
}