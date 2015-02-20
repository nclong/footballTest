using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class PassPlayManager : MonoBehaviour {

    public GameObject theFootball;
    public Vector3 FootBallOffset;
	public Image WRXIndicator;
	public Image WRYIndicator;
	public Image WRZIndicator;

	private Dictionary<PlayerPosition, GameObject> players;
	Touch mainTouch;
	private bool startedMoving = false;
	private bool readyToPass = false;
	private bool releasedBall = false;
	private Vector3 qbTargetPos;
	private Ray touchRay;
	private float rayToPlaneDistance;
	private Vector3 playerToCamera;

    private PlayerAttributes QBAttributes;
	private int WRYReadyFrames = 0;
	private int WRXReadyFrames = 60;
	private int WRZReadyFrames = 60;
	private int frameCount = 0;
	Plane footballField;
	// Use this for initialization
	void Start () {
		footballField = new Plane(Vector3.up, Vector3.zero);
		players = OffenseTeamManager.GetPlayerDict(0);
		playerToCamera = Camera.main.transform.position - players[PlayerPosition.QB].transform.position;
        QBAttributes = players[PlayerPosition.QB].GetComponent<PlayerAttributes>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if( !releasedBall )
        {
            theFootball.transform.parent = players[PlayerPosition.QB].transform;
            theFootball.transform.localPosition = FootBallOffset;
        }
		frameCount++;
		if( frameCount >= WRXReadyFrames )
		{
			WRXIndicator.gameObject.SetActive(true);
		}
		if( frameCount >= WRYReadyFrames )
		{
			WRYIndicator.gameObject.SetActive(true);
		}
		if( frameCount >= WRZReadyFrames )
		{
			WRZIndicator.gameObject.SetActive(true);
		}
		foreach( Touch touch in Input.touches)
		{
			mainTouch = touch;
			if( mainTouch.phase == TouchPhase.Began || mainTouch.phase == TouchPhase.Moved || mainTouch.phase == TouchPhase.Stationary)
			{	
				startedMoving = true;
				touchRay = Camera.main.ScreenPointToRay(mainTouch.position);
				footballField.Raycast(touchRay, out rayToPlaneDistance);
				qbTargetPos = touchRay.GetPoint(rayToPlaneDistance);
				qbTargetPos = new Vector3(qbTargetPos.x, players[PlayerPosition.QB].transform.position.y, qbTargetPos.z);
				players[PlayerPosition.QB].GetComponent<PlayerInPlayManager>().SetNewTarget(qbTargetPos);
				Camera.main.transform.position = players[PlayerPosition.QB].transform.position + playerToCamera;
			}
			else {
				players[PlayerPosition.QB].GetComponent<PlayerInPlayManager>().RemovePosition();
				readyToPass = true;
			}
		}

	}

	public void OnIndicatorTouch(GameObject Indicator)
	{
		WRXIndicator.gameObject.SetActive(false);
		WRYIndicator.gameObject.SetActive(false);
		WRZIndicator.gameObject.SetActive(false);

		ReceiverIndicator receiverIndicator = Indicator.GetComponent<ReceiverIndicator>();
        GameObject Receiver = receiverIndicator.ParentReceiver;
        Vector3 qbToReceiver = Receiver.transform.position - players[PlayerPosition.QB].transform.position;
        Vector3 throwDirection = new Vector3(qbToReceiver.x, 1f, qbToReceiver.z).normalized;
        float maxBallSpeed = 40f;
        float estimatedTime = ( -( maxBallSpeed * 0.9f ) + Mathf.Sqrt( ( maxBallSpeed * 0.9f ) * ( maxBallSpeed * 0.9f ) + 2f * Constants.BallAirDrag.magnitude * qbToReceiver.magnitude ) ) / Constants.BallAirDrag.magnitude;
        Vector3 guessPosition = Receiver.transform.position + Receiver.rigidbody.velocity * estimatedTime;
        qbToReceiver = guessPosition - players[PlayerPosition.QB].transform.position;
        theFootball.rigidbody.velocity = new Vector3( qbToReceiver.x, 1f, qbToReceiver.z ).normalized * maxBallSpeed;
        theFootball.transform.parent = null;
        theFootball.GetComponent<BallFlight>().inAir = true;
        theFootball.rigidbody.isKinematic = false;
        theFootball.collider.isTrigger = false;
	}

}
