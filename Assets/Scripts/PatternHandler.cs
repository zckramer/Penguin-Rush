using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternHandler : MonoBehaviour {

    #region Variables

    public Vector3[] spawnListings;

    [SerializeField]
    public GameObject[] spawnables;

    [SerializeField]
    GameObject[] objectSpawners;

    [SerializeField]
    float tempTimer;

    #endregion

    // Use this for initialization
    void Start ()
    {

        spawnListings = new Vector3[30];

	}
	
	// Update is called once per frame
	void Update ()
    {

        if (Input.GetKeyDown(KeyCode.J))
        {
            debugFullArray();
        }

        tempTimer += Time.deltaTime;
        if (true)
        {
            Debug.Log("Did timer check");
            if (tempTimer > 0.3)
            {
                Debug.Log(tempTimer + " > 0.3. It will be reset to 0");
                UpdateListings();
                tempTimer = 0;
                Debug.Log("It has been reset to 0");
            }
            else if(tempTimer < 0.3)
            {
                Debug.Log(tempTimer + " < 0.3");
            }
        }
        //Debug.Log("spawnListings[4] = " + spawnListings[4]);

	}

    void UpdateListings()
    {
        for(int i = 0; i < spawnListings.Length; i++)
        {
            if(spawnListings[i].x == 0)
            {
                doSpawning(spawnListings[i]);
                spawnListings[i] = new Vector3(0, 0, 0);
                Debug.Log("Beer here fear");
            }
            else if(spawnListings[i].x > 0)
            {
                Debug.Log("jerry can henry");
                spawnListings[i].x--;
            }
            
        }
    }

    void doSpawning(Vector3 spawnData)
    {
        if(spawnData.z == 0)
        {
            return;
        }
        
        if(objectSpawners[(int)spawnData.y] == null)
        {
            Debug.Log("Spawner number " + spawnData.y + " is unplugged");
        }

        if(spawnData.y > 9)
        {
            spawnData.y -= 10;
        }
        else if (spawnData.y < 0)
        {
            spawnData.y += 10;
        }

        Debug.Log("doSpawning says " + spawnData);

        Instantiate(spawnables[(int)spawnData.z], objectSpawners[(int)spawnData.y].transform.position, objectSpawners[(int)spawnData.y].transform.rotation);

    }

    void debugFullArray()
    {
        Debug.Log("~~~~~~~~~~~~~~~ Full Array Dump Start ~~~~~~~~~~~~~~~");
        for(int i = 0; i < spawnListings.Length; i++)
        {
            Debug.Log(spawnListings[i]);
        }
        Debug.Log("~~~~~~~~~~~~~~~ Full Array Dump End ~~~~~~~~~~~~~~~");
    }

}
