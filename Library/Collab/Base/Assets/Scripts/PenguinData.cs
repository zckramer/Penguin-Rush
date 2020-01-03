using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PenguinData : MonoBehaviour 
{
    #region Variables
	// References
	ShootScript shootScript;
	public DifficultySpawner difficultySpawner;
	PenguinMovementController penguinMovementController;

    public string activePowerUp = null;

    //Ammo type Bools
	public bool isInferno = false;
	public bool isSlimey = false;
	public bool isFrozen = false;
	public bool isCrusty = false;

	//Difficulty Variables
	[SerializeField]
	public int difficultyIndex = 0;				// 0 = easy, 1 = normal, 2 = hard

    //Timers and score
    public int HP;
    public int HPMax = 5;
    public int score;
	public int scoreIncrement = 1;
    public float pickupTimer;
	public float pickupTimerMax = 10f;
	public float scoreTimer;
	public float scoreTimerMax = 0.25f;

    //Ammo Icons
    public Sprite FrozenAmmoType;
    public Sprite InfernoAmmoType;
    public Sprite SlimyAmmoType;
    public Sprite CrustyAmmoType;
    public Sprite RegularAmmoType;
    public GameObject AmmoType;

    //Text
    public Text HpText;
    public Text scoreCountText;
    public Text ammoTypeText;
	public Text difficultyText;
    public Canvas canvas;

    //Gameover canvas
    public Transform gameOver;
   
    #endregion

    void Start()
    {
		penguinMovementController = gameObject.GetComponent<PenguinMovementController> ();
		shootScript = gameObject.GetComponent<ShootScript> ();
		score = 0;
		scoreTimer = scoreTimerMax;
		pickupTimer = pickupTimerMax;
		isInferno = false;
		isSlimey = false;
		isFrozen = false;
		isCrusty = false;
        ammoTypeText.GetComponent<Text>().text = ("Regular Ammo");
		difficultyIndex = 1;
    }

    void Update()
    {
		CheckForDeath ();
		UpdatePickups ();
		UpdateScore ();
        UpdateHp();
		UpdateScoreTimer ();
		IncrementTimerScore (scoreIncrement);
		HandleDifficultySetting ();
    }

	public void HandleDifficultySetting()		// Keypresses to raise / lower the difficulty setting
	{											// MIN DIFFICULTY 0, MAX DIFFICULTY 2
		if (Input.GetKeyDown (KeyCode.Minus)) // Decrease difficulty
		{
			score - 500;

			if (score < 0) 
			{
				score = 0;
			}
		}

		if (Input.GetKeyDown (KeyCode.Equals)) // Increase difficulty
		{
			score + 500;
		}

		//update the difficulty displayed on UI

			difficultyText.text = "Difficulty Index = " + difficultyIndex;

	}

	public void ModifyHP(int _ModifyHP)		// This INCREMENTS HP, as opposed to the HpUpdate on enemies that DECREMENTS.. careful
	{
        if (HP == 5)
        {

        }
        HP += _ModifyHP;
		Mathf.Clamp(HP, 0, 5);
	}

	void CheckForDeath()
	{
		if (HP <= 0) 
		{
			if (gameOver.gameObject.activeInHierarchy == false) 
			{
				gameOver.gameObject.SetActive (true);
				Time.timeScale = 0;
			}
		}
	}

	void UpdateScore()
	{
        scoreCountText.text = score.ToString ();
	}

    void UpdateHp()
    {
        HpText.text = HP.ToString();
    }

    void UpdateScoreTimer()
	{
		scoreTimer -= 1 * Time.deltaTime;
	}

	void UpdatePickupTimer()
	{		
		pickupTimer -= 1 * Time.deltaTime;
	}

	void IncrementTimerScore(int _increment)				// Use this method for time -> points
	{
		_increment = scoreIncrement;
		if (scoreTimer <= 0)
		{
			score += _increment;
			scoreTimer = scoreTimerMax;
		}
	}

	void IncrementScoreIncrement()
	{
		scoreIncrement += scoreIncrement;
	}

	public void ModifyScore(int _modifyScore)			// Use this method for kills -> points
	{
		score += _modifyScore;
	}
		
	void UpdatePickups()
	{
		if (pickupTimer <= 0)							// The pickups are temporary. Their timer is pickupTimer/pickupTimerMax
		{
			shootScript.projectileTypeIndex = 0;		// Switch back to normal ammo
			isInferno = false;
			isSlimey = false;
			isFrozen = false;
			isCrusty = false;
			pickupTimer = pickupTimerMax;
            AmmoType.GetComponent<Image>().sprite = RegularAmmoType;
            ammoTypeText.gameObject.SetActive(true);
            ammoTypeText.GetComponent<Text>().text = ("Regular Ammo");
		}

		if (isCrusty == true)
		{
			UpdatePickupTimer ();
			shootScript.projectileTypeIndex = 1;
            AmmoType.GetComponent<Image>().sprite = CrustyAmmoType;
            ammoTypeText.gameObject.SetActive(false);
        }

		if (isSlimey == true)
		{
			UpdatePickupTimer ();
			shootScript.projectileTypeIndex = 2;
            AmmoType.GetComponent<Image>().sprite = SlimyAmmoType;
            ammoTypeText.gameObject.SetActive(false);
        }

		if (isInferno == true)  
		{
			UpdatePickupTimer ();
			shootScript.projectileTypeIndex = 3;
            AmmoType.GetComponent<Image>().sprite = InfernoAmmoType;
            ammoTypeText.gameObject.SetActive(false);
        }

		if (isFrozen == true)
		{
			UpdatePickupTimer ();
			shootScript.projectileTypeIndex = 4;
            AmmoType.GetComponent<Image>().sprite = FrozenAmmoType;
            ammoTypeText.gameObject.SetActive(false);
        }
	}

	void UpdateDifficulty()
	{
		if (score >= 500) 
		{
			
		}
	}

}
