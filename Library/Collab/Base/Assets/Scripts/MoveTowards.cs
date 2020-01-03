using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour 
{

	PenguinMovementController penguin;

	// Use this for initialization
	void Start () 
	{
		penguin = GameObject.Find ("PenguinMovement").GetComponent<PenguinMovementController>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = transform.Translate (transform.forward) * Time.deltaTime * penguin.movementSpeed * 0.5f;
	}
}
