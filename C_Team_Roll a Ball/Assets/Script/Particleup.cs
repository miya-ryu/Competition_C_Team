using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particleup : MonoBehaviour
{
    private bool isPlaying;
    [SerializeField] ParticleSystem particle;

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor"))
        {
            if (isPlaying)
            {
                Debug.Log("触れている");
                particle.Play(true);
            }
        }
        else
        {
            particle.Stop(false, ParticleSystemStopBehavior.StopEmitting);
        }
        isPlaying = !isPlaying;
    }
}
