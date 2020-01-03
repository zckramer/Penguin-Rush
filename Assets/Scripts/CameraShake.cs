using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

    
    [SerializeField]
    float shakeTimer;
    [SerializeField]
    float shakeAmount;

    public float shakeTimerValue;
    public float shakeAmountValue;


    //public Transform movement;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if (shakeTimer >= 0)
        {
            Vector2 ShakePos = Random.insideUnitCircle * shakeAmount;
            transform.position = new Vector3(transform.position.x + ShakePos.x, transform.position.y + ShakePos.y, transform.position.z);
            shakeTimer -= Time.deltaTime;
            
        }
        else
        {
            transform.position = new Vector3(-0.03048059f, 3.06f, -3.156f);
        }
	}

    public void ShakeCamera()
    {
        shakeAmount = shakeAmountValue;
        shakeTimer = shakeTimerValue;
    }
}
