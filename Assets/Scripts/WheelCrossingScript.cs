using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelCrossingScript : MonoBehaviour 
{
	[SerializeField]
	float objRotateIndex;
	[SerializeField]
	float rotationSpeed = 12.0f;
	[SerializeField]
	int dir = 1;

	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		EnemyMovement ();
	}

	void EnemyMovement()
	{
		objRotateIndex = gameObject.transform.rotation.z;
		transform.Rotate (Vector3.forward * rotationSpeed * dir * Time.deltaTime);

		float xScale = transform.localScale.x;

		if (objRotateIndex >= 0.25f) 
		{
			dir = -1;
		} 

		else if (objRotateIndex <= -0.25f)
		{
			dir = 1;
		}
	}

}
