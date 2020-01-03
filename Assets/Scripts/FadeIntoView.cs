using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIntoView : MonoBehaviour {

    GameObject Penguin;

    int redColorInt;
    int greenColorInt;
    int blueColorInt;
    int alphaColorInt;

	// Use this for initialization
	void Start ()
    {

        Penguin = GameObject.Find("Penguin");
        	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Renderer Skin = gameObject.GetComponent<Renderer>();

        float colorHolder = Skin.material.color.r * 255f;
        redColorInt = (int) colorHolder;
        colorHolder = Skin.material.color.g * 255f;
        greenColorInt = (int)colorHolder;
        colorHolder = Skin.material.color.b * 255f;
        blueColorInt = (int)colorHolder;
        colorHolder = (Skin.material.color.a * 255f) + 1f;
        alphaColorInt = (int)colorHolder;

        byte redColorByte = (byte)redColorInt;
        byte greenColorByte = (byte)greenColorInt;
        byte blueColorByte = (byte)blueColorInt;
        byte alphaColorByte = (byte)alphaColorInt;

        Skin.material.color = new Color32(
                                    redColorByte,
                                    greenColorByte,
                                    blueColorByte,
                                    alphaColorByte);
        //Debug.Log("Skin a " + Skin.material.color.a);
        //Debug.Log("colorHolder " + colorHolder);
        //Debug.Log("redColorInt " + redColorInt);
        //Debug.Log("redColorByte " + redColorByte);
        //Debug.Log("alphaColorByte " + alphaColorByte);
	}
}
