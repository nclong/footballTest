using UnityEngine;
using System.Collections;

public class BallFlight : MonoBehaviour {

    public bool inAir = false;
    public int releaseFrames;

    private int frameCount = 0;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if( inAir)
        {
            frameCount++;
            if( frameCount >= releaseFrames)
            {
                collider.isTrigger = true;
            }
            //rigidbody.velocity += Constants.BallAirDrag;
        }
        else {
            transform.localPosition = Constants.BallOffset;
        }
	}
}
