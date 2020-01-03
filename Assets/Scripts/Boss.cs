using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour {

    private Transform player;

    [SerializeField]
    public float timer = 0f;

    public GameObject[] Bullet;
    public GameObject Superfish;
    public int BHealth = 3;

    // Use this for initialization
    void Start()
    {
        BHealth = 3;
        player = GameObject.Find("Penguin").GetComponent<Transform>();
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.LookAt(player);
        timer += Time.deltaTime;
        CheckForDestroy();
        if (timer >= 6.0f)
        {
            Shoot();
        }
    }


    public void updateBHealth(int _Bhealth)
    {
        BHealth -= _Bhealth;

    }

    void CheckForDestroy()
    {
        if (BHealth <= 0)
        {
            BHealth = 3;
            Spawn();
            gameObject.SetActive(false);
        }
    }


    void Spawn()
    {
        Instantiate(Superfish, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    void Shoot()
    {

            int randindex = Random.Range(0, Bullet.Length);
            Instantiate(Bullet[randindex], transform.position, transform.rotation);
            timer = 0;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Death")
        {
            BHealth--;
            Destroy(other.gameObject);
        }
    }
 }
