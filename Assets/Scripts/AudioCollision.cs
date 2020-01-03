using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioCollision : MonoBehaviour {

  
                                   

    #region audioClips

    [SerializeField]
    AudioClip Minor;
    [SerializeField]
    AudioClip Major;
    [SerializeField]
    AudioClip Fish;
    [SerializeField]
    AudioClip Dirt;
    [SerializeField]
    AudioClip HotRock;
    [SerializeField]
    AudioClip IceCube;
    [SerializeField]
    AudioClip SlickMud;
    [SerializeField]
    AudioClip EQ;
    [SerializeField]
    AudioClip Fronut;
    [SerializeField]
    AudioClip LeafRaft;
    [SerializeField]
    AudioClip SuperFish;
    [SerializeField]
    AudioClip EnemyBullet;



    #endregion


    void Start()
    {
       
    }


    void OnCollisionEnter(Collision other)  //Plays Sound Whenever collision detected
    {
        if(other.collider.tag != "Untagged")
        {
            GetComponent<AudioSource>().Play();
        }
       
    }

    public void doMakeSound(string other)
    {
        if(other == "MinorObstacle" || other == "Target")
        {
            GetComponent<AudioSource>().clip = Minor;
        }
        else if (other == "MajorObstacle")
        {
            GetComponent<AudioSource>().clip = Major;
        }
       
        else if (other == "Pickup Fish")
        {
            GetComponent<AudioSource>().clip = Fish;
        }
        else if (other == "Dirt")
        {
            GetComponent<AudioSource>().clip = Dirt;
        }
        else if (other == "HotRock")
        {
            GetComponent<AudioSource>().clip = HotRock;
        }
        else if (other == "IceCube")
        {
            GetComponent<AudioSource>().clip = IceCube;
        }
        else if (other == "SlickMud")
        {
            GetComponent<AudioSource>().clip = SlickMud;
        }

        else if (other == "Earthquake")
        {
            GetComponent<AudioSource>().clip = EQ;
        }
        
        else if (other == "Fronut")
        {
            GetComponent<AudioSource>().clip = Fronut;
        }
        else if (other == "LeafRaft")
        {
            GetComponent<AudioSource>().clip = LeafRaft;
        }
        else if (other == "Superfish")
        {
            GetComponent<AudioSource>().clip = SuperFish;
            Debug.Log("super");
        }
        else if (other == "Ebullet")
        {
            GetComponent<AudioSource>().clip = EnemyBullet;
            Debug.Log("bullet");
        }
        //  Debug.Log(other + " Audio Applied");
        GetComponent<AudioSource>().Play();
    }

}
