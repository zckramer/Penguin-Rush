using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySpawner : MonoBehaviour 
{
    PenguinData penguinData;
    PenguinDirectory Directory;
	PenguinMovementController penguinMovementController;

    public float timer;
	[SerializeField]
	//private int spawnRate = 4;

    // Difficulty modifiers
	public float spawnTimeMin;
	public float spawnTimeMax;
//	public float spawntimeE;
//	public float spawntimeM;
//	public float spawntimeH;
    private GameObject Penguin;
    public GameObject[] tundra;


    // Use this for initialization
    void Start () 
	{
//		spawntimeE = 5 + Random.Range(0, 10);
//		spawntimeM = 3 + Random.Range(0, 5);
//		spawntimeH = 2 + Random.Range(0, 3);
        Penguin = GameObject.Find("Penguin");
        penguinData = Penguin.GetComponent<PenguinData>();
        Directory = Penguin.GetComponent<PenguinDirectory>();
		penguinMovementController = GameObject.Find ("PenguinMovement").GetComponent<PenguinMovementController> ();
        spawnTimeMin = Directory.SpawnTimeMin;
		timer = Random.Range (10, spawnTimeMin);
        spawnTimeMax = Directory.SpawnTimeMax;
	}
	
	// Update is called once per frame
	void Update () 
	{
        spawnTimeMax = 20 - (penguinData.score / 200);
        UpdateDifficultyRating ();
		HandleSpawning ();

    }

    public void HandleSpawning()                // Difficulty, biome, and timers for spawning
    { 
		timer += Time.deltaTime;

		if (timer >= spawnTimeMin) 
		{
			int randIndex = Random.Range(0, 100);

			if (randIndex <= 49)
			{
				Spawn();
				timer = 0;
				spawnTimeMin = Random.Range(1, spawnTimeMax) - (penguinData.difficultyIndex * 0.36f);       
			}

			if (randIndex >= 50)
			{
				timer = 0;
				spawnTimeMin = Random.Range(1, spawnTimeMax) - (penguinData.difficultyIndex * 0.36f);
			}

		}
/*		
    	    //Easy Spawner
            if (gameObject.tag == "Easy" && timer >= spawntimeE && penguinData.difficultyIndex == 0)
            {
                int randIndex = Random.Range(0, 100);
                if (randIndex <= 49)
                {
                    Spawn();
                    timer = 0;
                    spawntimeE = 	//Random.Range(1, 10);       
                }

                if (randIndex >= 50)
                {
                    timer = 0;
                    spawntimeE = Random.Range(1, 10);
                }
            }

            //Medium Spawner
            if (gameObject.tag == "Medium" && timer >= spawntimeM && penguinData.difficultyIndex == 1)
            {
                int randIndex = Random.Range(0, 100);
                if (randIndex <= 49)
                {
                    Spawn();
                    timer = 0;
                    spawntimeM = Random.Range(1, 5);
                }
                if (randIndex >= 50)
                {
                    timer = 0;
                    spawntimeM = Random.Range(1, 5);
                }
            }

			//Hard Spawner
			if (gameObject.tag == "Hard" && timer >= spawntimeH && penguinData.difficultyIndex == 2)
			{
				int randIndex = Random.Range(0, 100);
				if (randIndex <= 49)
				{
					Spawn();
					timer = 0;
					spawntimeH =  Random.Range(1, 2);
				}
				if (randIndex >= 50)
				{
					timer = 0;
					spawntimeH =  Random.Range(1, 2);
				}
			}
*/
	}

	void UpdateDifficultyRating()
	{
		penguinData.difficultyIndex = penguinData.score / 500;

	}

	void Spawn ()
	{	

			int randindex = Random.Range (0, tundra.Length);
			//Debug.Log ("randIndex = " + randindex);
			Instantiate (tundra [randindex -1], transform.position, transform.rotation);

}
}
