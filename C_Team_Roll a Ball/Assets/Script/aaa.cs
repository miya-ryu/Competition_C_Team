using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aaa : MonoBehaviour
{
    GameObject particle;

    // Start is called before the first frame update
    void Start()
    {

        particle = GameObject.Find("Paper");
        particle.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("再生されました");
        particle.transform.position = new Vector3(0, 14, 0);
        particle.SetActive(true);
        particle.GetComponent<ParticleSystem>().Play();
    }
}
