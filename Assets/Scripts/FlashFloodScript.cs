using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashFloodScript : MonoBehaviour 
{
    public Transform movement;
    public Transform wave;
    private Vector3 initialPos;
    private PlayerLog eventLog;
    

	// Use this for initialization
	void Start ()
    {
        initialPos = gameObject.transform.position;
        //initialRot = gameObject.transform.rotation;
        eventLog = GetComponent<PlayerLog>();

    }

/*	void OnTriggerEnter(Collider other)
        {
            if (other.tag == "FlashFlood")
            {
            StartCoroutine(waveLength());
            eventLog.NewActivity("Flash Flood Has Begun");
        }
        } 
    IEnumerator waveLength()
    {
        yield return new WaitForSeconds(0);
        wave.gameObject.SetActive(true);
        movement.transform.position = new Vector3(0, 5, 0);
        Debug.Log("Hit Leaf Raft pickup");
        yield return new WaitForSeconds(10);
        wave.gameObject.SetActive(false);
        movement.transform.position = new Vector3(0, 2.65f, -2.17f);
        eventLog.NewActivity("The Flash Flood is over");
        //transform.position = initialPos;
        //transform.rotation = initialRot;

    }
    */
    
}
