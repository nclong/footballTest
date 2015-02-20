using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour {

    public Image WRXIndicator;
    public Image WRYIndicator;
    public Image WRZIndicator;

    public Sprite RedSprite;
    public Sprite YellowSprite;
    public Sprite GreenSprite;

	// Use this for initialization
	void Start () {
        WRYIndicator.gameObject.SetActive(false);
        WRZIndicator.gameObject.SetActive(false);
        WRXIndicator.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void FixedUpdate () {
	
	}

    public void SetIndicator(PlayerPosition position, string color)
    {
        Sprite newSprite = null;
        switch (color)
        {
            case "green":
                newSprite = GreenSprite;
                break;
            case "yellow":
                newSprite = YellowSprite;
                break;
            case "red":
                newSprite = RedSprite;
                break;
            default:
                Debug.Log("Incorrect color string passed to UIManager.SetIndicator");
                break;
        }

        switch (position)
        {
            case PlayerPosition.WRX:
                WRXIndicator.sprite = newSprite;
                break;
            case PlayerPosition.WRY:
                WRYIndicator.sprite = newSprite;
                break;
            case PlayerPosition.WRZ:
                WRYIndicator.sprite = newSprite;
                break;
            default:
                Debug.Log("Incorrect PlayerPosition passed to UIManager.SetIndicator");
                break;
        }
    }
}
