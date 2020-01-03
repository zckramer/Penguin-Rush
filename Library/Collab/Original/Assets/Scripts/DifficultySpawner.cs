using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultySpawner : MonoBehaviour 
{
    PenguinData penguinData;
    PenguinDirectory Directory;

    public float timer;
	[SerializeField]
	//private int spawnRate = 4;

    // Difficulty modifiers
    public float spawntimeE;
    public float spawntimeM;
    public float spawntimeH;
    private GameObject Penguin;
    public GameObject[] desert;
    public GameObject[] tundra;
    public GameObject[] everglades;
    public GameObject[] savannah;


    // Use this for initialization
    void Start () 
	{
        spawntimeE = 5 + Random.Range(0, 10);
        spawntimeM = 3 + Random.Range(0, 5);
        spawntimeH = 2 + Random.Range(0, 3);
        Penguin = GameObject.Find("Penguin");
        penguinData = Penguin.GetComponent<PenguinData>();
        Directory = Penguin.GetComponent<PenguinDirectory>();

        timer = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		HandleSpawning ();

    }

    public void HandleSpawning()                // Difficulty, biome, and timers for spawning
    {
        timer += 1 * Time.deltaTime;

        //Easy Spawner
            if (gameObject.tag == "Easy" && timer >= spawntimeE && penguinData.difficultyIndex == 0)
            {
                int randIndex = Random.Range(0, 100);
                if (randIndex <= 49)
                {
                    Spawn();
                    timer = 0;
                    spawntimeE = Random.Range(1, 10);       // this is used in coroutine SpawnPatternBurst as a parameter
                                                            //StartCoroutine(SpawnPatternBurst(5));

                }
                if (randIndex >= 50)
                {
                    timer = 0;
                    spawntimeE = Random.Range(1, 10);
                }
            }

            //Medium Spawner
            if (gameObject.tag == "Medium" && timer >= spawntimeM && penguinData.difficultyIndex == 1 && penguinData.score >= 1000)
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
                if (gameObject.tag == "Hard" && timer >= spawntimeH && penguinData.difficultyIndex == 2  && penguinData.score >= 5000)
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
            }
        
                
        
/*	public IEnumerator SpawnPatternBurst(int _numberOf)			// the parameter will be the number of enemies spawned within 1 second
	{
		float spawnDelay = 60f / spawnRate;

		for (int i = 0; i < _numberOf; i++)
		{
			Spawn ();
			yield return new WaitForSeconds (spawnDelay);
//			yield return new WaitForSeconds (spawnRate);
		}

	}
*/
    void Spawn()
    {	
        if (Directory.curBiome == PenguinDirectory.biomeList.Tundra)
        {
            int randindex = Random.Range(0, tundra.Length);
			Debug.Log ("randIndex = " + randindex);
            Instantiate(tundra[randindex], transform.position, transform.rotation);
        }
        if (Directory.curBiome == PenguinDirectory.biomeList.HighDesert)
        {
            int randindex = Random.Range(0, desert.Length);
            Instantiate(desert[randindex], transform.position, transform.rotation);
        }
        if (Directory.curBiome == PenguinDirectory.biomeList.Everglades)
        {
            int randindex = Random.Range(0, everglades.Length);
            Instantiate(everglades[randindex], transform.position, transform.rotation);
        }
        if (Directory.curBiome == PenguinDirectory.biomeList.Savanna)
        {
            int randindex = Random.Range(0, savannah.Length);
            Instantiate(savannah[randindex], transform.position, transform.rotation);
        }
    }

}
