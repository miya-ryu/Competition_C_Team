
using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//[RequireComponent(typeof(GameManager))]

public class ButtonFunction : MonoBehaviour {

	//[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	public GameObject menuUIPrefab;
	//　ポーズUIのインスタンス
	public GameObject menuUIInstance;

    GameObject go;
    GameManager gm;
    
	// Update is called once per frame
	void Update () {

        go = GameObject.Find("Ball");
        gm = go.GetComponent<GameManager>();
        //Spaceキーが押されたら

        if ((Input.GetKeyDown(KeyCode.JoystickButton7) || Input.GetKeyDown(KeyCode.Space)) && gm.score < 1)
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

        } else if (gm.score >= 1)
        {

            Time.timeScale = 0f;

        }


    }
}