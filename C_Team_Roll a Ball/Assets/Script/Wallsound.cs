using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wallsound : MonoBehaviour
{
    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Wall;

    void OnCollisionEnter(Collision col)
    {
        //ぶつかったオブジェクトのタグがボールだったら
        if (col.gameObject.CompareTag("Ball"))
        {
            Debug.Log("当たった");
            //音を鳴らす
            audioSource.PlayOneShot(Wall);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        // ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("当たった");
            //音を鳴らす(sound1)
            audioSource.PlayOneShot(Wall);
        }
    }
}
