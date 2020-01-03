using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PenguinEquipScript : MonoBehaviour {


    //Switch board

    public bool HasDrillHat;
    public bool HasD20;
    public bool HasAi;
    public bool HasAccHat;
    public bool HasSucker;
    public bool HasRudder;
    public bool HasJetpack;



    void start()
    {
       
            DontDestroyOnLoad(gameObject);
        
    }

    public void drillHat()
    {
        HasDrillHat = true;
        HasD20 = false;
        HasAi = false;
        HasAccHat = false;
        HasSucker = false;
        HasRudder = false;
        HasJetpack = false;
    }
    public void D20()
    {
        HasDrillHat = false;
        HasD20 = true;
        HasAi = false;
        HasAccHat = false;
        HasSucker = false;
        HasRudder = false;
        HasJetpack = false;
    }
    public void Ai()
    {
        HasDrillHat = false;
        HasD20 = false;
        HasAi = true;
        HasAccHat = false;
        HasSucker = false;
        HasRudder = false;
        HasJetpack = false;
    }
    public void accHat()
    {
        HasDrillHat = false;
        HasD20 = false;
        HasAi = false;
        HasAccHat = true;
        HasSucker = false;
        HasRudder = false;
        HasJetpack = false;
    }
    public void sucker()
    {
        HasDrillHat = false;
        HasD20 = false;
        HasAi = false;
        HasAccHat = false;
        HasSucker = true;
        HasRudder = false;
        HasJetpack = false;
    }
    public void rudder()
    {
        HasDrillHat = false;
        HasD20 = false;
        HasAi = false;
        HasAccHat = false;
        HasSucker = false;
        HasRudder = true;
        HasJetpack = false;
    }
    public void jetPack()
    {
        HasDrillHat = false;
        HasD20 = false;
        HasAi = false;
        HasAccHat = false;
        HasSucker = false;
        HasRudder = false;
        HasJetpack = true;
    }

}
