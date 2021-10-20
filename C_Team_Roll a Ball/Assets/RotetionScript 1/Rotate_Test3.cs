using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Test3 : MonoBehaviour
{
	//加速したのち終端する、目的の速度
	public float target_kmph_ = 100f;

    // Use this for initialization
    void FixedUpdate()
    {
        var hori = Input.GetAxis("Horizontal");
        var vert = Input.GetAxis("Vertical");
        var rb = GetComponent<Rigidbody>();

        /*自分に対しての向きで、トルクをかける*/
        rb.AddRelativeTorque(new Vector3(hori, -hori, 0)*60f); //左右でy軸回転
        rb.AddRelativeTorque(new Vector3(0, -vert, vert)*60f); //上下でx軸回転

        /*Test*/
        //rb.AddRelativeTorque(new Vector3(hori, -hori, 0)); //左右でy軸回転
        //rb.AddRelativeTorque(new Vector3(0, -vert, vert)); //上下でx軸回転
        //rb.AddTorque(new Vector3(hori, -hori, 0) * 2f); //左右でy軸回転
        //rb.AddTorque(new Vector3(0, -vert, vert) * 2f); //上下でx軸回転

        Transform mytransform = this.transform;

        Vector3 angles = mytransform.localEulerAngles;

        if (angles.x > 180)
        {

            angles.x = angles.x - 360f;

        }
        if (angles.z > 180)
        {

            angles.z = angles.z - 360f;

        }
        if (angles.y != 0)
        {

            angles.y = 0;

        }


        if ((angles.x >= -30f) || (angles.x <= 30f))
        {

            if (angles.x > 30f)
            {

                angles.x = 30f;
                //angles.y = 0;
                //mytransform.localEulerAngles = angles;


            }
            else if (angles.x < -30f)
            {

                angles.x = -30f;
                //angles.y = 0;
                //mytransform.localEulerAngles = angles;

            }

        }
        if ((angles.z >= -30f) || (angles.z <= 30f))
        {

            if (angles.z > 30f)
            {

                angles.z = 30f;
                //angles.y = 0;
                //mytransform.localEulerAngles = angles;

            }
            else if (angles.z < -30f)
            {

                angles.z = -30f;
                //angles.y = 0;
                //mytransform.localEulerAngles = angles;

            }

        }
        angles.y = 0;
        mytransform.localEulerAngles = angles;


        /*x軸方向の水平を保つ*/
        var left = transform.TransformVector(Vector3.left); //機体の左を向くベクトルを、ローカル→ワールド座標に変換する！
        var horizontal_left = new Vector3(left.x, 0f, left.z).normalized;   //上で求めたベクトルをx-z平面（水平）上のベクトルに補正し、単位ベクトルにする。
        rb.AddTorque(Vector3.Cross(left, horizontal_left)*5);    //外積を取る。傾いているほど大きいトルク。（ばねのように）

        /*機体から見てz軸方向にも水平を保つ。*/
        var forward = transform.TransformVector(Vector3.forward);
        var horizontal_forward = new Vector3(forward.x, 0f, forward.z).normalized;
        rb.AddTorque(Vector3.Cross(forward, horizontal_forward)*5);

        ///*機体を前に発進させるエンジン*/
        //var force = (rb.mass * rb.drag * target_kmph_ / 3.6f) / (1f - rb.drag * Time.fixedDeltaTime);   //ある終端そくどに向かうための力を求める！
        //rb.AddRelativeForce(new Vector3(0f, 0f, force));
    }

}
