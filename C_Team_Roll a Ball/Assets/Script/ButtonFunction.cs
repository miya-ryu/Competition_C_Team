
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonFunction : MonoBehaviour {

	[SerializeField]
	//　ポーズした時に表示するUIのプレハブ
	private GameObject menuUIPrefab;
	//　ポーズUIのインスタンス
	private GameObject menuUIInstance;
	// Update is called once per frame
	void Update () {
		//Spaceキーが押されたら
		if (Input.GetKeyDown(KeyCode.JoystickButton7)) {
			//メニューが出ていなかったら
			if (menuUIInstance == null)  {
				menuUIInstance = GameObject.Instantiate (menuUIPrefab) as GameObject;
				//ゲーム画面を止める
				Time.timeScale = 0f;
			} else {
				Destroy (menuUIInstance);
				Time.timeScale = 1f;
			}
		}
	}
}