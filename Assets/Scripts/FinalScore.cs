using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScore : MonoBehaviour {
    public GameObject PenguinScore;
    
    public Text FishCount;


   
    // Use this for initialization
    void Start()
    {
      
    }


       // Update is called once per frame
        void Update ()
    {
        FishCount.text = PenguinScore.GetComponent<PenguinData>().score.ToString();
    }

    }
