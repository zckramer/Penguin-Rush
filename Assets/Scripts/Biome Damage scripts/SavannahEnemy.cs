using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavannahEnemy : MonoBehaviour 
{
    private ObstacleController Controller;
	[SerializeField]
	GameObject particleWeaknessOBJ;
	[SerializeField]
	GameObject particleStrengthOBJ;

    // Use this for initialization
    void Start()
    {
        Controller = GetComponent<ObstacleController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Slimey Fish")
        {
			Controller.UpdateHealth(5);
			PlayWeakParticle ();
        }

        if (other.tag == "Crusty Fish")
        {
			Controller.UpdateHealth(1);
			PlayStrParticle ();
        }

        if (other.tag == "Inferno Fish")
        {
			Controller.UpdateHealth(1);
			PlayStrParticle ();
        }

        if (other.tag == "Frozen Fish")
        {
			Controller.UpdateHealth(1);
			PlayStrParticle ();
        }

        if (other.tag == "Basic Fish")
        {
			Controller.UpdateHealth(2);
			PlayStrParticle ();
        }
    }

	public void PlayStrParticle ()	// gotta make this do something
	{
		Instantiate (particleStrengthOBJ, gameObject.transform.position, gameObject.transform.rotation);
	}

	public void PlayWeakParticle()	// gotta make this do something
	{
		Instantiate (particleWeaknessOBJ, gameObject.transform.position, gameObject.transform.rotation);
	}

}
