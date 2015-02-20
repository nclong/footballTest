using UnityEngine;
using System.Collections;

public class TouchTest : MonoBehaviour {

	private RaycastHit hit;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach( Touch touch in Input.touches )
		{
			Debug.Log ("Touch Num: " + touch.fingerId.ToString() );
			Debug.Log ("Touch State: " + touch.phase.ToString());
			Debug.Log ("Touch Pos: " + touch.position.ToString());
		}
	
	}
}
