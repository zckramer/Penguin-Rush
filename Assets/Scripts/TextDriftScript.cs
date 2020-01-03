using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDriftScript : MonoBehaviour 
{
	TextMesh textMesh;
	GameObject penguin;

	// Use this for initialization
	void Start () 
	{
		penguin = GameObject.Find ("Penguin");
		textMesh = gameObject.GetComponent<TextMesh> ();
		Destroy (gameObject, 1.5f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		transform.LookAt(2 * transform.position - penguin.transform.position);
		transform.Translate (Vector3.down * 0.25f /*, Space.Self */);
//		textMesh.color.a = textMesh.color.a * Time.deltaTime * -1;		// would like the alpha to fade quickly
	}

	void OnBecameInvis()
	{
		Destroy (gameObject);
	}

}
