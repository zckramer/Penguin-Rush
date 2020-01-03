using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shot : MonoBehaviour 
{

    private Transform penguin;
    private Transform boss;
	[SerializeField]
    private float MoveSpeed;
    private float lifetime = 4f;


    // Use this for initialization
    void Start () 
	{
        MoveSpeed = 10f;
        penguin = GameObject.Find("Penguin").GetComponent<Transform>();     
        lifetime = 4f;
        Destroy(gameObject, lifetime);
		gameObject.GetComponent<Rigidbody> ().velocity = (penguin.transform.position - transform.position).normalized * MoveSpeed;
        //boss = GameObject.Find("Boss").GetComponent<Transform>();

    }
	
	// Update is called once per frame
	void Update () 
	{
        if (boss == null)
        {

        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Melee Area" && gameObject.tag == "B_Target" || gameObject.tag == "Death")
        {
            gameObject.GetComponent<Rigidbody>().velocity = (boss.transform.position - transform.position).normalized * MoveSpeed;
            gameObject.tag = "Death";
        }
        if (other.tag == "Melee Area" && gameObject.tag != "B_Target" && gameObject.tag != "Death")
        {
            Destroy(gameObject);
        }
        if (other.tag == "Inferno Fish")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }

	void OnBecameInvis()
	{
		Destroy (gameObject);
	}

}
