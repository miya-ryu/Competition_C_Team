using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound : MonoBehaviour
{
    public AudioClip sound;

    void OnCollisionEnter(Collision col)
    {
        AudioSource.PlayClipAtPoint(sound, transform.position);
    }
}