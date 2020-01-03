using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementScript : MonoBehaviour {

    PenguinMovementController penguinMovementReference;

	// Use this for initialization
	void Start ()
    {
        penguinMovementReference = GameObject.Find("PenguinMovement").GetComponent<PenguinMovementController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        updateObjectMovement();
        deathCheck();
	}

    void updateObjectMovement()
    {
        //uses penguin speed to adjust the movement of all objects in scene so the faster penguin 'moves' the fast everything else moves
		gameObject.transform.Translate(0, 0, Time.deltaTime * -1 * penguinMovementReference.GetComponent<PenguinMovementController>().movementSpeed, Space.World);
		gameObject.transform.Translate(0, 0, -1 * Time.deltaTime * penguinMovementReference.movementSpeed, Space.World);
    }

	void OnBecameInvis ()
	{
		Destroy (gameObject, 1f);
	}

    void deathCheck()
    {
        if(gameObject.transform.position.z < GameObject.Find("Penguin").transform.position.z)
        {
            Destroy(gameObject, 2f);
        }
    }

}
