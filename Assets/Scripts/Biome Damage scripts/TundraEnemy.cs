using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TundraEnemy : MonoBehaviour 
{
	private GameObject penguin;
	private ObstacleController controller;
	[SerializeField]
	GameObject particleWeaknessOBJ;
	[SerializeField]
	GameObject particleStrengthOBJ;

    // Use this for initialization
    void Awake()
    {
		
		controller = gameObject.GetComponent<ObstacleController> ();
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slimey Fish")
        {
			controller.UpdateHealth(1);
			PlayStrParticle ();
        }

        if (other.tag == "Crusty Fish")
        {
			controller.UpdateHealth(1);
			PlayStrParticle ();
        }

        if (other.tag == "Inferno Fish")
        {
			controller.UpdateHealth(5);
			PlayWeakParticle ();
        }

        if (other.tag == "Frozen Fish")
        {
			controller.UpdateHealth(1);
			PlayStrParticle ();
        }

        if (other.tag == "Basic Fish")
        {
			controller.UpdateHealth(2);
			PlayStrParticle ();
        }
	}

	public void PlayStrParticle()	// gotta make this do something
	{
		Instantiate (particleStrengthOBJ, gameObject.transform.position, gameObject.transform.rotation);
	}

	public void PlayWeakParticle()	// gotta make this do something
	{
		Instantiate (particleWeaknessOBJ, gameObject.transform.position, gameObject.transform.rotation);
	}

}