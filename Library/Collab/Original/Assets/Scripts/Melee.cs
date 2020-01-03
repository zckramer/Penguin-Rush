using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour 
{

    private GameObject Guard;
	[SerializeField]
	bool canMelee = true;
    private float timer = 0f;
	[SerializeField]
	private float timerCooldown;
	private float timerCooldownLimit = 3.5f;

	// Use this for initialization
	void Start () 
	{
		canMelee = true;
		timerCooldown = timerCooldownLimit;
        Guard = GameObject.Find("Melee");
        timer = 0;
        Guard.SetActive(false);
    }

    // Update is called once per frame
     void Update () 
	{
		UpdateCooldown ();

        timer += Time.deltaTime;
		if (Input.GetKeyDown("space") && (canMelee))
        {
			Debug.Log ("Spacebar pressed");
            Guard.SetActive(true);
            timer = 0f;
			canMelee = false;
        }

        if (timer >= .5f)
        {
            Guard.SetActive(false);
        }
    }
		
	void UpdateCooldown ()
	{
		if (canMelee == false) 
		{
			timerCooldown -= Time.deltaTime;
		}

		if (timerCooldown <= 0) 
		{
			canMelee = true;
			timerCooldown = timerCooldownLimit;
		}

	}

	void OnTriggerEnter(Collider other)		// Shield destroys enemy bullets
	{
		if (other.tag == "Ebullet") 
		{
			Destroy (other.gameObject);
		}
	}

}
