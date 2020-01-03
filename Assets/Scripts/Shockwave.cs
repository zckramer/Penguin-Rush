using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shockwave : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Destroy(gameObject, 5f);
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MajorObstacle" || other.tag == "MinorObstacle" || other.tag == "DestructibleObstacle" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
