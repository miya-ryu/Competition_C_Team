
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;


public static class CustomInput
{
    private static float timeToEnableInputs;

    public static void DisableInputs(float time)
    {
        timeToEnableInputs = Time.time + time;
    }

    public static float GetAxis(string axisName)
    {
        return Time.time >= timeToEnableInputs ? Input.GetAxis(axisName) : 0.0f;
    }

    public static bool GetKeyDown(KeyCode key)
    {
        return (Time.time >= timeToEnableInputs) && Input.GetKeyDown(key);
    }
}

public class MenuSelect_Test : MonoBehaviour
{
    bool pushFlag = false;

    int number = 0;
    void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#elif UNITY_STANDALONE
      UnityEngine.Application.Quit();
#endif
    }
    void Update()
    {


        //var vert = Input.GetAxis("Vertical");

        var vert = CustomInput.GetAxis("Vertical");

        // transformを取得
        Transform myTransform = this.transform;

        // 座標を取得
        Vector3 pos = myTransform.position;

        if (0 < vert)
        {
            if (pushFlag == false && vert > 0)
            {

                pushFlag = true;

                CustomInput.DisableInputs(1.0f);

                number++;
                pos.y -= 22;

                if (number > 2)
                {
                    number = 0;
                    pos.y += 3 * 22;
                }

            }
            else
            {

                pushFlag = false;

            }
        }
        if (vert < 0)
        {

            if (pushFlag == false && vert < 0)
            {

                pushFlag = true;

                CustomInput.DisableInputs(1.0f);

                number--;
                pos.y += 22;

                if (number < 0)
                {
                    number = 2;
                    pos.y -= 3 * 22;
                }

            }
            else
            {

                pushFlag = false;

            }
        }
        //if (0 < Input.GetAxisRaw("Vertical"))
        //{
        //    number++;
        //    pos.y -= 22;

        //    if (number > 2)
        //    {
        //        number = 0;
        //        pos.y += 3 * 22;
        //    }
        //}
        //if (Input.GetAxisRaw("Vertical") < 0)
        //{
        //    number--;
        //    pos.y += 22;

        //    if (number < 0)
        //    {
        //        number = 2;
        //        pos.y -= 3 * 22;
        //    }
        //}
        myTransform.position = pos;  // 座標を設定

        if (Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetKeyDown(KeyCode.Escape))
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
