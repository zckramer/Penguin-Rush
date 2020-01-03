using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinDirectory : MonoBehaviour
{
    #region
    private PlayerLog eventLog;
    [SerializeField]
    GameObject penguinMovement;
    public Transform canvas;
    GameObject slopeHolder;
	ShootScript shootScript;

    //Pickup Particle
    public GameObject pickupParticle;

    //Collision Particle
    public GameObject collisionParticleObj;


    PenguinData PenguinInfoHolder;


    public int activeShields;//Leaf sheild
    
    

    public GameObject EQ_Emitter;
    public GameObject Shockwave;

    //consolidated variables for all spawners
    public float SpawnTimeMin;
    public float SpawnTimeMax;

    PenguinData penguinData;


    #endregion

    // Use this for initialization
    void Start()
    {
        eventLog = GetComponent<PlayerLog>();
        Time.timeScale = 1;
        penguinMovement = GameObject.Find("PenguinMovement");
		shootScript = gameObject.GetComponent<ShootScript> ();
        PenguinInfoHolder = GetComponent<PenguinData>();
        penguinData = GameObject.Find("Penguin").GetComponent<PenguinData>();
        SpawnTimeMin = 20 - (penguinData.difficultyIndex * 0.36f);
        SpawnTimeMax = 20;
    }
        



	// Update is called once per frame
	void Update ()
    {
		CheckGameOver ();
    }


    void CheckGameOver()
    {
        if (PenguinInfoHolder.HP <= 0)
        {
            if (canvas.gameObject.activeInHierarchy == false)
            {                                                   // Goes to Game over screen
                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
            }
        }
    } 

    //Obstacle collision 
    void OnTriggerEnter(Collider other)
    {
		if (other.tag == "Superfish")
        {
            if(PenguinInfoHolder.HP != 5)
            {
				shootScript.FireRateLevelUp ();
                PenguinInfoHolder.ModifyHP(1);
                Destroy(other.gameObject);
            }

            if (PenguinInfoHolder.HP == 5)
            {
                Destroy(other.gameObject);
            }
        }
        if (other.tag == "MinorObstacle" || other.tag == "Enemy" || other.tag == "Ebullet" || other.tag == "DestructibleObstacle")	// This is where minor obstacles, enemies, and enemy shots are handled
        {
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);

			PlayRedFlash ();
			shootScript.FireRateLevelDown ();

            if (activeShields <= 0)
            {
				PenguinInfoHolder.ModifyHP (-1);
				shootScript.FireRateLevelDown ();
				Destroy(other.gameObject);
            }
            else if(activeShields > 0)
            {
                activeShields--;
                Destroy(other.gameObject);
            }
		}
        else if (other.tag == "MajorObstacle" )// This is where Major obstacles are handled
        {
            //Debug.Log("other is MajorObstacle and hasAI is false");
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);
            
			PlayRedFlash ();

            if (activeShields <= 0)
            {
				shootScript.FireRateLevelDown ();
				PenguinInfoHolder.ModifyHP (-2);
				Destroy(other.gameObject);
            }
            else if (activeShields > 0)
            {
                activeShields--;
                Destroy(other.gameObject);
            }
            Debug.Log("GAME OVER: Player hit major obstacle");
        }
       

		if(other.tag == "Pickup Fish")									// Pickup fish handled here (should be here, ONLY)
        {
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);

                PenguinInfoHolder.ModifyScore(10);
                // standard fish pickup (no accountant's hat)
                Destroy(other.gameObject);
			Instantiate (pickupParticle, gameObject.transform);
            
        }

        //Pick-up collision
        else if (other.tag == "Dirt")
        {
            PenguinInfoHolder.isSlimey = false;
            PenguinInfoHolder.isFrozen = false;
            PenguinInfoHolder.isInferno = false;
            PenguinInfoHolder.isCrusty = true;
            PenguinInfoHolder.pickupTimer = 10;
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);
			Destroy(other.gameObject);
			Instantiate (pickupParticle, gameObject.transform);
        }

        else if (other.tag == "HotRock")
        {
            PenguinInfoHolder.isSlimey = false;
            PenguinInfoHolder.isFrozen = false;
            PenguinInfoHolder.isCrusty = false;
            PenguinInfoHolder.isInferno = true;
            PenguinInfoHolder.pickupTimer = 10;
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);
            Destroy(other.gameObject);
			Instantiate (pickupParticle, gameObject.transform);
        }

        else if (other.tag == "IceCube")
        {
            PenguinInfoHolder.isSlimey = false;
            PenguinInfoHolder.isInferno = false;
            PenguinInfoHolder.isCrusty = false;
            PenguinInfoHolder.isFrozen = true;
            PenguinInfoHolder.pickupTimer = 10;
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);
            Destroy(other.gameObject);
			Instantiate (pickupParticle, gameObject.transform);
        }

        else if (other.tag == "SlickMud")
        {
            PenguinInfoHolder.isFrozen = false;
            PenguinInfoHolder.isInferno = false;
            PenguinInfoHolder.isCrusty = false;
            PenguinInfoHolder.isSlimey = true;
            PenguinInfoHolder.pickupTimer = 10;
            GetComponentInParent<AudioCollision>().doMakeSound(other.tag);
            Destroy(other.gameObject);
			Instantiate (pickupParticle, gameObject.transform);
        }

    	if (other.tag == "B_Target")
        {
			shootScript.FireRateLevelDown ();
            PenguinInfoHolder.ModifyHP(-1);
            Destroy(other.gameObject);
        }
    }

	void PlayRedFlash()
	{
		if (collisionParticleObj != null)  	// Plays red flash collision particle
		{
			Instantiate (collisionParticleObj, gameObject.transform);
		}
	}
}
