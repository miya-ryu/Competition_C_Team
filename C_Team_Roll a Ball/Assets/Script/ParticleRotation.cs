using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ParticleRotation : MonoBehaviour
{
    void Update()
    {
        gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}