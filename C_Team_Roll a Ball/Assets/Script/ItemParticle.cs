using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemParticle : MonoBehaviour
{
    [SerializeField] private ParticleSystem particle = null;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            // パーティクルシステムのインスタンスを生成する。
            ParticleSystem newParticle = Instantiate(particle);

            // パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
            newParticle.transform.position = this.transform.position;

            // パーティクルを発生させる。
            newParticle.Play();

            // インスタンス化したパーティクルシステムのGameObjectを削除する。
            Destroy(newParticle.gameObject, 1.0f);
        }
    }
}
