using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnBecameInvis : MonoBehaviour 
{
	void OnBecameInvis()
	{
		Destroy (gameObject);
	}
}
