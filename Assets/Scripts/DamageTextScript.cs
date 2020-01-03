using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageTextScript : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		Destroy (gameObject, 1.75f);	
	}
	
	// Update is called once per frame
	void Update () 
	{
		gameObject.transform.position += transform.up * Time.deltaTime * 2;
	}
}
