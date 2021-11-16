using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSound : MonoBehaviour
{
    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Wall;

    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが Ball だった場合
        if (other.gameObject.CompareTag("Ball"))
        {
            //音を鳴らす(sound1)
            audioSource.PlayOneShot(Wall);
        }
    }
}