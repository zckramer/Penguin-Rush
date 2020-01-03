using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour {

    #region Variables

    #region Spawners
    [SerializeField]
    GameObject spawner0;
    [SerializeField]
    GameObject spawner1;
    [SerializeField]
    GameObject spawner2;
    [SerializeField]
    GameObject spawner3;
    [SerializeField]
    GameObject spawner4;
    [SerializeField]
    GameObject spawner5;
    [SerializeField]
    GameObject spawner6;
    [SerializeField]
    GameObject spawner7;
    [SerializeField]
    GameObject spawner8;
    [SerializeField]
    GameObject spawner9;
    #endregion

    #endregion

    // Use this for initialization
    void Start ()
    {

        #region FillingVariables
        spawner0 = GameObject.Find("Spawner0");
        spawner1 = GameObject.Find("Spawner1");
        spawner2 = GameObject.Find("Spawner2");
        spawner3 = GameObject.Find("Spawner3");
        spawner4 = GameObject.Find("Spawner4");
        spawner5 = GameObject.Find("Spawner5");
        spawner6 = GameObject.Find("Spawner6");
        spawner7 = GameObject.Find("Spawner7");
        spawner8 = GameObject.Find("Spawner8");
        spawner9 = GameObject.Find("Spawner9");
        #endregion
        
    }

    // Update is called once per frame
    void Update ()
    {
		
	}



}
