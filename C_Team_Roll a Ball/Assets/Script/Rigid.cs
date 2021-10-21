using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rigid : MonoBehaviour
{
    public Vector3 acceleration; //加速度
    public Vector3 velocity;     //速度
    public Vector3 position;     //位置

    public float mass; //質量
    public Vector3 gravityScale; //重量加速度

    const float dt = 1f / 60f; //微小時間dt
    public void AddForce(Vector3 force)
    {
        acceleration += force; //加速度＋力
    }

    private void FixedUpdate()
    {
        acceleration += mass * gravityScale; //質量 * 重力加速度 = 重力

        velocity += acceleration * dt; //速度 = 加速度 * 微小時間dt
        position += velocity * dt; // 位置 = 速度 * 微小時間dt

        if(position.y < 0.5f)
        {
            velocity = -velocity;
        }
        transform.position = position;
        acceleration = Vector3.zero; //加速度をリセット
    }
}
