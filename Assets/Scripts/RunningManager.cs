using UnityEngine;
using System.Collections;

public class RunningManager : MonoBehaviour {

	private GameObject Runner;
	private PlayerAttributes RunnerAttributes;
	private PlayerAwareness RunnerAwareness;

	private Vector3 RunningDirection;
	private float Acceleration;
	private float CurrentSpeed = 0;
	private float MaxSpeed;
	private Touch MainTouch;
	private float AngleDirection;
	private bool TouchActive = false;
	private Vector3 CameraToRunner;
	

	// Use this for initialization
	void Start () {
		Runner = GameObject.Find("TestRunner");
		RunnerAttributes = Runner.GetComponent<PlayerAttributes>();
		RunnerAwareness = Runner.GetComponent<PlayerAwareness>();
		Acceleration = (float)RunnerAttributes.Acceleration / 100f;;
		MaxSpeed = (float)RunnerAttributes.Speed / 100f;
		CameraToRunner = Runner.transform.position - Camera.main.transform.position;
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if( Runner != null )
		{
			if( MainTouch.phase == TouchPhase.Ended || MainTouch.phase == TouchPhase.Canceled )
			{
				TouchActive = false;
			}

			foreach( Touch touch in Input.touches ) 
			{
				if( touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Stationary ) 
				{ 
					MainTouch = touch;
					TouchActive = true;
					Debug.Log ("Touch Found.");
					Debug.Log ("Touch position: " + touch.position );
					//If a Touch is in the Running texture zone
					if( MainTouch.position.y <= Constants.RunningYMax && MainTouch.position.y >= Constants.RunningYMin )
					{
						Debug.Log ("Touch in running zone.");
						if( MainTouch.position.x >= Constants.RunningDeadZoneXMin && MainTouch.position.x <= Constants.RunningDeadZoneXMax )
						{
							Debug.Log ("Touch in dead zone.");
							Runner.transform.eulerAngles = new Vector3( Runner.transform.eulerAngles.x, 0f, Runner.transform.eulerAngles.z );
						}
						else
						{
							Debug.Log ("Touch outside dead zone.");
							if( MainTouch.position.x < Constants.RunningDeadZoneXMin )
							{
								Debug.Log ("Touch left of dead zone.");
								AngleDirection = (Constants.RunningDeadZoneXMin - MainTouch.position.x) / Constants.RunningDeadZoneXMin * -90f;
							}
							else
							{
								Debug.Log ("Touch right of dead zone.");
								AngleDirection = (MainTouch.position.x - Constants.RunningDeadZoneXMax) / (Constants.TouchXMax - Constants.RunningDeadZoneXMax) * 90f;
							}
					
							Runner.transform.eulerAngles = new Vector3( Runner.transform.eulerAngles.x, AngleDirection, Runner.transform.eulerAngles.z);
						}
					}
				}


				break;
			}

			if( !TouchActive )
			{
				AngleDirection = 0f; 
			}
			Debug.Log ( AngleDirection);
			CurrentSpeed += Acceleration;
			if( CurrentSpeed >= MaxSpeed )
			{
				CurrentSpeed = MaxSpeed;
			}

			Runner.rigidbody.velocity = Runner.transform.forward.normalized * CurrentSpeed;
			Camera.main.transform.position = Runner.transform.position - CameraToRunner;
		}
	
	}
}
