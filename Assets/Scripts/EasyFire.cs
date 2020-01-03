using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EasyFire : MonoBehaviour {
    public bool EasyMode;

	// Use this for initialization
	void Start () {
        EasyMode = false;		
	}
	public void click()
    {
        EasyMode = true;
    }
	// Update is called once per frame
	void Update () {
		if(EasyMode == true)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
	}
}
