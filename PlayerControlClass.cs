using UnityEngine;
using System.Collections;

public class PlayerControlClass : MonoBehaviour {
	public GameObject Mover;
	public int GlobalTimer;

	float Speed;
	bool MouseFlight;
	int KeyTime;
	Vector3 mousePos;

	Vector3 Vec3;
	Vector2 click;
	Vector2 clickSize;

	// Use this for initialization
	void Start () {
		MouseFlight = false;			//make sure its not on by default
		KeyTime = 0;
		Speed = 0.02f;
		Platform.Initialise();
	}
	
	// Update is called once per frame
	void Update () {
		if ( KeyTime >0 ) KeyTime--;

		if ( Input.GetKey( "escape" ) ) {
			Application.Quit();
		}

		switch( Platform.ControlMethod() ) {
		case 0:			//XBox 360, mouse+keyboard or Joystick controls
			//left analogue stick
//			Vec3.x = 0-Input.GetAxis ( "Vertical" );
//			Vec3.y = Input.GetAxis ( "Horizontal" );
//			Vec3.z = transform.localEulerAngles.z;
//			transform.Rotate( Vec3 );
/*			if ( Input.GetAxis( "Speed" )>0.0f ) {
				Speed += 0.02f;
			}
			if ( Input.GetAxis( "Speed" )<0.0f ) {
				Speed -= 0.02f;
			}*/
			if ( Speed >1.0f ) Speed = 1.0f;
			if ( Speed<0.0f ) Speed = 0.0f;
/*			if ( Input.GetButton( "Jumpdrive" ) ) {
				Speed = 20.0f;
				if ( Speed > 20.0f ) Speed = 20.0f;
			}*/
			
			if ( MouseFlight == true ) {
				mousePos = Input.mousePosition;
				mousePos.x -= Screen.width/2;
				mousePos.y -= Screen.height/2;
				
				mousePos.x *= 0.002f;
				mousePos.y *= 0.002f;
			}

			if ( Input.GetKey( "space" ) && KeyTime <= 0 ) {
				if ( MouseFlight == true ) {
					MouseFlight = false;
				} else {
					MouseFlight = true;	
				}
				
				KeyTime = GlobalTimer;
			}
			
			if ( Input.GetKey ( "up" ) ) {
				Speed += 0.2f;
			}
			if ( Input.GetKey ( "down" ) ) {
				Speed -= 0.2f;
			}
			if ( Speed >1.0f ) Speed = 1.0f;
			if ( Speed<0.0f ) Speed = 0.0f;
			
			if ( Input.GetKey ( "j" ) ) {
				Speed = 20.0f;
				if ( Speed > 20.0f ) Speed = 20.0f;
			}

			if ( MouseFlight == true ) {
				//only rotate if the mouse flight system is active
				Vec3.x = 0-mousePos.y;
				Vec3.y = mousePos.x;
			}
			Vec3.z = 0-transform.localEulerAngles.z;
			transform.Rotate( Vec3 );
			break;

		case 1 :	//tablet controls
			if ( TouchClass.IsEntryIn( "SPEEDUP" ) == true ) {
				Speed += 0.2f;
				if ( Speed>1.0f ) Speed =1.0f;
			}
			if ( TouchClass.IsEntryIn( "SLOWDOWN" ) == true ) {
				Speed -= 0.2f;
				if ( Speed<0.0f ) Speed = 0.0f;
			}
			if ( Speed >1.0f ) Speed = 1.0f;
			if ( Speed<0.0f ) Speed = 0.0f;
			if ( TouchClass.IsEntryIn( "JUMPDRIVE" ) == true ) {
				Speed *= 10.0f;
				if ( Speed>10.0f ) Speed = 10.0f;
			}
			if ( TouchClass.IsEntryIn( "JOYSTICK" ) == true ) {
				//the player has clicked on the joystick so we can now get the location of the touch
				click = TouchClass.TouchLocation( "JOYSTICK" );
				clickSize = TouchClass.TouchScale( "JOYSTICK" );

				Vec3 = transform.localEulerAngles;
				Vec3.x += ( 0.0f -( 0.0125f * (click.y -( clickSize.y /2.0f ) ) ) );
				Vec3.y += ( 0.0125f * ( click.x -( clickSize.x /2.0f ) ) );
				Vec3.z = 0.0f-transform.localEulerAngles.z;
				transform.localEulerAngles = Vec3;
			}
			break;
		default:
			break;
		}

		Mover.transform.rotation = transform.rotation;
		Mover.transform.Translate( Vector3.back *Speed );
		Vec3.x = 0.0f;
		Vec3.y = 0.0f;
		Vec3.z = 0.0f;
		Mover.transform.localEulerAngles = Vec3;
		Variable.PlayerSpeed = Speed;
//		transform.Translate( Vector3.forward *Speed );

		TouchClass.Reset();			//reset the system after processing all actions
	}
}
