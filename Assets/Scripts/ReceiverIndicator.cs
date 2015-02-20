using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ReceiverIndicator : MonoBehaviour {

    public GameObject ParentReceiver;
    public Vector3 Offset;

    private Image thisImage;
    public Vector3 distanceAdjustedOffset;
	// Use this for initialization
	void Start () {
	   thisImage = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {

	   if( ParentReceiver != null )
       {
            Vector3 PlayerCenter = ParentReceiver.renderer.bounds.center;
            Vector3 PlayerExtents = ParentReceiver.renderer.bounds.extents;
            Vector3 PlayerUpperRight = new Vector3(PlayerCenter.x + PlayerExtents.x, PlayerCenter.y + PlayerExtents.y, PlayerCenter.z);
            PlayerUpperRight = Camera.main.WorldToScreenPoint(PlayerUpperRight);
            thisImage.transform.position = PlayerUpperRight
                + new Vector3( thisImage.preferredWidth, thisImage.preferredHeight, 0f); 
       }
	}

    public void SetParentReceiver(GameObject newReceiver)
    {
        ParentReceiver = newReceiver;
    }
}
