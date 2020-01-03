using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{

    public AudioClip pop;
    private AudioSource source;

    void Start()
    {
        source = GetComponent<AudioSource>();
        
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "MinorObstacle" || other.tag == "MajorObstacle" || other.tag == "Enemy" || other.tag == "DestructibleObstacle")
        {
            AudioSource.PlayClipAtPoint(pop, new Vector3(1, 2, -8));
            Debug.Log("POP!!!");
            Destroy(gameObject);
        }
    }
}
