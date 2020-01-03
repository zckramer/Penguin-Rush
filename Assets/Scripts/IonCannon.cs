using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IonCannon : MonoBehaviour 
{

    public Transform Cannon;


    // Use this for initialization
    void Start()
    {
        Cannon.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
            Cannon.gameObject.SetActive(true);
        else if (Input.GetKeyDown(KeyCode.T))
            Cannon.gameObject.SetActive(false);
    }


}
