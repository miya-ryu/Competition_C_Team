using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotAngle = 100.0f;

    void FixedUpdate()
    {
        transform.Rotate(0f, rotAngle * Time.deltaTime, 0f, Space.World);
    }
}