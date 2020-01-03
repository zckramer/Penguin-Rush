//Using a basic bullet mechanic to launch and propel the shockwave like a bullet from a gun

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Earthquake : MonoBehaviour {

    public GameObject EQ_Emitter;
    public GameObject Shockwave;
    public float ShockwaveForwardForce;

    //For camera shake
    public float shakeTimer;
    public float shakeAmount;
    public CameraShake camShake;
  
	// Use this for initialization
	void Start ()
    {
		
	}

	
	// Update is called once per frame
	void OnTriggerEnter (Collider other)
    {
        if (other.tag == "Earthquake")
        {
           
            GameObject TemporaryShockwaveHandler;
            TemporaryShockwaveHandler = Instantiate(Shockwave, EQ_Emitter.transform.position, EQ_Emitter.transform.rotation) as GameObject;

            Rigidbody Temporary_RigidBody;
            Temporary_RigidBody = TemporaryShockwaveHandler.GetComponent<Rigidbody>();

            Temporary_RigidBody.AddForce(transform.right * ShockwaveForwardForce);

            Destroy(TemporaryShockwaveHandler, 5.0f);

            Destroy(other.gameObject);
        }

    }

}
