using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flamethrower : MonoBehaviour {

    public Transform Flame;


	// Use this for initialization
	void Start ()
    {
        Flame.gameObject.SetActive(false);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetKeyDown(KeyCode.F))
            Flame.gameObject.SetActive(true);
        if (Input.GetKeyDown(KeyCode.G))
            Flame.gameObject.SetActive(false);
    }

  
}
