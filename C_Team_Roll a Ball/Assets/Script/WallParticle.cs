using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallParticle : MonoBehaviour
{
	[SerializeField] private ParticleSystem particle = null;

	//[SerializeField] int m_cacheCount = 1;

	//ParticleSystem[] m_cache = default;

	//int m_index = 5;

	//void Start()
	//{
	//	System.Array.Resize(ref m_cache, m_cacheCount);
	//	for (int i = 0; i < m_cacheCount; i++)
	//	{
	//		m_cache[i] = Instantiate(particle);
	//	}
	//}

	//void Update()
	//{
	//	if (Input.GetButtonDown("Ball"))
	//	{
	//		m_cache[m_index].Play();
	//		m_index = (m_index == m_cacheCount - 1) ? 0 : m_index + 1;
	//	}
	//}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Wall")
		{
			// パーティクルシステムのインスタンスを生成する。
			ParticleSystem newParticle = Instantiate(particle);

			// パーティクルの発生場所をこのスクリプトをアタッチしているGameObjectの場所にする。
			newParticle.transform.position = this.transform.position;

			// パーティクルを発生させる。
			newParticle.Play();

			// インスタンス化したパーティクルシステムのGameObjectを削除する。
			Destroy(newParticle.gameObject, 3.5f);
		}
	}
}