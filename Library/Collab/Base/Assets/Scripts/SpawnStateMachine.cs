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

		EMPTY
	}

	SpawnState curState;
	Dictionary <SpawnState, Action> ssm = new Dictionary <SpawnState, Action>();
	public GameObject[] spawnPoint;

	// Timer Functions
	[SerializeField]
	private float timer = 0f;
	private float timerLimit = 4.0f;

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

		curState = SpawnState.EMPTY;
	}
	
	// Update is called once per frame
	void Update () 
	{
		ssm [curState].Invoke;
	}

						// State Patterns
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
		
		}

	}

	void ResetState()
	{
		timer = 0.0f;					// Perhaps here we should go to a default state for a frame?
	}

	void SetNextPatternState()			// Randomly choose the next pattern state
	{
		
	}
}
