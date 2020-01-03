using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lazer : MonoBehaviour {

    // Use this for initialization
    void Start() {
        Destroy(gameObject, 4f);
    }

    // Update is called once per frame
    void Update() {
        Vector3 forward = new Vector3(0, 0, 8);
        gameObject.GetComponent<Rigidbody>().velocity = forward;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "DestructibleObstacle" || other.tag == "Enemy")
        {
            Destroy(other.gameObject);
        }
    }
}
