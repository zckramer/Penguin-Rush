using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testParticleText : MonoBehaviour 
{

	// Text Object Variables
	[SerializeField]
	GameObject particleText;
	TextMesh damageTextMesh;
	[SerializeField]
	string damageText;



	void Spawnparticles()
	{

		damageTextMesh.text = damageText;
		Instantiate(particleText, transform.position, transform.rotation);

	}



}
