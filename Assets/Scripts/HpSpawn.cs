using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpSpawn : MonoBehaviour {

    public GameObject SuperFish;

    private float timer;


	
	// Update is called once per frame
	void Update () {
        timer += Time.deltaTime;

        if (timer >= 200)
        {
            
            int randIndex = Random.Range(0, 500);
            if (randIndex == 1)
            {
                Instantiate(SuperFish, transform.position, transform.rotation);
                timer = 150;
            }
        }
        if (timer <= 50.2f && timer >= 50)
        {
            Instantiate(SuperFish, transform.position, transform.rotation);
        }
     
    }
}
