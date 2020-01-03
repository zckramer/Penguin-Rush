using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootScript : MonoBehaviour 
{
    private Transform player;

    [SerializeField]
    public float timer = 0f;

    public GameObject Bullet;

	// Use this for initialization
	void Start () 
	{
        player = GameObject.Find("Penguin").GetComponent<Transform>();
		timer = Random.Range(0, 5f);
    }
	
	// Update is called once per frame
	void Update () 
	{

        transform.LookAt(player);
        timer += Time.deltaTime;

        if (timer >= 5.0f )
        {
            Shoot();
        }
       
    }
    void Shoot()
    {
        if(player.transform.position.z < this.transform.position.z)
        {
            Instantiate(Bullet, transform.position, transform.rotation);
            timer = 0;
        }
    }
}
