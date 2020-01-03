using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnStateMachine : MonoBehaviour 
{
	private enum SpawnState
	{
		QUADRANT_TOPLEFT,
		QUADRANT_TOPRIGHT,
		QUADRANT_BOTTOMLEFT,
		QUADRANT_BOTTOMRIGHT,
		PUSH_TO_TOP,
		PUSH_TO_RIGHT,
		PUSH_TO_BOTTOM,
		PUSH_TO_LEFT,
		WALL,
		RANDOM,
		PATTERN_STATE,

		EMPTY
	}

	SpawnState curState;
	Dictionary <SpawnState, Action> ssm = new Dictionary <SpawnState, Action>();
	public GameObject[] spawnPoint;		// This array is where each spawner is placed, starting at 12 o'clock and moving clockwise, is 10, 1, 2, 3...

	// Timer Functions
	[SerializeField]
	private float timer = 0f;
	private float timerLimit = 4.0f;	// each state will draw a pattern for 4 seconds
	private float burstTimerLimit; 		// this will be the timer limit divided by the number of instances of obstacles. So, 7 obstacles would be 4/7

	// Use this for initialization
	void Start () 
	{
		ssm.Add (SpawnState.QUADRANT_TOPLEFT, StateQuadTopLeft);
		ssm.Add (SpawnState.QUADRANT_TOPRIGHT, StateQuadTopRight);
		ssm.Add (SpawnState.QUADRANT_BOTTOMLEFT, StateQuadBottomLeft);
		ssm.Add (SpawnState.QUADRANT_BOTTOMRIGHT, StateQuadBottomRight);
		ssm.Add (SpawnState.PUSH_TO_TOP, StatePushToTop);
		ssm.Add (SpawnState.PUSH_TO_RIGHT, StatePushToRight);
		ssm.Add (SpawnState.PUSH_TO_BOTTOM, StatePushToBottom);
		ssm.Add (SpawnState.PUSH_TO_LEFT, StatePushToLeft);
		ssm.Add (SpawnState.WALL, StateWall);
		ssm.Add (SpawnState.EMPTY, StateEmpty);
		ssm.Add (SpawnState.RANDOM, StateRandom);

		curState = SpawnState.RANDOM;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ssm [curState].Invoke();
	}

	void SetState (SpawnState _newState)
	{
		curState = _newState;
	}
						// State Patterns
	void StateRandom ()
	{
		
	}

	void StateEmpty ()
	{
		
	}

	void StateWall ()
	{

	}

	void StatePushToLeft()				// Two angled walls that force the player through a bottleneck, starts at 3 and 4
	{

	}

	void StatePushToBottom()			// Two angled walls that force the player through a bottleneck, starts at 10 and 1
	{

	}

	void StatePushToRight()				// Two angled walls that force the player through a bottleneck, starts at 7 and 8
	{

	}

	void StatePushToTop()				// Two angled walls that force the player through a bottleneck, starts at 5 and 6
	{

	}

	void StateQuadTopLeft()				// Build a wall of obstacles that covers a quadrant of the tunnel
	{

	}

	void StateQuadTopRight()			// Build a wall of obstacles that covers a quadrant of the tunnel
	{

	}

	void StateQuadBottomLeft()			// Build a wall of obstacles that covers a quadrant of the tunnel
	{

	}

	void StateQuadBottomRight()			// Build a wall of obstacles that covers a quadrant of the tunnel
	{

	}

						// End State Patterns
	// Timer Functions
	void PatternTimerHandler()
	{
		timer += Time.deltaTime;

		// Pattern Randomizer
		if (timer >= timerLimit) 		// Each state runs for 4 seconds, then changes pattern
		{
			ResetState ();	
			SetNextPatternState ();
		}

	}

	void ResetState()
	{
		timer = 0.0f;					// Perhaps here we should go to a default state for a frame?
	}

	void SetNextPatternState()			// Randomly choose the next pattern state
	{
		int patternIndex;
		patternIndex = UnityEngine.Random.Range (1, 11);		// you have to continue to increase the max range as you add patterns
		if (patternIndex == 1) 
		{
			SetState (SpawnState.RANDOM);
		}
		if (patternIndex == 2) 
		{
			SetState (SpawnState.EMPTY);
		}
		if (patternIndex == 3) 
		{
			SetState (SpawnState.WALL);
		}
		if (patternIndex == 4) 
		{
			SetState (SpawnState.PUSH_TO_LEFT);
		}
		if (patternIndex == 5) 
		{
			SetState (SpawnState.PUSH_TO_TOP);
		}
		if (patternIndex == 6) 
		{
			SetState (SpawnState.PUSH_TO_RIGHT);
		}
		if (patternIndex == 7) 
		{
			SetState (SpawnState.PUSH_TO_BOTTOM);
		}
		if (patternIndex == 8) 
		{
			SetState (SpawnState.QUADRANT_TOPLEFT);
		}
		if (patternIndex == 9) 
		{
			SetState (SpawnState.QUADRANT_TOPRIGHT);
		}
		if (patternIndex == 10) 
		{
			SetState (SpawnState.QUADRANT_BOTTOMRIGHT);
		}
		if (patternIndex == 11)
		{
			SetState (SpawnState.QUADRANT_BOTTOMLEFT);
		}
	}
}
