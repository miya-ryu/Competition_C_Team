using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SE : MonoBehaviour
{
    public AudioClip Wall;
    public AudioClip Item;

    AudioSource audioSource;

    public void Stert()
    {
        audioSource = GetComponent<AudioSource>();
    }
}
