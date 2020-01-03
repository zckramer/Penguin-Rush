using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternCreator : MonoBehaviour {

    PatternHandler patternHandler;

    bool allSlotsEmpty;

    float tempTimer;

	// Use this for initialization
	void Start ()
    {
        patternHandler = GetComponentInParent<PatternHandler>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        tempTimer += Time.deltaTime;
        if (tempTimer > 2)
        {
            doRandomAll();
            tempTimer = 0;
        }
	}

    void doRandomAll()
    {
        int rand = Random.Range(1, 3);

        if(rand == 1)
        {
            patternXShape(getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject());
        }
        else if (rand == 2)
        {
            patternCross(getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject());
        }
        else if (rand == 3)
        {
            patternDownArrow(getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject(), getRandomSpawnObject());
        }
        //Debug.Log("Made a random pattern and filled it");
    }

    void patternXShape(int firstObject, int secondObject, int thirdObject, int forthObject, int fifthObject)
    {
        //  x   x
        //    x  
        //  x   x
        allSlotsEmpty = true;

        int centerSpot = Random.Range(0, 9);

        checkIfEmpty(0, centerSpot - 1);
        checkIfEmpty(0, centerSpot + 1);
        checkIfEmpty(1, centerSpot);
        checkIfEmpty(2, centerSpot - 1);
        checkIfEmpty(2, centerSpot + 1);

        if (allSlotsEmpty)
        {
            addNewEntry(new Vector3(0, centerSpot - 1, firstObject));
            addNewEntry(new Vector3(0, centerSpot + 1, secondObject));
            addNewEntry(new Vector3(1, centerSpot, thirdObject));
            addNewEntry(new Vector3(2, centerSpot - 1, forthObject));
            addNewEntry(new Vector3(2, centerSpot + 1, fifthObject));
        }
        Debug.Log("An X Shape pattern was made");
    }

    void patternCross(int firstObject, int secondObject, int thirdObject, int forthObject, int fifthObject)
    {
        //    x  
        //  x x x
        //    x  
        allSlotsEmpty = true;

        int centerSpot = Random.Range(0, 9);

        checkIfEmpty(0, centerSpot);
        checkIfEmpty(1, centerSpot + 1);
        checkIfEmpty(1, centerSpot);
        checkIfEmpty(1, centerSpot - 1);
        checkIfEmpty(2, centerSpot);

        if (allSlotsEmpty)
        {
            addNewEntry(new Vector3(0, centerSpot, firstObject));
            addNewEntry(new Vector3(1, centerSpot - 1, secondObject));
            addNewEntry(new Vector3(1, centerSpot, thirdObject));
            addNewEntry(new Vector3(1, centerSpot + 1, forthObject));
            addNewEntry(new Vector3(2, centerSpot, fifthObject));
        }
        Debug.Log("A cross shape pattern was made");
    }

    void patternDownArrow(int firstObject, int secondObject, int thirdObject, int forthObject, int fifthObject)
    {
        //  x       x
        //    x   x  
        //      x    
        allSlotsEmpty = true;

        int centerSpot = Random.Range(0, 9);

        checkIfEmpty(0, centerSpot - 2);
        checkIfEmpty(0, centerSpot + 2);
        checkIfEmpty(1, centerSpot - 1);
        checkIfEmpty(1, centerSpot + 1);
        checkIfEmpty(2, centerSpot);

        if (allSlotsEmpty)
        {
            addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
            addNewEntry(new Vector3(0, centerSpot + 2, secondObject));
            addNewEntry(new Vector3(1, centerSpot - 1, thirdObject));
            addNewEntry(new Vector3(1, centerSpot + 1, forthObject));
            addNewEntry(new Vector3(2, centerSpot, fifthObject));
        }
        Debug.Log("a DownArrow pattern was made");
    }

/*	void patternA1(int firstObject, int secondObject, int thirdObject, int forthObject, int fifthObject)
	{
		// Check Pattern Spawning Design document in drive for an illustration
		allSlotsEmpty = true;

		int centerSpot = Random.Range(0, 9);

		// Minor Obstacles
		checkIfEmpty(centerSpot -1, centerSpot + 1);
		checkIfEmpty(centerSpot -2, centerSpot + 2);
		checkIfEmpty(centerSpot -3, centerSpot + 3);
		checkIfEmpty(centerSpot -4, centerSpot + 4);
		checkIfEmpty(centerSpot -5, centerSpot + 5);
		checkIfEmpty(centerSpot -6, centerSpot + 6);
		checkIfEmpty(centerSpot -7, centerSpot + 7);
		checkIfEmpty(centerSpot -8, centerSpot + 8);
		checkIfEmpty(centerSpot -9, centerSpot + 9);
		checkIfEmpty(centerSpot -10, centerSpot + 10);
		checkIfEmpty(centerSpot -11, centerSpot + 11);
		checkIfEmpty(centerSpot, centerSpot);
		checkIfEmpty(centerSpot +1, centerSpot - 1);
		checkIfEmpty(centerSpot +2, centerSpot - 2);
		checkIfEmpty(centerSpot +3, centerSpot - 3);
		checkIfEmpty(centerSpot +4, centerSpot - 4);
		checkIfEmpty(centerSpot +5, centerSpot - 5);
		checkIfEmpty(centerSpot +6, centerSpot - 6);
		checkIfEmpty(centerSpot +7, centerSpot - 7);
		checkIfEmpty(centerSpot +8, centerSpot - 8);
		checkIfEmpty(centerSpot +9, centerSpot - 9);
		checkIfEmpty(centerSpot +10, centerSpot - 10);
		checkIfEmpty(centerSpot +11, centerSpot - 11);

		// Fish Pickups
		checkIfEmpty(centerSpot -3, centerSpot - 3);
		checkIfEmpty (centerSpot - 8, centerSpot - 8);
		checkIfEmpty (centerSpot + 8, centerSpot + 8);


		if (allSlotsEmpty)
		{
			// Minor Obstacles
			addNewEntry(new Vector3(centerSpot -1, centerSpot + 1, patternHandler.spawnables[1]));
			addNewEntry(new Vector3(centerSpot -2, centerSpot + 2, firstObject));
			addNewEntry(new Vector3(centerSpot -3, centerSpot + 3, firstObject));
			addNewEntry(new Vector3(centerSpot -4, centerSpot + 4, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));

			// Fish Pickups
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(0, centerSpot - 2, firstObject));
			addNewEntry(new Vector3(10, centerSpot - 2, firstObject));

		}
		Debug.Log("a DownArrow pattern was made");
	}
*/

    void checkIfEmpty(int x, int y)
    {
        for (int i = 0; i < patternHandler.spawnListings.Length; i++)
        {
            if(patternHandler.spawnListings[i].x == x)
            {
                if(y > 9)
                {
                    y = y - 10;
                }
                if (y < 0)
                {
                    y = y + 10;
                }
                if(patternHandler.spawnListings[i].y == y)
                {
                    if(patternHandler.spawnListings[i].z != 0)
                    {
                        allSlotsEmpty = false;
                    }
                }
            }
        }
    }

    void addNewEntry(Vector3 newEntry)
    {
        for (int i = 0; i < patternHandler.spawnListings.Length; i++)
        {
            if (patternHandler.spawnListings[i].x == 0)
            {
                if (newEntry.y > 9)
                {
                    newEntry.y = newEntry.y - 10;
                }
                if(newEntry.y < 0)
                {
                    newEntry.y = newEntry.y + 10;
                }
                if (patternHandler.spawnListings[i].y == 0)
                {
                    if (patternHandler.spawnListings[i].z == 0)
                    {
                        patternHandler.spawnListings[i] = newEntry;
                        return;
                    }
                }
            }
        }
    }

    int getRandomSpawnObject()
    {
        int randObj = Random.Range(1, patternHandler.spawnables.Length);
        return randObj;
    }

}
