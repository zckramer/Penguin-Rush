﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PickupData : MonoBehaviour
{
    PenguinData penguindata;
    public GameObject EnergyDrinkPickup;
    public GameObject IceCubePickup;
    public GameObject HotRockPickup;
    public GameObject DirtPickup;
    public GameObject SlickMudPickup;
    public GameObject EarthquakePickup;
    public GameObject LeafRaftPickup;
    public bool ActivePowerup;
    private PlayerLog eventLog;

	// Pickup feedback particle reference
	public GameObject pickupParticleObj;
	public Transform penguinTransform;

    public Canvas canvas;

	void Start()
    {
        penguindata = GetComponent<PenguinData>();
        eventLog = GetComponent<PlayerLog>();		
        EarthquakePickup.GetComponent<Earthquake>().enabled = false;      
        LeafRaftPickup.GetComponent<LeafRaft>().enabled = false;
	}
    
    void OnTriggerEnter(Collider other)
    {
        if (ActivePowerup == true)
        {
           Destroy(GameObject.FindWithTag("Dirt"));
            
           Destroy(GameObject.FindWithTag("IceCube"));
           
            Destroy(GameObject.FindWithTag("HotRock"));
           
            Destroy(GameObject.FindWithTag("SlickMud"));             
        }

        if (ActivePowerup == false)
        {
            if (other.tag == "Dirt")
            {
                eventLog.NewActivity("Dirt Pickup Acquired");
                penguindata.isCrusty = true;
                   
				MakePickupParticle ();
			}

            if (other.tag == "SlickMud")
            {
                eventLog.NewActivity("SlickMud Pickup Acquired");
                penguindata.isSlimey = true;
                
                MakePickupParticle();
            }

            if (other.tag == "HotRock")
            {
                eventLog.NewActivity("HotRock Pickup Acquired");
                penguindata.isInferno = true;              

                MakePickupParticle();
            }

            if (other.tag == "IceCube")
            {
                eventLog.NewActivity("IceCube Pickup Acquired");
                penguindata.isFrozen = true;               

                MakePickupParticle();
            }

			if (other.tag == "SpeedUp")
            {
                eventLog.NewActivity("Energy Drink Pickup Acquired");
                        
				MakePickupParticle ();      
			}

            if (other.tag == "Earthquake")
            {
                eventLog.NewActivity("Earthquake Pickup Acquired");                             
             
                EarthquakePickup.GetComponent<Earthquake>().enabled = true;
                                     
				MakePickupParticle ();
			}
                
            if (other.tag == "LeafRaft")
            {
                eventLog.NewActivity("LeafRaft Pickup Acquired");
          
				LeafRaftPickup.GetComponent<LeafRaft>().enabled = true;
				MakePickupParticle ();       
            }             	
		}
 }

	void MakePickupParticle ()
	{
		Instantiate (pickupParticleObj, penguinTransform);
	}

}


