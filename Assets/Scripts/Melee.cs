using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Melee : MonoBehaviour 
{
    private GameObject Guard;

	// Ready-Timer for shield
	[SerializeField]
	bool canMelee = true;
	[SerializeField]
    private float timer = 0f;
	[SerializeField]
	private float timerCooldown;
	[SerializeField]
	private float timerCooldownLimit = 3.5f;

	// Colors for shield ready meter
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    public Color Yellow = Color.yellow;
    public Slider MeleeBarSlider;
    public Image Fill;

    void Awake()
	{
        MeleeBarSlider = MeleeBarSlider.GetComponent<Slider>();
    }

    // Use this for initialization
    void Start () 
	{
		canMelee = true;
		timerCooldown = timerCooldownLimit;
        Guard = GameObject.Find("Melee");
        timer = 0;
        Guard.SetActive(false);
        MeleeBarSlider.value = 3.5f;
        Fill.color = MaxHealthColor;
    }

    // Update is called once per frame
     void Update () 
	{
		UpdateCooldown ();

        timer += Time.deltaTime;
		if (Input.GetKeyDown("space") && (canMelee))
        {
			Debug.Log ("Spacebar pressed");
            Guard.SetActive(true);
            timer = 0f;
			canMelee = false;
        }

		if (timer >= .8f) 
		{
			Guard.SetActive (false);
		}
    }
		
	void UpdateCooldown ()
	{
		if (canMelee == false) 
		{
			timerCooldown -= Time.deltaTime;
            MeleeBarSlider.value = timerCooldown;
            Fill.color = MinHealthColor;
        }

		if (timerCooldown <= 0) 
		{
			canMelee = true;
			timerCooldown = timerCooldownLimit;
            MeleeBarSlider.value = timerCooldown;
            Fill.color = MaxHealthColor;
        }
	}

    public void UpdateHealthBar(int val)
    {
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, timerCooldown);
    }

	void OnTriggerEnter(Collider other)		// Shield destroys enemy bullets
	{
		if (other.tag == "Ebullet"|| other.tag == "Enemy"|| other.tag == "DestructibleObstacle") 
		{
			Destroy (other.gameObject);
			timerCooldown = timerCooldownLimit;
				// play a cool melee kill particle
		}

    }

}
