using UnityEngine;
using System.Collections;
[RequireComponent(typeof(GUITexture))]

public class TouchButtonClass : MonoBehaviour {
	private GUITexture _gui;
	public Vector2 MousePosition;

	public Vector2 Scale;
	public string ButtonAction;
	private bool _buttonEnabled;			//this means the button can only be pressed once and will not trigger more than one event

	// Use this for initialization
	void Start () {
		transform.localScale = Vector3.zero;		//for some reason gui elements scale from 0 not 1
		_gui = GetComponent<GUITexture>();
		_gui.pixelInset = new Rect( _gui.pixelInset.x, _gui.pixelInset.y, Scale.x, Scale.y );	//make sure its pixel perfect

		//Debug.Log( ButtonAction+":"+_gui.pixelInset.x+" : "+_gui.pixelInset.y+" / "+_gui.texture.width+" : "+_gui.texture.height );
	}
	
	// Update is called once per frame
	void Update () {
		_buttonEnabled = false;		//reset the button each cycle

		foreach ( Touch touch in Input.touches ) {
			if ( _buttonEnabled ) return;			//exit the function
			if ( !_gui.HitTest( touch.position ) ) continue;		//do hit test, we 'press' it

			switch ( touch.phase ) {
			case TouchPhase.Began:
			case TouchPhase.Moved:
			case TouchPhase.Stationary:
				ButtonPressed( touch.position );//We hit the button!
				return;//Return completely out of the update.
			}
		}
		//NOTE: PC TESTING
		if (_buttonEnabled) return;//don't go any further if this button is pressed.
		
		MousePosition = Input.mousePosition;
		if (!Input.GetMouseButton(0)) return;//Bugger off if no mouse press.
		if (!_gui.HitTest(MousePosition)) return;
		ButtonPressed( MousePosition ); //We hit the button!
	}

	private void ButtonPressed( Vector2 location )
	{
		_buttonEnabled = true;//This button has been hit.
		TouchClass.AddEntry( ButtonAction, location, Scale );
	}
}


/*
public class UnityBasic1 : MonoBehaviour
{
	void Update()
	{
	    _buttonEnabled = false;//We reset the button.
 
	    foreach (Touch touch in Input.touches)
	    {
	        if (_buttonEnabled) return;//don't go any further if this button is pressed.
	        if (!_gui.HitTest(touch.position)) continue;//do hit test, we 'press' it??
	        switch (touch.phase)
	        {
	        }
	    }
 
	}
 
}
 * */