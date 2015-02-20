using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameStateManager : MonoBehaviour {

	private static ControlMode CurrentMode;
	private static PlayerAttributes CurrentControlPlayer;
	private static Dictionary<ControlMode, GameObject> ManagerDictionary;
	// Use this for initialization
	void Start () {
		CurrentMode = ControlMode.StartingPlay;
		ManagerDictionary = new Dictionary<ControlMode, GameObject>();
		ManagerDictionary[ControlMode.Defense] = GameObject.Find("DefenseManager");
		ManagerDictionary[ControlMode.PickingPlayDefense] = GameObject.Find("DefensePlaySelector");
		ManagerDictionary[ControlMode.PickingPlayOffense] = GameObject.Find ("OffensePlaySelector");
		ManagerDictionary[ControlMode.QBPassing] = GameObject.Find("PassPlayManager");
		ManagerDictionary[ControlMode.QBRunning] = GameObject.Find("RunningPlayManager");
		ManagerDictionary[ControlMode.Running] = GameObject.Find ("RunningManager");
		ManagerDictionary[ControlMode.StartingPlay] = GameObject.Find ("PlayStartManager");
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		foreach( GameObject obj in ManagerDictionary.Values )
		{
			if( obj != null )
			{
				if( obj == ManagerDictionary[CurrentMode] )
				{
					obj.SetActive(true);
				}
				else {
					obj.SetActive(false);
				}
			}
			//Debug.Log(obj);
		}

		//ManagerDictionary[CurrentMode].SetActive(true);
		//Debug.Log(ManagerDictionary[CurrentMode]);
		//Debug.Log(CurrentMode);
	
	}

	public static void ChangeState(ControlMode newMode)
	{
		CurrentMode = newMode;
	}
}
