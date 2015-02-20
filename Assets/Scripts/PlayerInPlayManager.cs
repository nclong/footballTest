using UnityEngine;
using System;
using System.Collections;
public class PlayerInPlayManager : MonoBehaviour {


	public float positionReachedThreshold;
	public float closeToTouchThreshold;
	public GameObject Football;

	private PlayerAttributes playerAttributes;

	private Vector3[] targetPositions;
	private float acceleration;
	private float speed;
	private float deceleration;

	private Vector3 targetLocation;
	private Vector3 targetDirection;

	private bool playStarted = false;
	// Use this for initialization
	void Start () {
		playerAttributes = GetComponent<PlayerAttributes>();
		targetPositions = new Vector3[3];
		acceleration = (float)playerAttributes.Acceleration / 200f;
		speed = (float)playerAttributes.Speed / 50f;
		deceleration = (float)playerAttributes.Agility / 70f;

		targetLocation = Vector3.zero;
		targetDirection = Vector3.zero;


		//Hacky Solutions For a Demo
		if( playerAttributes.Position == PlayerPosition.WRY )
		{
			targetPositions[0] = new Vector3(-2.15f, 0.32f, -6.2f);
			targetPositions[1] = new Vector3(-2.15f, 0.32f, 10f);
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if( playStarted )
		{
			if( targetPositions.Length <= 0
				|| targetPositions[0] == Vector3.zero )
			{
				targetLocation = Vector3.zero;
			}
			else {
				targetLocation = targetPositions[0];
			}

			Vector3 CurrentPosition = transform.position;
			float distance = Vector3.Distance(CurrentPosition, targetLocation);

			if( distance <= positionReachedThreshold)
			{
				RemovePosition();
			}

			if( targetLocation == Vector3.zero )
			{
				rigidbody.velocity *= deceleration;
			}
			else {
				//Make way to next target location
				//Establish target vector
				//Make target vector an angle
				//Adjust current angle according to target
				//Change current angle to a vector
				//make acceleration and velocity vectors out of current angle
				//Set reigidbody velocity
				targetLocation = targetPositions[0];
				targetDirection = (targetLocation - transform.position).normalized;
				if( targetDirection == rigidbody.velocity.normalized)
				{
					rigidbody.velocity += targetDirection * acceleration;
				}
				else {
					Vector3 oldVelocity = rigidbody.velocity;
					oldVelocity /= deceleration;
					if( oldVelocity.magnitude <= 0.05f)
					{
						oldVelocity = Vector3.zero;
					}

					Vector3 newVelocity = targetDirection * acceleration;
					rigidbody.velocity = oldVelocity + newVelocity;
				}

				if( rigidbody.velocity.magnitude >= speed)
				{
					rigidbody.velocity = rigidbody.velocity.normalized * speed;
				}
			}

			//if( Vector3.Distance(transform.position, targetLocation) <= closeToTouchThreshold )
			//{
			//	rigidbody.velocity /= deceleration;
			//}
	}

	}

	public void SetNewTarget(Vector3 newTarget)
	{
		for(int i = 0; i < targetPositions.Length; ++i)
		{
			targetPositions[i] = Vector3.zero;
		}

		targetPositions[0] = newTarget;
	}

	public void RemovePosition()
	{ 
		for(int i = 1; i < targetPositions.Length; ++i)
		{
			targetPositions[i-1] = targetPositions[i];
		}

		targetPositions[targetPositions.Length - 1] = Vector3.zero;
	}

	public void StartPlay()
	{
		playStarted = true;
		targetLocation = targetPositions[0];
	}
}
