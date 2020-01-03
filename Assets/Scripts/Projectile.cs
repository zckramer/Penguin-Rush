using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
	//Script call
 
	//Object References
	public GameObject penguin;
    

	//Particle Prefab References
	public GameObject obstacleParticleObj;
	public GameObject frozenParticleObj;
	public GameObject crustyParticleObj;
	public GameObject slimeyParticleObj;
	public GameObject infernoParticleObj;

    public Transform targetTransform;

	Vector3 targetVector;

	//Variables
	public float moveSpeed;
	[SerializeField]
	private float lifetime = 1.5f;

    // Use this for initialization
    void Start ()
	{
        moveSpeed = 20f;
        lifetime = 4f;
        Destroy(gameObject, lifetime);
        penguin = GameObject.Find ("Penguin");
    }

	// Update is called once per frame
	void Update () 
	{
		Vector3 forward = new Vector3 (0, 0, moveSpeed);
		gameObject.GetComponent<Rigidbody> ().velocity = forward;
        if (this.tag == "Inferno Fish")
        {
            lifetime = 1f;
            moveSpeed = 1f;
        }
    }

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Enemy")
		{
  	          Destroy (gameObject);
		} 

		if (other.tag == "MinorObstacle" || other.tag == "MajorObstacle") 
		{
			if (obstacleParticleObj != null)
			{
				Instantiate(obstacleParticleObj);
				Destroy (gameObject);
			}

            Destroy(gameObject);

        }

		if (other.tag == "DestructibleObstacle") 
		{
			Destroy (gameObject);

			if (obstacleParticleObj != null)
			{
				Instantiate(obstacleParticleObj);
				Destroy (gameObject);
			}

		}
	}

}
