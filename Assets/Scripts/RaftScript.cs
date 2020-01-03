using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftScript : MonoBehaviour {

    //public Transform penguin;
    public Transform raft;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void ActivateRaft()
    {
        raft.gameObject.SetActive(true);
        GetComponentInParent<PenguinDirectory>().activeShields++;
        Debug.Log("Picked up Leaf Raft");
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "LeafRaft")

        //if (raft.gameObject.activeInHierarchy == false)
        {
            raft.gameObject.SetActive(true);
            GetComponentInParent<PenguinDirectory>().activeShields++;
            Debug.Log("Picked up Leaf Raft");
            Destroy(other.gameObject);
        }
    
        else if (other.tag == "MajorObstacle" || other.tag == "MinorObstacle" || other.tag == "Target")
        {
            //Destroy(other.gameObject);
            raft.gameObject.SetActive(false);
            Debug.Log("Hit Obstacle");
            Destroy(other.gameObject);
        }
    }
}
