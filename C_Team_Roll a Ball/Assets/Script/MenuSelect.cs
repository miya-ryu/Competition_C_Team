
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSelect : MonoBehaviour {

    int number = 0;
    void Quit()
    {
#if UNITY_EDITOR
      UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
    void Update() {
        var vert = Input.GetAxis("Vertical");
        // transformを取得
        Transform myTransform = this.transform;
 
        // 座標を取得
        Vector3 pos = myTransform.position;

        if (0 < Input.GetAxisRaw("Vertical"))
        {
            number++;
            pos.y -= 22;

            if (number > 2)
            {
                number = 0;
                pos.y += 3 * 22;
            }
        }
        if (Input.GetAxisRaw("Vertical") < 0)
        {
            number--;
            pos.y += 22;

            if (number < 0)
            {
                number = 2;
                pos.y -= 3 * 22;
            }
        }
        myTransform.position = pos;  // 座標を設定

        if (Input.GetKeyDown(KeyCode.JoystickButton0))
        {
            switch (number)
            {
                case 0:
                    SceneManager.LoadScene("SampleScene");
                    break;
                case 1:

                case 2:
                    Quit();
                    break;
            }
        }
    }
}
