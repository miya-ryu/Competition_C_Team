using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyRigidbody : MonoBehaviour
{
    public Vector3 acceleration; //加速度
    public Vector3 velocity;     //速度
    public Vector3 position;     //位置
    public float mass;           //質量
    public Vector3 gravityScale; //重力加速度

    const float dt = 1f / 60f; //微小時間dtに相当する部分

    void Start()
    {
        //現在の位置を取得
        position = transform.position;
    }

    public void AddForce(Vector3 force)
    {
        //加速度＋力
        acceleration += force;
    }

    void FixedUpdate()
    {
        //加速度＝質量×重力加速度（重力を発生させる）
        acceleration += mass * gravityScale;
        //速度＝加速度×時間
        velocity += acceleration * dt;
        //位置＝速度×時間
        position += velocity * dt;

        //もしy軸の高さが0.5より小さくなったら
        //if(position.y < 0.5f)
        //{
        //    //跳ね返りの処理（地面と接触したら跳ね返る表現）
        //    velocity = -velocity;
        //}
        //現在の位置を置き換える
        transform.position = position;
        //加速度をゼロにする
        acceleration = Vector3.zero;
    }
}
