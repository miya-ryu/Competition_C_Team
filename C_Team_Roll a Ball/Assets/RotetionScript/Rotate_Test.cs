using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate_Test : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
	{

	}

	//float minAngle = Time.deltaTime*90F;
	float maxAngle = 30.0F;

	Transform target;
	float speed = 1F/90F;

	//void Start()
	//{
	//	target = GameObject.Find("Cube").transform;
	//}

	void Update()
	{
		float step = speed * Time.deltaTime;
		float minAngle = 90F;

		//指定した方向にゆっくり回転する場合
		transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(maxAngle, 0, 0), minAngle);
	}

}