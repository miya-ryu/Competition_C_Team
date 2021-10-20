using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateContoroll_Test2 : MonoBehaviour
{
    bool coroutineBool = false;

    void Update()
    {
        float x = 0f, y = 0f, z = 0f;
        Transform mytransform = this.transform;

        Vector3 angles = transform.localEulerAngles;
        if (Input.GetKey("right"))
        {

            x++;
            if (x > 30f) {
                x = 30f;
                angles.x = 30f;
                mytransform.localEulerAngles = angles;
            }
            else
            {
                transform.Rotate(x, 0, 0);
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
