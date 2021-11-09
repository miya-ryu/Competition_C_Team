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

    GameObject CountText;
    Timer script;
    float countDown;

    // Update is called once per frame
    void Update()
    {
        go = GameObject.Find("Ball");
        gm = go.GetComponent<PlayerController>();

        CountText = GameObject.Find("Game Clear");
        script = CountText.GetComponent<Timer>();

        //STRAT ボタンが押されたら
        if ((Input.GetKeyDown(KeyCode.JoystickButton7)) && gm.score < gm.scoreMax && script.CountFlag)
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
        else if (Time.timeScale == 0 && menuUIInstance == null && gm.score == 0 && script.CountFlag)
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