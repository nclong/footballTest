using UnityEngine;

public static class Constants {
	
	public static float TouchXMin { get { return 0f; } }
	public static float TouchXMax { get { return 780f; } }
	public static float RunningYMax { get { return 160f; } }
	public static float RunningYMin { get { return 0f; } }
	public static float RunningDeadZoneXMin { get { return 275f; } }
	public static float RunningDeadZoneXMax { get { return 360f; } }
	public static float RunningUIYValue { get { return 77.34f; } }
    public static Vector3 BallAirDrag { get { return new Vector3( -0.1f, -9.8f, -0.1f ); } }
    public static Vector3 BallOffset { get { return new Vector3( 0.56f, 0.466f, 0.089f ); } }
}
