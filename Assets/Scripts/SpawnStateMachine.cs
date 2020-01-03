using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnStateMachine : MonoBehaviour 
{
	private enum SpawnState
	{
		SPIRAL_WALLS_RIGHT,
		SPIRAL_WALLS_LEFT,
		POSTS_0_2,
		POSTS_1_3,
		RANDOM,
        RIGHT_ONLY,
        LEFT_ONLY,

		EMPTY
	}
	[SerializeField]
	SpawnState curState;
	Dictionary <SpawnState, Action> ssm = new Dictionary <SpawnState, Action>();

	// Spawner Variables
	public GameObject[] spawnPrefabs;
	public GameObject[] spawnPoint;		// This array is where each spawner is placed, starting at 12 o'clock and moving clockwise, is 0, 1, 2, 3...
	private int rotationSpeed = 50;

	// Timer Functions
	[SerializeField]
	private float timer = 0f;
	private float timerLimit = 4.0f;	// each state will draw a pattern for 4 seconds
	private float burstTimerLimit; 		// this will be the timer limit divided by the number of instances of obstacles. So, 7 obstacles would be 4/7
	float spawnTimer = 0f;
	float randomTimer = 0f;
	float quarterSecond = 0.25f;
	float halfSecond = 0.5f;
	float oneSecond = 1f;

    GameObject spawnedObjectHolder;

	// Use this for initialization
	void Start () 
	{
		ssm.Add (SpawnState.EMPTY, StateEmpty);
		ssm.Add (SpawnState.SPIRAL_WALLS_RIGHT, StateSpiralWallsRight);
		ssm.Add (SpawnState.SPIRAL_WALLS_LEFT, StateSpiralWallsLeft);
		ssm.Add (SpawnState.POSTS_0_2, StatePostsA);
		ssm.Add (SpawnState.POSTS_1_3, StatePostsB);
		ssm.Add (SpawnState.RANDOM, StateRandom);
        ssm.Add(SpawnState.RIGHT_ONLY, RightOnly);
        ssm.Add(SpawnState.LEFT_ONLY, LeftOnly);

        curState = SpawnState.EMPTY;
        spawnedObjectHolder = GameObject.Find("SpawnedObjectHolder");
	}
	
	// Update is called once per frame
	void Update () 
	{
		ssm [curState].Invoke();
	}

	void SetState (SpawnState _newState)
	{
		curState = _newState;
	}
																// State Patterns
	void StateSpiralWallsRight ()
	{
		PatternTimerHandler ();
	
		spawnTimer += Time.deltaTime;
		SpinAndSpawnMinors (1);
	}

	void StateSpiralWallsLeft ()
	{
		PatternTimerHandler ();

		spawnTimer += Time.deltaTime;
		SpinAndSpawnMinors (-1);
	}

	void StatePostsA()
	{		
		rotationSpeed = 0;	// this gets reset back to 50 during ResetState function
		PatternTimerHandler();
		SpinSpawners (1);	// clockwise

		//make a timer and dual spawns
		int randObjIndex = UnityEngine.Random.Range (6, 7);

		spawnTimer += Time.deltaTime;
		if (spawnTimer >= (oneSecond * 2)) 
		{
			Instantiate (spawnPrefabs [randObjIndex], spawnPoint [0].transform.position, spawnPoint[0].transform.rotation, spawnedObjectHolder.transform);
			Instantiate (spawnPrefabs [randObjIndex], spawnPoint [2].transform.position, spawnPoint[2].transform.rotation, spawnedObjectHolder.transform);

			spawnTimer = 0f;
		}
	}

	void StatePostsB()
	{
		rotationSpeed = 3000;	// this gets reset back to 50 during ResetState function
		PatternTimerHandler();
		SpinSpawners (-1);	// clockwise
		SpawnDualPrefabs(3, 4);	// twice per pattern, spawn a regular fish pickup or a super fish

	}

	void StateRandom()
	{
		PatternTimerHandler ();
		rotationSpeed = 1000;

		SpinSpawners (-1);

		int randObjIndex = UnityEngine.Random.Range (0, spawnPrefabs.Length - 1);
		int randTransformIndex = UnityEngine.Random.Range (0, spawnPoint.Length - 1);

		randomTimer += Time.deltaTime;
		if (randomTimer >= quarterSecond) 
		{
			Debug.Log ("randomTimer >= a quarter second. Resetting to a random number.");
			Instantiate (spawnPrefabs [randObjIndex], spawnPoint [randTransformIndex].transform.position, spawnPoint[randTransformIndex].transform.rotation, spawnedObjectHolder.transform);
			randomTimer = UnityEngine.Random.Range (0, quarterSecond);
		}
	}

    void RightOnly()//By John  --  creates dashed lines that in theory mean the player can only go counter-clockwise
    {
        rotationSpeed = 50;
        PatternTimerHandler();

        spawnTimer += Time.deltaTime;


        transform.Rotate(new Vector3(0, 0, (rotationSpeed)) * Time.deltaTime, Space.Self);

        if (spawnTimer < 0.5f)
        {
            Instantiate(spawnPrefabs[0], spawnPoint[0].transform.position, spawnPoint[0].transform.rotation, spawnedObjectHolder.transform);
            Instantiate(spawnPrefabs[0], spawnPoint[2].transform.position, spawnPoint[2].transform.rotation, spawnedObjectHolder.transform);

        }
        if (spawnTimer > 0.5f && spawnTimer < 1f)
        {
            Instantiate(spawnPrefabs[0], spawnPoint[1].transform.position, spawnPoint[1].transform.rotation, spawnedObjectHolder.transform);
            Instantiate(spawnPrefabs[0], spawnPoint[3].transform.position, spawnPoint[3].transform.rotation, spawnedObjectHolder.transform);
            spawnTimer = 0f;
        }
        Debug.Log(spawnPrefabs[0].name);
    }

    void LeftOnly()//By John  --  creates dashed lines that in theory mean the player can only go clockwise
    {
        rotationSpeed = 50;
        PatternTimerHandler();

        spawnTimer += Time.deltaTime;


        transform.Rotate(new Vector3(0, 0, (rotationSpeed * -1)) * Time.deltaTime, Space.Self);

        if (spawnTimer < 0.5f)
        {
            Instantiate(spawnPrefabs[0], spawnPoint[0].transform.position, spawnPoint[0].transform.rotation, spawnedObjectHolder.transform);
            Instantiate(spawnPrefabs[0], spawnPoint[2].transform.position, spawnPoint[2].transform.rotation, spawnedObjectHolder.transform);

        }
        if (spawnTimer > 0.5f && spawnTimer < 1f)
        {
            Instantiate(spawnPrefabs[0], spawnPoint[1].transform.position, spawnPoint[1].transform.rotation, spawnedObjectHolder.transform);
            Instantiate(spawnPrefabs[0], spawnPoint[3].transform.position, spawnPoint[3].transform.rotation, spawnedObjectHolder.transform);
            spawnTimer = 0f;
        }
    }

    void StateEmpty ()
	{
		PatternTimerHandler ();
	}

						// End State Patterns
	// Helper Functions
	void SpawnDualPrefabs(int _pickupChoice1, int _pickupChoice2)			// random chance between two items in the spawnPrefab array. Must have TWO parameters, low and high
	{
		//make a timer and dual pickup spawns on 0 and 2
		int randObjIndex = UnityEngine.Random.Range (_pickupChoice1, _pickupChoice2);

		spawnTimer += Time.deltaTime;
		if (spawnTimer >= oneSecond) 
		{
			Instantiate (spawnPrefabs [randObjIndex], spawnPoint [0].transform.position, spawnPoint[0].transform.rotation, spawnedObjectHolder.transform);
			Instantiate (spawnPrefabs [randObjIndex], spawnPoint [2].transform.position, spawnPoint[2].transform.rotation, spawnedObjectHolder.transform);

			spawnTimer = 0f;
		}

	}
	void SpinAndSpawnMinors(int _direction)			// Clockwise is 1, Counter Clockwise is -1, 0 is stopped
	{
		randomTimer += Time.deltaTime;

		transform.Rotate (new Vector3 (0, 0, (rotationSpeed * _direction)) * Time.deltaTime, Space.Self);

		if (spawnTimer >= 0.25f) 
		{
			Instantiate (spawnPrefabs [0], spawnPoint [0].transform.position, spawnPoint[0].transform.rotation, spawnedObjectHolder.transform);
			Instantiate (spawnPrefabs [0], spawnPoint [2].transform.position, spawnPoint[2].transform.rotation, spawnedObjectHolder.transform);
			spawnTimer = 0f;
		}
		if (randomTimer >= oneSecond) 
		{
			Instantiate (spawnPrefabs [3], spawnPoint [1].transform.position, spawnPoint[0].transform.rotation, spawnedObjectHolder.transform);
			randomTimer = 0;
		}
	}

	void SpinSpawners(int _direction)
	{
		transform.Rotate (new Vector3 (0, 0, (rotationSpeed * _direction)) * Time.deltaTime, Space.Self);

	}

	// Timer Functions
	void PatternTimerHandler()
	{
		timer += Time.deltaTime;

		// Pattern Randomizer
		if (timer >= timerLimit) 		// Each state runs for 4 seconds, then changes pattern
		{
			ResetState ();	
			SetNextPatternState ();
		}

	}

	void ResetState()
	{
		timer = 0.0f;					// Perhaps here we should go to a default state for a frame?
		rotationSpeed = 50;
	}

	// Random Pattern Selector
	void SetNextPatternState()			// Randomly choose the next pattern state
	{
		int patternIndex;
		patternIndex = UnityEngine.Random.Range (1, 8);		// you have to continue to increase the max range as you add patterns
		Debug.Log("random pattern index is: " + patternIndex);

		if (patternIndex == 1) 
		{
			SetState (SpawnState.SPIRAL_WALLS_RIGHT);
		}
		if (patternIndex == 2) 
		{
			SetState (SpawnState.SPIRAL_WALLS_LEFT);
		}
		if (patternIndex == 3) 
		{
			SetState (SpawnState.RANDOM);
		}
		if (patternIndex == 4) 
		{
			SetState (SpawnState.POSTS_0_2);
		}
		if (patternIndex == 5) 
		{
			SetState (SpawnState.POSTS_1_3);
		}
        if (patternIndex == 6)
        {
            SetState(SpawnState.RIGHT_ONLY);
        }
        if (patternIndex == 7)
        {
            SetState(SpawnState.LEFT_ONLY);
        }
        if (patternIndex == 8) 
		{
			SetNextPatternState ();
		}
	
	}

	void CheckIfEmpty(int _atPositionInArray)		// too terrified to start this
	{
		
	}


}
