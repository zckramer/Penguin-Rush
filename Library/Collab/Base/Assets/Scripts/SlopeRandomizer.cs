using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlopeRandomizer : MonoBehaviour {

    #region

    [SerializeField]
    int frequencyOfBranchingSlopes;

    [SerializeField]
    private int randNum;

    [SerializeField]
    GameObject slopeHolder;

    #region Slope holding variables
    
    [SerializeField]
    GameObject TundraDefaultSlope;
    [SerializeField]
    GameObject TundraSlopeMajorLeft;
    [SerializeField]
    GameObject TundraSlopeMajorRight;
    [SerializeField]
    GameObject TundraSlopeMinorLeft;
    [SerializeField]
    GameObject TundraSlopeMinorRight;
    [SerializeField]
    GameObject TundraSlopeDestructibleLeft;
    [SerializeField]
    GameObject TundraSlopeDestructibleRight;
    [SerializeField]
    GameObject TundraFishJackpotSlope;
    [SerializeField]
    GameObject TundraBranchOffLeftEverglades;
    [SerializeField]
    GameObject TundraBranchOffLeftSavanna;
    [SerializeField]
    GameObject TundraBranchOffLeftHighDesert;
    [SerializeField]
    GameObject TundraBranchOffRightEverglades;
    [SerializeField]
    GameObject TundraBranchOffRightSavanna;
    [SerializeField]
    GameObject TundraBranchOffRightHighDesert;
    [SerializeField]
    GameObject TundraPickupSpawningSlope;
    [SerializeField]
    GameObject TundraTurtleCrossingSlope;
    [SerializeField]
    GameObject TundraBugFlyingSlope;
    [SerializeField]
    GameObject newTundraSlope1;
    [SerializeField]
    GameObject newTundraSlope2;
    [SerializeField]
    GameObject newTundraSlope3;
    [SerializeField]
    GameObject newTundraSlope4;
    [SerializeField]
    GameObject newTundraSlope5;
    [SerializeField]
    GameObject newTundraSlope6;
    [SerializeField]
    GameObject newTundraSlope7;

    [SerializeField]
    GameObject HighDesertDefaultSlope;
    [SerializeField]
    GameObject HighDesertSlopeMajorLeft;
    [SerializeField]
    GameObject HighDesertSlopeMajorRight;
    [SerializeField]
    GameObject HighDesertSlopeMinorLeft;
    [SerializeField]
    GameObject HighDesertSlopeMinorRight;
    [SerializeField]
    GameObject HighDesertSlopeDestructibleLeft;
    [SerializeField]
    GameObject HighDesertSlopeDestructibleRight;
    [SerializeField]
    GameObject HighDesertFishJackpotSlope;
    [SerializeField]
    GameObject HighDesertBranchOffLeftTundra;
    [SerializeField]
    GameObject HighDesertBranchOffLeftEverglades;
    [SerializeField]
    GameObject HighDesertBranchOffLeftSavanna;
    [SerializeField]
    GameObject HighDesertBranchOffRightTundra;
    [SerializeField]
    GameObject HighDesertBranchOffRightEverglades;
    [SerializeField]
    GameObject HighDesertBranchOffRightSavanna;
    [SerializeField]
    GameObject HighDesertPickupSpawningSlope;
    [SerializeField]
    GameObject HighDesertTurtleCrossingSlope;
    [SerializeField]
    GameObject HighDesertBugFlyingSlope;
    [SerializeField]
    GameObject newHighDesertSlope1;
    [SerializeField]
    GameObject newHighDesertSlope2;
    [SerializeField]
    GameObject newHighDesertSlope3;
    [SerializeField]
    GameObject newHighDesertSlope4;
    [SerializeField]
    GameObject newHighDesertSlope5;
    [SerializeField]
    GameObject newHighDesertSlope6;
    [SerializeField]
    GameObject newHighDesertSlope7;

    [SerializeField]
    GameObject SavannaDefaultSlope;
    [SerializeField]
    GameObject SavannaSlopeMajorLeft;
    [SerializeField]
    GameObject SavannaSlopeMajorRight;
    [SerializeField]
    GameObject SavannaSlopeMinorLeft;
    [SerializeField]
    GameObject SavannaSlopeMinorRight;
    [SerializeField]
    GameObject SavannaSlopeDestructibleLeft;
    [SerializeField]
    GameObject SavannaSlopeDestructibleRight;
    [SerializeField]
    GameObject SavannaFishJackpotSlope;
    [SerializeField]
    GameObject SavannaBranchOffLeftTundra;
    [SerializeField]
    GameObject SavannaBranchOffLeftEverglades;
    [SerializeField]
    GameObject SavannaBranchOffLeftHighDesert;
    [SerializeField]
    GameObject SavannaBranchOffRightTundra;
    [SerializeField]
    GameObject SavannaBranchOffRightEverglades;
    [SerializeField]
    GameObject SavannaBranchOffRightHighDesert;
    [SerializeField]
    GameObject SavannaPickupSpawningSlope;
    [SerializeField]
    GameObject SavannaTurtleCrossingSlope;
    [SerializeField]
    GameObject SavannaBugFlyingSlope;
    [SerializeField]
    GameObject newSavannaSlope1;
    [SerializeField]
    GameObject newSavannaSlope2;
    [SerializeField]
    GameObject newSavannaSlope3;
    [SerializeField]
    GameObject newSavannaSlope4;
    [SerializeField]
    GameObject newSavannaSlope5;
    [SerializeField]
    GameObject newSavannaSlope6;
    [SerializeField]
    GameObject newSavannaSlope7;

    [SerializeField]
    GameObject EvergladesDefaultSlope;
    [SerializeField]
    GameObject EvergladesSlopeMajorLeft;
    [SerializeField]
    GameObject EvergladesSlopeMajorRight;
    [SerializeField]
    GameObject EvergladesSlopeMinorLeft;
    [SerializeField]
    GameObject EvergladesSlopeMinorRight;
    [SerializeField]
    GameObject EvergladesSlopeDestructibleLeft;
    [SerializeField]
    GameObject EvergladesSlopeDestructibleRight;
    [SerializeField]
    GameObject EvergladesFishJackpotSlope;
    [SerializeField]
    GameObject EvergladesBranchOffLeftTundra;
    [SerializeField]
    GameObject EvergladesBranchOffLeftSavanna;
    [SerializeField]
    GameObject EvergladesBranchOffLeftHighDesert;
    [SerializeField]
    GameObject EvergladesBranchOffRightTundra;
    [SerializeField]
    GameObject EvergladesBranchOffRightSavanna;
    [SerializeField]
    GameObject EvergladesBranchOffRightHighDesert;
    [SerializeField]
    GameObject EvergladesPickupSpawningSlope;
    [SerializeField]
    GameObject EvergladesTurtleCrossingSlope;
    [SerializeField]
    GameObject EvergladesBugFlyingSlope;
    [SerializeField]
    GameObject newEvergladesSlope1;
    [SerializeField]
    GameObject newEvergladesSlope2;
    [SerializeField]
    GameObject newEvergladesSlope3;
    [SerializeField]
    GameObject newEvergladesSlope4;
    [SerializeField]
    GameObject newEvergladesSlope5;
    [SerializeField]
    GameObject newEvergladesSlope6;
    [SerializeField]
    GameObject newEvergladesSlope7;

    #endregion

    GameObject PenguinGameObject;

    //SlopeMovement slopeMovement;

    int numOfSlopesSinceTransition;

    GameObject slopeToBeSpawned;
    Vector3 slopeSpawnDestination;
    Vector3 slopeSpawnRotation;

    float BranchDistanceHolder;

    GameObject mostRecentSlope;//var to hold most recent slope so the branch maker can apply proper rotation

    //bool isBranch;//a simple bool that allows the branching paths to bypass the biome spawning ristriction

    #endregion

    // Use this for initialization
    void Start ()
    {
        slopeHolder = GameObject.Find("SlopeHolder");
        PenguinGameObject = GameObject.Find("PenguinMovement/Penguin");
	}
	
	// Update is called once per frame
	void Update ()
    {
         	
	}

    public void spawnNewSlope(Vector3 slopeSpawnLocation, PenguinDirectory.biomeList requestedBiome, bool isBranch)
    {
        randNum = Random.Range(1, 19);

        if (PenguinGameObject.GetComponent<PenguinDirectory>().curBiome == requestedBiome || isBranch)
        {
            numOfSlopesSinceTransition += 1;
            if (requestedBiome == PenguinDirectory.biomeList.Tundra)
            {
                #region Tundra

                #region TundraBranchOffSlopes
                if (numOfSlopesSinceTransition > frequencyOfBranchingSlopes && randNum < 7)
                {
                    numOfSlopesSinceTransition = 0;
                    if (randNum == 1)
                    {
                        slopeToBeSpawned = TundraBranchOffLeftEverglades;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Everglades);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 2)
                    {
                        slopeToBeSpawned = TundraBranchOffLeftHighDesert;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.HighDesert);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 3)
                    {
                        slopeToBeSpawned = TundraBranchOffLeftSavanna;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Savanna);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 4)
                    {
                        slopeToBeSpawned = TundraBranchOffRightEverglades;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Everglades);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 5)
                    {
                        slopeToBeSpawned = TundraBranchOffRightHighDesert;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();
                        
                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.HighDesert);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 6)
                    {
                        slopeToBeSpawned = TundraBranchOffRightSavanna;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Savanna);
                        Debug.Log("Unfinished");
                    }
                    numOfSlopesSinceTransition = 0;
                    return;
                }
                #endregion

                if (randNum == 1)
                {
                    slopeToBeSpawned = TundraDefaultSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 2)
                {
                    slopeToBeSpawned = TundraSlopeMinorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 3)
                {
                    slopeToBeSpawned = TundraSlopeMinorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 4)
                {
                    slopeToBeSpawned = TundraSlopeMajorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 5)
                {
                    slopeToBeSpawned = TundraSlopeMajorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 6)
                {
                    slopeToBeSpawned = TundraSlopeDestructibleLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 7)
                {
                    slopeToBeSpawned = TundraSlopeDestructibleRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 8)
                {
                    slopeToBeSpawned = TundraFishJackpotSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 9)
                {
                    slopeToBeSpawned = TundraPickupSpawningSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 10)
                {
                    slopeToBeSpawned = TundraTurtleCrossingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 11)
                {
                    slopeToBeSpawned = TundraBugFlyingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 12)
                {
                    slopeToBeSpawned = newTundraSlope1;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 13)
                {
                    slopeToBeSpawned = newTundraSlope2;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 14)
                {
                    slopeToBeSpawned = newTundraSlope3;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 15)
                {
                    slopeToBeSpawned = newTundraSlope4;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 16)
                {
                    slopeToBeSpawned = newTundraSlope5;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 17)
                {
                    slopeToBeSpawned = newTundraSlope6;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 18)
                {
                    slopeToBeSpawned = newTundraSlope7;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                #endregion
            }

            if (requestedBiome == PenguinDirectory.biomeList.HighDesert)
            {
                #region HighDesert

                #region HighDesertBranchOffSlopes
                if (numOfSlopesSinceTransition > frequencyOfBranchingSlopes && randNum < 7)
                {

                    numOfSlopesSinceTransition = 0;
                    if (randNum == 1)
                    {
                        slopeToBeSpawned = HighDesertBranchOffLeftEverglades;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Everglades);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 2)
                    {
                        slopeToBeSpawned = HighDesertBranchOffLeftSavanna;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Savanna);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 3)
                    {
                        slopeToBeSpawned = HighDesertBranchOffLeftTundra;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Tundra);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 4)
                    {
                        slopeToBeSpawned = HighDesertBranchOffRightEverglades;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Everglades);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 5)
                    {
                        slopeToBeSpawned = HighDesertBranchOffRightSavanna;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Savanna);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 6)
                    {
                        slopeToBeSpawned = HighDesertBranchOffRightTundra;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Tundra);
                        Debug.Log("Unfinished");
                    }
                    return;
                }
                #endregion

                if (randNum == 1)
                {
                    slopeToBeSpawned = HighDesertDefaultSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 2)
                {
                    slopeToBeSpawned = HighDesertSlopeMinorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 3)
                {
                    slopeToBeSpawned = HighDesertSlopeMinorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 4)
                {
                    slopeToBeSpawned = HighDesertSlopeMajorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 5)
                {
                    slopeToBeSpawned = HighDesertSlopeMajorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 6)
                {
                    slopeToBeSpawned = HighDesertSlopeDestructibleLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 7)
                {
                    slopeToBeSpawned = HighDesertSlopeDestructibleRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 8)
                {
                    slopeToBeSpawned = HighDesertFishJackpotSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 9)
                {
                    slopeToBeSpawned = HighDesertPickupSpawningSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 10)
                {
                    slopeToBeSpawned = HighDesertTurtleCrossingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 11)
                {
                    slopeToBeSpawned = HighDesertBugFlyingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 12)
                {
                    slopeToBeSpawned = newHighDesertSlope1;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 13)
                {
                    slopeToBeSpawned = newHighDesertSlope2;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 14)
                {
                    slopeToBeSpawned = newHighDesertSlope3;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 15)
                {
                    slopeToBeSpawned = newHighDesertSlope4;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 16)
                {
                    slopeToBeSpawned = newHighDesertSlope5;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 17)
                {
                    slopeToBeSpawned = newHighDesertSlope6;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 18)
                {
                    slopeToBeSpawned = newHighDesertSlope7;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                #endregion
            }

            if (requestedBiome == PenguinDirectory.biomeList.Savanna)
            {
                #region Savanna

                #region SavannaBranchOffSlopes
                if (numOfSlopesSinceTransition > frequencyOfBranchingSlopes && randNum < 7)
                {

                    numOfSlopesSinceTransition = 0;
                    if (randNum == 1)
                    {
                        slopeToBeSpawned = SavannaBranchOffLeftEverglades;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Everglades);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 2)
                    {
                        slopeToBeSpawned = SavannaBranchOffLeftHighDesert;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.HighDesert);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 3)
                    {
                        slopeToBeSpawned = SavannaBranchOffLeftTundra;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Tundra);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 4)
                    {
                        slopeToBeSpawned = SavannaBranchOffRightEverglades;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Everglades);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 5)
                    {
                        slopeToBeSpawned = SavannaBranchOffRightHighDesert;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.HighDesert);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 6)
                    {
                        slopeToBeSpawned = SavannaBranchOffRightTundra;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Tundra);
                        Debug.Log("Unfinished");
                    }
                    return;
                }
                #endregion

                if (randNum == 1)
                {
                    slopeToBeSpawned = SavannaDefaultSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 2)
                {
                    slopeToBeSpawned = SavannaSlopeMinorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 3)
                {
                    slopeToBeSpawned = SavannaSlopeMinorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 4)
                {
                    slopeToBeSpawned = SavannaSlopeMajorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 5)
                {
                    slopeToBeSpawned = SavannaSlopeMajorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 6)
                {
                    slopeToBeSpawned = SavannaSlopeDestructibleLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 7)
                {
                    slopeToBeSpawned = SavannaSlopeDestructibleRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 8)
                {
                    slopeToBeSpawned = SavannaFishJackpotSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 9)
                {
                    slopeToBeSpawned = SavannaPickupSpawningSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 10)
                {
                    slopeToBeSpawned = SavannaTurtleCrossingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 11)
                {
                    slopeToBeSpawned = SavannaBugFlyingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 12)
                {
                    slopeToBeSpawned = newSavannaSlope1;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 13)
                {
                    slopeToBeSpawned = newSavannaSlope2;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 14)
                {
                    slopeToBeSpawned = newSavannaSlope3;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 15)
                {
                    slopeToBeSpawned = newSavannaSlope4;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 16)
                {
                    slopeToBeSpawned = newSavannaSlope5;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 17)
                {
                    slopeToBeSpawned = newSavannaSlope6;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 18)
                {
                    slopeToBeSpawned = newSavannaSlope7;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                #endregion
            }

            if (requestedBiome == PenguinDirectory.biomeList.Everglades)
            {
                #region Everglades

                #region EvergladesBranchOffSlopes
                if (numOfSlopesSinceTransition > frequencyOfBranchingSlopes && randNum < 7)
                {

                    numOfSlopesSinceTransition = 0;
                    if (randNum == 1)
                    {
                        slopeToBeSpawned = EvergladesBranchOffLeftHighDesert;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.HighDesert);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 2)
                    {
                        slopeToBeSpawned = EvergladesBranchOffLeftSavanna;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Savanna);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 3)
                    {
                        slopeToBeSpawned = EvergladesBranchOffLeftTundra;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeLeftBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Tundra);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 4)
                    {
                        slopeToBeSpawned = EvergladesBranchOffRightHighDesert;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.HighDesert);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 5)
                    {
                        slopeToBeSpawned = EvergladesBranchOffRightSavanna;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Savanna);
                        Debug.Log("Unfinished");
                    }
                    else if (randNum == 6)
                    {
                        slopeToBeSpawned = EvergladesBranchOffRightTundra;
                        slopeSpawnDestination = slopeSpawnLocation;
                        doSpawning();

                        doMakeRightBranch(slopeSpawnLocation, PenguinDirectory.biomeList.Tundra);
                        Debug.Log("Unfinished");
                    }
                    return;
                }
                #endregion

                if (randNum == 1)
                {
                    slopeToBeSpawned = EvergladesDefaultSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 2)
                {
                    slopeToBeSpawned = EvergladesSlopeMinorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 3)
                {
                    slopeToBeSpawned = EvergladesSlopeMinorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 4)
                {
                    slopeToBeSpawned = EvergladesSlopeMajorLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 5)
                {
                    slopeToBeSpawned = EvergladesSlopeMajorRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 6)
                {
                    slopeToBeSpawned = EvergladesSlopeDestructibleLeft;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 7)
                {
                    slopeToBeSpawned = EvergladesSlopeDestructibleRight;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 8)
                {
                    slopeToBeSpawned = EvergladesFishJackpotSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 9)
                {
                    slopeToBeSpawned = EvergladesPickupSpawningSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 10)
                {
                    slopeToBeSpawned = EvergladesTurtleCrossingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 11)
                {
                    slopeToBeSpawned = EvergladesBugFlyingSlope;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 12)
                {
                    slopeToBeSpawned = newEvergladesSlope1;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 13)
                {
                    slopeToBeSpawned = newEvergladesSlope2;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 14)
                {
                    slopeToBeSpawned = newEvergladesSlope3;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 15)
                {
                    slopeToBeSpawned = newEvergladesSlope4;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 16)
                {
                    slopeToBeSpawned = newEvergladesSlope5;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 17)
                {
                    slopeToBeSpawned = newEvergladesSlope6;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                else if (randNum == 18)
                {
                    slopeToBeSpawned = newEvergladesSlope7;
                    slopeSpawnDestination = slopeSpawnLocation;
                    doSpawning();
                }
                #endregion
            }

        }

    }

    void doSpawning()
    {
        mostRecentSlope = Instantiate(slopeToBeSpawned, slopeSpawnDestination, Quaternion.identity, slopeHolder.transform);
        //Debug.Log(slopeToBeSpawned);
    }

    void doMakeLeftBranch(Vector3 slopeSpawnLocation, PenguinDirectory.biomeList requestedBiome)
    {
        //BranchDistanceHolder = 0;
        for(float i = 1; i < 7; i++)//i needs to start equal to one
        {
            slopeSpawnDestination = new Vector3(
                slopeSpawnLocation.x + i * -3.535534f,
                slopeSpawnLocation.y,
                slopeSpawnLocation.z + i * 3.535534f);

            spawnNewSlope(slopeSpawnDestination, requestedBiome,true);
            //new slope must be spawned before euler angle changes to said slope
            mostRecentSlope.transform.eulerAngles = new Vector3(
                                                            mostRecentSlope.transform.eulerAngles.x,
                                                            mostRecentSlope.transform.eulerAngles.y - 45,
                                                            mostRecentSlope.transform.eulerAngles.z);
            
            Debug.Log("Bing");//not spawning because penguin.curbiome is a different biome. that is in place for good reason dont change it.
            numOfSlopesSinceTransition = 0;
        }
        Debug.Log("branch Spawned");
    }

    void doMakeRightBranch(Vector3 slopeSpawnLocation, PenguinDirectory.biomeList requestedBiome)
    {
        //BranchDistanceHolder = 0;
        for (float i = 1; i < 7; i++)//i needs to start equal to one
        {
            slopeSpawnDestination = new Vector3(
                slopeSpawnLocation.x + i * 3.535534f,
                slopeSpawnLocation.y,
                slopeSpawnLocation.z + i * 3.535534f);

            spawnNewSlope(slopeSpawnDestination, requestedBiome, true);
            //new slope must be spawned before euler angle changes to said slope
            mostRecentSlope.transform.eulerAngles = new Vector3(
                                                            mostRecentSlope.transform.eulerAngles.x,
                                                            mostRecentSlope.transform.eulerAngles.y + 45,
                                                            mostRecentSlope.transform.eulerAngles.z);

            Debug.Log("Bing");//not spawning because penguin.curbiome is a different biome. that is in place for good reason dont change it.
            numOfSlopesSinceTransition = 0;
        }
        Debug.Log("branch Spawned");
    }

}
