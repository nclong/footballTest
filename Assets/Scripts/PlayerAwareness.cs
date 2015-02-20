using UnityEngine;
using System.Collections;

public class PlayerAwareness : MonoBehaviour {

	public Vector3 FacingDirection { get; private set; }
	public Vector3 GoalDirection {
		get
		{
			return new Vector3 (0f, 0f, 1f);
		}
	}
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
