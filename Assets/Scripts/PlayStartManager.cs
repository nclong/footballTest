using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayStartManager : MonoBehaviour {
	
	private Dictionary<PlayerPosition, GameObject> players;

	public int teamNumber = 0;
	private bool firstTouch = false;
	private bool secondTouch = false;
	private bool manInMotionStarted = false;
	// Use this for initialization
	void Start () {
		players = OffenseTeamManager.GetPlayerDict(teamNumber);
		Debug.Log("PlayStartManager Loaded");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Debug.Log("Playstart Active");
		foreach(Touch touch in Input.touches)
		{
			if( touch.phase == TouchPhase.Began )
			{
				if(!firstTouch)
				{
					firstTouch = true;
					Debug.Log("First Touch");
				}
				else
				{
					secondTouch = true;
					Debug.Log("Second Touch");
				}
			}
			
			
		}
		
		if(firstTouch && !manInMotionStarted)
		{
			StartManInMotion ();
		}
		
		if(secondTouch)
		{
			foreach(GameObject player in players.Values)
			{
				player.GetComponent<PlayerInPlayManager>().StartPlay();
			}
			GameStateManager.ChangeState(ControlMode.QBPassing);
		}

		
	}
	
	private void StartManInMotion()
	{
		players[PlayerPosition.WRY].GetComponent<PlayerInPlayManager>().StartPlay();
		manInMotionStarted = true;
	}
}
