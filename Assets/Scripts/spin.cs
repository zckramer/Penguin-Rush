using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spin : MonoBehaviour 
{
	public float rotateSpeed = 150.0f;

	// Update is called once per frame
	void Update () 
	{
		float rotate = Time.deltaTime * rotateSpeed;
		transform.Rotate(0, rotate, 0);
	}
}
