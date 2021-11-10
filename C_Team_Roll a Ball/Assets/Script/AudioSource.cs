using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSource : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip Item;
    public AudioClip Wall;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision other)
    {
        GameObject gm = GameObject.Find("GameManager");
        if (gm.GetComponent<GameManager>().lslnGame())
        {
            if (other.gameObject.tag == "Block")
            {
                audio.PlayOneShot(sound01);
            }
            else if (other.gameObject.tag == "Target")
            {
                audio.PlayOneShot(sound02);
            }
        }
    }
}
