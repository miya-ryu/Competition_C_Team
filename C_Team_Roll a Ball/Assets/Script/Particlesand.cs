using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlesand : MonoBehaviour
{
    [SerializeField] ParticleSystem particle;

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("触れている");
            particle.Play(true);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            Debug.Log("離れている");
            particle.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
    }
}
