using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleController : MonoBehaviour 
{
    [SerializeField]
    private int obstacleHealth;

    public GameObject[] Pickups;

	private GameObject penguin;
    PenguinData penguinInfoHolder;

    // Use this for initialization
    void Awake ()
    {
		obstacleHealth = 1;
		penguin = GameObject.Find ("Penguin");
		penguinInfoHolder = penguin.GetComponent<PenguinData>();
    }
	
	// Update is called once per frame
	void Update ()
    {
		CheckForDestroy ();
	}

    public void UpdateHealth(int _mod)
	{
		obstacleHealth -= _mod;
        CheckForDestroy();
    }

    void SpawnPickup()
    {
        int randIndex = Random.Range(0, 100);
        if (randIndex <= 24)
        {
            int randindex = Random.Range(0, Pickups.Length -1);
			Instantiate(Pickups[randindex], gameObject.transform.position, gameObject.transform.rotation);
            Destroy(gameObject);
        }
       if (randIndex >= 25)
        {
            Destroy(gameObject);
        }
 
    }

    void CheckForDestroy()
	{
		if (obstacleHealth <= 0)
		{
			penguinInfoHolder.ModifyScore(100);
            SpawnPickup();
			Destroy (gameObject);
            // GetComponent<AudioSource>().Play();
           
        }
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			penguinInfoHolder.ModifyHP (-2);
			Destroy (gameObject);
		}

		if (other.tag == "Basic Fish") 
		{
			UpdateHealth (-1);
		}
		if (other.tag == "Melee Area") 
		{
			UpdateHealth (-5);
		}
        if (other.tag == "Lazer")
        {
            Destroy(gameObject);
        }
	}



}
