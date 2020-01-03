using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootScript : MonoBehaviour 
{
	// References
	PenguinData penguinData;

    //ice Shot
 //   public GameObject Lazer;
    //Shotgun
    public GameObject Shotgun;
   
    //Flamethrower
    public Transform Flame;

    //Laser
    public Transform Laser;

    // Projectile Selection Variables
    public GameObject[] projectileTypes;
	public int projectileTypeIndex = 0;
			// Please set public game object variables in this order:
			// 0 = normal
			// 1 = crusty
			// 2 = slimey
			// 3 = inferno
			// 4 = frozen

	// Fire Timer Variables
	public float fireTimer = 0f;
	[SerializeField]
	float fireTimerLimit = 0.0f;
	public bool canFire = true;
	public int numSuperFish = 0;
	[SerializeField]
	float modFactor = 0.0f;
	[SerializeField]
	float normalFireTimer = 2;

	// Use this for initialization
	void Start () 
	{
		penguinData = gameObject.GetComponent<PenguinData> ();
		SelectProjectileType (0);
		fireTimerLimit = normalFireTimer;
        Flame.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () 
	{
		CheckForFire ();

        if(projectileTypeIndex == 0)
        {
			HandleFireUpgrade ();
        }
        if(projectileTypeIndex == 1)
        {
            fireTimerLimit = 2f;
            Shotgun.SetActive(true);
        }
        if(projectileTypeIndex != 1)
        {
            Shotgun.SetActive(false);
        }
        if(projectileTypeIndex == 2)
        {
            fireTimerLimit = 0.25f;
        }
        if (projectileTypeIndex == 3)
        {
            fireTimerLimit = 0.3f;
        }
        if (projectileTypeIndex != 3)
        {
            Flame.gameObject.SetActive(false);
        }
        if (projectileTypeIndex == 4)
        {
            fireTimerLimit = 3f;
            Laser.gameObject.SetActive(true);
        }
        if (projectileTypeIndex != 4)
        {
            Laser.gameObject.SetActive(false);
        }
    }

	void UpdateProjectileType()
	{
		if (penguinData.isCrusty) 
		{
			projectileTypeIndex = 1;
		}

		if (penguinData.isSlimey) 
		{
			projectileTypeIndex = 2;
		}

		if (penguinData.isInferno) 
		{
            projectileTypeIndex = 3;
            //Flame.gameObject.SetActive(true);
            Debug.Log("Flame on!");
        }

		if (penguinData.isFrozen) 
		{
			projectileTypeIndex = 4;
		}
		if (penguinData.isFrozen == false && penguinData.isInferno == false && penguinData.isSlimey == false && penguinData.isCrusty == false)
        {
            projectileTypeIndex = 0;
        }
        
	}

	void SelectProjectileType (int _projType)
	{
		projectileTypeIndex	= _projType;
	}

	void DoFire()
	{
        if (projectileTypeIndex != 3 || projectileTypeIndex != 4)
        {
            Instantiate(projectileTypes[projectileTypeIndex], gameObject.transform.position, gameObject.transform.rotation);
        }
        if (projectileTypeIndex == 3 || projectileTypeIndex == 4)
        {

        }


    }

	void CheckForFire()
	{
		fireTimer += Time.deltaTime;
		if (fireTimer >= fireTimerLimit) 
		{
			canFire = true;
		} 
		else 
		{
			canFire = false;
		}

		if (!Input.GetKey (KeyCode.Mouse0)) 		// This simply keeps the flamethrower and Laser OFF when the shoot button isn't pressed
		{
			Flame.gameObject.SetActive(false);
            Laser.gameObject.SetActive(false);

        }
		if (Input.GetKey (KeyCode.Mouse0) || Input.GetKey (KeyCode.Z) || Input.GetButton("Fire1")) 
		{
            //Frozen
            if (canFire && projectileTypeIndex == 4)
            {
                Laser.gameObject.SetActive(true);
            }

            if (projectileTypeIndex == 4 && Input.GetKeyUp(KeyCode.Mouse0))
            {
                Laser.gameObject.SetActive(false);
            }

            //Inferno
            if (canFire && projectileTypeIndex == 3)
            {
                Flame.gameObject.SetActive(true);
            }

            if (projectileTypeIndex == 3 && Input.GetKeyUp(KeyCode.Mouse0))
            {
                Flame.gameObject.SetActive(false);
            }

            //Crusty
			if (canFire && projectileTypeIndex == 1)
            {
                GameObject shotgunFire = Instantiate(projectileTypes[projectileTypeIndex], gameObject.transform.position, gameObject.transform.rotation);
                GameObject penguin = GameObject.Find("Penguin");

                #region Fixes Shotgunfire transform

                shotgunFire.transform.position = new Vector3(
                    shotgunFire.transform.position.x * 0,
                    shotgunFire.transform.position.y * 0,
                    shotgunFire.transform.position.z * 0);


                shotgunFire.transform.position = new Vector3(
                    penguin.transform.position.x,
                    penguin.transform.position.y,
                    penguin.transform.position.z);

                #endregion

                #region Fixes Shotgunfire rotation
                shotgunFire.transform.eulerAngles = new Vector3(
                    shotgunFire.transform.eulerAngles.x * 0,
                    shotgunFire.transform.eulerAngles.y * 0,
                    shotgunFire.transform.eulerAngles.z * 0);

                shotgunFire.transform.eulerAngles = new Vector3(
                    penguin.transform.eulerAngles.x + 180,
                    penguin.transform.eulerAngles.y + 270,
                    penguin.transform.eulerAngles.z + 270 + GameObject.Find("PenguinMovement").transform.eulerAngles.z);

                Debug.Log(shotgunFire.transform.eulerAngles.x);
                #endregion


                //Debug.Log("Shotgun Fired");
                fireTimer = 0f;
            }

			/*else if (canFire && projectileTypeIndex != 4) //commented out because it effectivly does what the two lines of code above do in a less functional way. Duplicate code?
			{
				DoFire ();
				fireTimer = 0f;
			}*/
			else if (canFire && projectileTypeIndex !=1)
			{
				DoFire();
				fireTimer = 0f;
			}
		}
	}

	void HandleFireUpgrade()												// References: none		Used in: ShootScript.cs
	{		
		if (Input.GetKeyDown (KeyCode.P)) 									// Increment and decrement num super fish for testing
		{
			IncrementNumSuperfish (1);
		}		
		if (Input.GetKeyDown (KeyCode.O)) 
		{
			IncrementNumSuperfish (-1);
		}	
																			// the timer limit is being decremented by the modulus of the 
																			// number of super fish collected (or fire rate upgrade level, max level 10) times 0.1. if modulus = 0, +0.1
		if (numSuperFish > 10) 												// Max fire rate level is 10
		{
			numSuperFish = 10;
		}

		if (numSuperFish < 0) 												// Max fire rate level is 10
		{
			numSuperFish = 0;
		}
		if (numSuperFish == 0) 
		{
			fireTimerLimit = normalFireTimer;
		}
		if (numSuperFish == 1) 
		{
			fireTimerLimit = 1.85f;
		}
		if (numSuperFish == 2) 
		{
			fireTimerLimit = 1.7f;
		}		
		if (numSuperFish == 3) 
		{
			fireTimerLimit = 1.6f;
		}		
		if (numSuperFish == 4) 
		{
			fireTimerLimit = 1.45f;
		}		
		if (numSuperFish == 5) 
		{
			fireTimerLimit = 1.3f;
		}		
		if (numSuperFish == 6) 
		{
			fireTimerLimit = 1.15f;
		}		
		if (numSuperFish == 7) 
		{
			fireTimerLimit = 1f;
		}		
		if (numSuperFish == 8) 
		{
			fireTimerLimit = .85f;
		}		
		if (numSuperFish == 9) 
		{
			fireTimerLimit = .7f;
		}		
		if (numSuperFish == 10) 
		{
			fireTimerLimit = .5f;
		}

		
	}

	public void IncrementNumSuperfish (int _increment)
	{
		numSuperFish += _increment;
	}

	public void FireRateLevelUp ()
	{
		numSuperFish ++;
	}

	public void FireRateLevelDown ()
	{
		numSuperFish = numSuperFish - 3;
	}

	public float FireTimerLimit ()
	{
		return fireTimerLimit;
	}

}
