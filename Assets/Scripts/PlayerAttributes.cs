using UnityEngine;
using System.Collections;

public class PlayerAttributes : MonoBehaviour {
	public string PlayerName;
	public string PlayerNum;
	public PlayerPosition Position;
	public int Weight;
	[Range(0,100)]
	public int Strength;
	[Range(0,100)]
	public int Acceleration;
	[Range(0,100)]
	public int Speed;
	[Range(0,100)]
	public int Awareness;
	[Range(0,100)]
	public int Agility;
	[Range(0,100)]
	public int ThrowingPower;
	[Range(0,100)]
	public int ThrowingSpeed;
	[Range(0,100)]
	public int ThrowingAccuracy;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
