using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestForcescript : MonoBehaviour
{
    private MyRigidbody rb;

    void Start()
    {
        rb = GetComponent<MyRigidbody>();
    }

    void FixedUpdate()
    {
        rb.AddForce(new Vector3(0f, -9.8f, 0f));
    }
}
