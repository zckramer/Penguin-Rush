using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour 
{
	// Script and Game Object References
	private GameObject penguin;
	PenguinData penguinData;


	// Particle Effect variables
	[SerializeField]
	GameObject particleWeaknessOBJ;
	[SerializeField]
	GameObject particleStrengthOBJ;

	// Text Object Variables
	[SerializeField]
	GameObject awardTextOBJ;
	TextMesh pointsTextMesh;
	[SerializeField]
	string awardText;

	// Health Variables
	[SerializeField]
	private int enemyHealth;

	// Pickups variables
	public GameObject[] Pickups;
	private Transform pickupSpawnTransform;
	float lazerTouchingTime = 0f;


	// Scoring Variables
	public int pointsAwarded;

   
    public AudioClip pop;
    private AudioSource source;



    // Use this for initialization
    void Awake()
	{
		pointsTextMesh = awardTextOBJ.GetComponent<TextMesh> ();
		penguin = GameObject.Find ("Penguin");
		penguinData = penguin.GetComponent<PenguinData> ();
		pickupSpawnTransform = gameObject.transform;
        source = GetComponent<AudioSource>();
    }

    void Update()
	{
		CheckForDestroy ();
	}

	void OnTriggerEnter(Collider other)
	{
	    if (other.tag == "Lazer")
        {
			// Damage instantly once, then over time
			UpdateHealth (1);
			lazerTouchingTime += Time.deltaTime;
			if (lazerTouchingTime >= 0.25f) 
			{
				UpdateHealth (1);
				lazerTouchingTime = 0f;
			}
		
			PlayWeakParticle ();
        }

		if (other.tag == "Basic Fish")
		{
			UpdateHealth(2);
			PlayStrParticle ();
		}

		if (other.tag == "Melee Area") 
		{
			Debug.Log ("other.tag = " + other.tag);
			UpdateHealth (5);
			PlayWeakParticle ();
		}
        if (other.tag == "Flamethrower")
        {
            UpdateHealth(5);
            //Destroy(other.gameObject);
        }
        if (other.tag == "Crusty Fish")
        {
            UpdateHealth(1);
            Destroy(other.gameObject);
        }
        if (other.tag == "Frozen Fish")
        {
            UpdateHealth(5);
        }
        if (other.tag == "Slimey Fish")
        {
            UpdateHealth(1);
            Destroy(other.gameObject);
        }
    }

	public void UpdateHealth(int _decrement)			// This function DECREMENTS HP, not incrementing. be cautious with the parameter here
	{
		enemyHealth -= _decrement;
		awardText = _decrement.ToString();
		CheckForDestroy();
	}

	void SpawnPickup()
	{
		int randIndex = Random.Range(0, 100);
		if (randIndex <= 24)
		{
			int randindex = Random.Range(0, Pickups.Length);
			Instantiate(Pickups[randindex], pickupSpawnTransform.position, pickupSpawnTransform.rotation);
			Destroy(gameObject);
		}
		if (randIndex >= 25)
		{
            
			Destroy(gameObject);
		}
	}

	void CheckForDestroy()
	{
		if (enemyHealth <= 0)
		{
			SpawnAwardText ();

            AudioSource.PlayClipAtPoint(pop, transform.position);
//			Debug.Log("Boom!!");
			penguinData.ModifyScore(pointsAwarded);
			SpawnPickup();
            Destroy (gameObject);
			//GetComponent<AudioSource>().Play();

		}
	}

	void SpawnAwardText ()
	{
		pointsTextMesh.text = pointsAwarded.ToString();
		Instantiate(awardTextOBJ, transform.position, transform.rotation);

	}

	public void PlayStrParticle()	
	{
		Instantiate (particleStrengthOBJ, gameObject.transform.position, gameObject.transform.rotation);
	}

	public void PlayWeakParticle()	
	{
		Instantiate (particleWeaknessOBJ, gameObject.transform.position, gameObject.transform.rotation);
	}

}
