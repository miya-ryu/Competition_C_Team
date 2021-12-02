using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorSound : MonoBehaviour
{
    // 使用する AudioSource をアタッチ
    [SerializeField] private AudioSource audioSource = null;

    // 使用する AudioClip をアタッチ
    [SerializeField] public AudioClip Floor;

    private void OnTriggerEnter(Collider collider)
    {
        //接地面のオブジェクトのタグが Floor だったら
        if (collider.gameObject.CompareTag("Floor"))
        {
            //音を鳴らす
            audioSource.PlayOneShot(Floor, 1.5f);
        }
    }
}
