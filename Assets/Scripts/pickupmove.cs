using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickupmove : MonoBehaviour 
{
	PenguinMovementController penguin;
	private float lifetime;
	// Use this for initialization
	void Start ()
	{
		lifetime = 12f;
//		Destroy(gameObject, lifetime);
		penguin = GameObject.Find("PenguinMovement").GetComponent<PenguinMovementController>();
	}

        // Update is called once per frame
	void Update () 
	{
//		gameObject.transform.Translate(0, 0, Time.deltaTime * -1 * penguin.movementSpeed, Space.World);
	}

	void OnBecameInvis()
	{
		Destroy (gameObject, 1f);
	}
}

