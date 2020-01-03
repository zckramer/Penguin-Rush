using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenguinMovementController : MonoBehaviour
{
    #region
    PenguinData PenguinInfoHolder;

    float minSpeedIncreaseTimer;
    public float minSpeedIncreaseOverTime;
    public bool increaseMinimumSpeed;

    [SerializeField]
    public float movementSpeed = 3f;

    public float dodgeSpeed = 100f;

    private float curRotation;

    [SerializeField]
    bool is360;
    [SerializeField]
    bool isSnapMovement;
    [SerializeField]
    bool doCentering;

    [SerializeField]
    private float movementHeldTimer;
    [SerializeField]
    float movementHeldTimerValue = 1;
    [SerializeField]
    private float constantTransitionTimer;
    [SerializeField]
    float constantTransitionTimerValue = 0.3f;

    public Transform canvas;

    public float speedMod = 1;


    //Equipment Variables
    //Rudder
    public float rudderDodgeSpeed = 150f;
    public bool hasRudder = false;

    public int numOfSlopesPassed;
    public float playTimeElapsed;

    GameObject Penguin;


    #endregion

    // Use this for initialization
    void Start()
    {
        PenguinInfoHolder = GetComponent<PenguinData>();
        //speedupParticleSystem = GameObject.Find ("SpeedUp Particle").GetComponent<ParticleSystem>();
        //emissionModule = speedupParticleSystem.GetComponent<ParticleSystem> ().emission;
    }


    // Update is called once per frame
    void Update()
    {
        playTimeElapsed += Time.deltaTime;

        godModeCheck();

        doMovement();
    }

    void doMovement()
    {
        //Movement keys
        //Debug.Log(gameObject.transform.eulerAngles.z);



        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("AxisX") >= .1f || Input.GetAxis("AxisX") <= -.1f)//a catch that isnt filled down below. WHile a key is pressed it increments movementheldtimer
        {
            movementHeldTimer += Time.deltaTime;
            constantTransitionTimer += Time.deltaTime;
        }

        #region SnapMovement
        if (isSnapMovement)
        {
            if (movementHeldTimer >= 0 && movementHeldTimer < movementHeldTimerValue)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetAxis("AxisX") >= .1f)
                {
                    if (!is360 && (gameObject.transform.eulerAngles.z > 334 || gameObject.transform.eulerAngles.z < 26))
                    {
                        curRotation -= (Time.deltaTime * dodgeSpeed);
                        if (curRotation < -26 || curRotation > 26)
                        {
                            curRotation = -24.9f;
                        }
                        //Debug.Log("curRotation = " + curRotation);
                        updateRotation(curRotation);
                    }
                    else if (is360)
                    {
                        curRotation -= 36;
                        //curRotation -= (Time.deltaTime * dodgeSpeed);
                        if (curRotation < 0)
                        {
                            curRotation += 360;
                        }
                        updateRotation(curRotation);
                    }
                }

                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetAxis("AxisX") <= -.1f)
                {
                    if (!is360 && (gameObject.transform.eulerAngles.z > 334 || gameObject.transform.eulerAngles.z < 26))
                    {
                        curRotation += (Time.deltaTime * dodgeSpeed);
                        if (curRotation < -26 || curRotation > 26)
                        {
                            curRotation = 24.9f;
                        }
                        updateRotation(curRotation);
                    }
                    else if (is360)
                    {
                        curRotation += 36;
                        //curRotation += (Time.deltaTime * dodgeSpeed);
                        if (curRotation > 360)
                        {
                            curRotation -= 360;
                        }
                        updateRotation(curRotation);
                    }
                }

            }
            else if (movementHeldTimer >= movementHeldTimerValue)
            {
                if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) || Input.GetAxis("AxisX") >= .1f && constantTransitionTimer > constantTransitionTimerValue)
                {
                    if (!is360 && (gameObject.transform.eulerAngles.z > 334 || gameObject.transform.eulerAngles.z < 26))
                    {
                        curRotation -= (Time.deltaTime * dodgeSpeed);
                        if (curRotation < -26 || curRotation > 26)
                        {
                            curRotation = -24.9f;
                        }
                        //Debug.Log("curRotation = " + curRotation);
                        updateRotation(curRotation);
                    }
                    else if (is360)
                    {
                        curRotation -= 36;
                        //curRotation -= (Time.deltaTime * dodgeSpeed);
                        if (curRotation < 0)
                        {
                            curRotation += 360;
                        }
                        updateRotation(curRotation);
                    }
                    constantTransitionTimer = 0;
                }

                if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("AxisX") <= -.1f) && constantTransitionTimer > constantTransitionTimerValue)
                {
                    if (!is360 && (gameObject.transform.eulerAngles.z > 334 || gameObject.transform.eulerAngles.z < 26))
                    {
                        curRotation += (Time.deltaTime * dodgeSpeed);
                        if (curRotation < -26 || curRotation > 26)
                        {
                            curRotation = 24.9f;
                        }
                        updateRotation(curRotation);
                    }
                    else if (is360)
                    {
                        curRotation += 36;
                        //curRotation += (Time.deltaTime * dodgeSpeed);
                        if (curRotation > 360)
                        {
                            curRotation -= 360;
                        }
                        updateRotation(curRotation);
                    }
                    constantTransitionTimer = 0;
                }
            }
        }
        #endregion

        #region notSnapMovement
        if (!isSnapMovement)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow) || Input.GetAxis("AxisX") >= .1f)
            {
                if (is360)//needs to be not an 'else if' only an if by itself - John
                {
                    curRotation -= (Time.deltaTime * dodgeSpeed);
                    if (curRotation < 0)
                    {
                        curRotation += 360;
                    }
                    updateRotation(curRotation);
                }
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow) || Input.GetAxis("AxisX") <= -.1f)
            {
                if (is360)//needs to be not an 'else if' only an if by itself - John
                {
                    curRotation += (Time.deltaTime * dodgeSpeed);
                    if (curRotation > 360)
                    {
                        curRotation -= 360;
                    }
                    updateRotation(curRotation);
                }
            }
        }
        #endregion

        if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.LeftArrow) && !Input.GetKey(KeyCode.RightArrow) )
        {
            movementHeldTimer = 0;
            constantTransitionTimer = 0;
            if (!isSnapMovement && doCentering)
            {
                centerPlayer();
            }
        }
/*
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetAxis("AxisY") >= .1f)										// speed increase
        {
//			emissionRate += Time.deltaTime;						// If the W key is being pressed, increase
			speedMod = 5f;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow) || Input.GetAxis("AxisY") <= -.1f)										// speed Decrease
        {
            speedMod = .5f;
        }
*/																// end accel and brake system


        PenguinData penguinData = GameObject.Find("Penguin").GetComponent<PenguinData>();
//		DifficultySpawner difficultySpawner = GameObject.Find("SpawnerEasy").GetComponent<DifficultySpawner>();
        PenguinDirectory penguinDirectory = GameObject.Find("Penguin").GetComponent<PenguinDirectory>();
//		movementSpeed = speedMod + (penguinData.difficultyIndex * (penguinData.score + penguinDirectory.SpawnTimeMin)) / penguinData.score;
    }

    void centerPlayer()			//temp function name?
    {
        float degreesFromCentered = 0;
        if (((curRotation / 36) - Mathf.Floor(curRotation / 36)) != 0)
        {
            degreesFromCentered = (((curRotation / 36) - Mathf.Floor(curRotation / 36)) - 0.5f);
        }
        if (degreesFromCentered != 0.5 || degreesFromCentered != -0.5)
        {
            if (degreesFromCentered < 0.5 && degreesFromCentered > 0.45)
            {
                updateRotation((Mathf.Round(curRotation / 36)) * 36);
            }
            else if (degreesFromCentered > 0)
            {
                updateRotation(curRotation + (degreesFromCentered * 2));
            }

            if (degreesFromCentered > -0.5 && degreesFromCentered < -0.45)
            {
                updateRotation((Mathf.Round(curRotation / 36)) * 36);
            }
            else if (degreesFromCentered < 0)
            {
                updateRotation(curRotation + (degreesFromCentered * 2));
            }
            //Debug.Log(degreesFromCentered);
            //Debug.Log(curRotation);
        }
    }

    void updateRotation(float mod)
    {
        gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                gameObject.transform.eulerAngles.z * 0);

        gameObject.transform.eulerAngles = new Vector3(
                gameObject.transform.eulerAngles.x,
                gameObject.transform.eulerAngles.y,
                gameObject.transform.eulerAngles.z + mod);

        curRotation = mod;

    }

    void godModeCheck()
    {
        if(Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.UpArrow))
        {
            Penguin = GameObject.Find("Penguin");
            Penguin.GetComponent<PenguinDirectory>().activeShields = 500;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.DownArrow))
        {
            Penguin = GameObject.Find("Penguin");
            Penguin.GetComponent<PenguinDirectory>().activeShields = 0;
        }
    }
}
