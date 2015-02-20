using UnityEngine;
using System.Collections;

public class BallFlight : MonoBehaviour {

    public bool inAir = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        rigidbody.velocity += Constants.BallAirDrag;
	}
}
