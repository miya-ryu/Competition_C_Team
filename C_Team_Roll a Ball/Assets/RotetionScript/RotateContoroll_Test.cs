using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContoroll_Test : MonoBehaviour
{
    bool coroutineBool = false;

    void Update()
    {
        if (Input.GetKeyDown("right"))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("RightMove");
            }
        }

        if (Input.GetKeyDown("left"))
        {
            //回転中ではない場合は実行 
            if (!coroutineBool)
            {
                coroutineBool = true;
                StartCoroutine("LeftMove");
            }
        }
    }

    //右にゆっくり回転して90°でストップ
    IEnumerator RightMove()
    {
        for (int turn = 0; turn < 30; turn++)
        {

            transform.Rotate(1, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
        coroutineBool = false;
    }

    //左にゆっくり回転して90°でストップ
    IEnumerator LeftMove()
    {
        for (int turn = 0; turn < 30; turn++)
        {
            transform.Rotate(-1, 0, 0);
            yield return new WaitForSeconds(0.03f);
        }
        coroutineBool = false;
    }
}
