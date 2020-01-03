using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootMeterScript : MonoBehaviour 
{
	public ShootScript shootScript;
	public Slider shootSlider;

	// Use this for initialization
	void Start () 
	{
		shootSlider = gameObject.GetComponent<Slider> ();
	}

	// Update is called once per frame
	void Update () 
	{
		UpdateShootometer ();
	}

	void UpdateShootometer()
	{
		shootSlider.maxValue = (shootScript.FireTimerLimit());
		shootSlider.minValue = (0);
		shootSlider.value = (shootScript.fireTimer);
	}
}
