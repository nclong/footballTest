using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OffenseTeamManager : MonoBehaviour {

	public GameObject PlayerC;
	public GameObject PlayerTE;
	public GameObject PlayerG;
	public GameObject PlayerQB;
	public GameObject PlayerHB;
	public GameObject PlayerWX;
	public GameObject PlayerWZ;
	public GameObject PlayerWY;



	static public Dictionary<PlayerPosition, GameObject> GetPlayerDict(int teamNum)
	{
		return PlayerDictionary[teamNum];
	}

	static public Dictionary<PlayerPosition, GameObject> GetPlayerDict()
	{
		return currentTeam;
	}

	private static Dictionary<PlayerPosition, GameObject>[] PlayerDictionary;
	private static Dictionary<PlayerPosition, GameObject> currentTeam;
	// Use this for initialization
	void Start () {

		PlayerDictionary = new Dictionary<PlayerPosition, GameObject>[2]
		{
			new Dictionary<PlayerPosition, GameObject>(),
			new Dictionary<PlayerPosition, GameObject>()
		};

		PlayerDictionary[0][PlayerPosition.C] = PlayerC;
		PlayerDictionary[0][PlayerPosition.G] = PlayerG;
		PlayerDictionary[0][PlayerPosition.TE] = PlayerTE;
		PlayerDictionary[0][PlayerPosition.HB] = PlayerHB;
		PlayerDictionary[0][PlayerPosition.WRX] = PlayerWX;
		PlayerDictionary[0][PlayerPosition.WRY] = PlayerWY;
		PlayerDictionary[0][PlayerPosition.WRZ] = PlayerWZ;
		PlayerDictionary[0][PlayerPosition.QB] = PlayerQB;

		currentTeam = PlayerDictionary[0];
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

	void SetNewOffense(int teamNum)
	{
		currentTeam = PlayerDictionary[teamNum];
	}
}
