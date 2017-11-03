using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * This will hold all the tablet touch controls for the entire game systems
 */
static public class TouchClass {
	static public List<string> TList;
	static public List<Vector2> TouchPoint;
	static public List<Vector2> ScaleList;

	static public void Initialise() {
		TList = new List<string>();
	}

	static public void Reset() {
		//reset every turn
		if ( TList != null ) {
			TList.Clear();
			TouchPoint.Clear();
			ScaleList.Clear ();
		}
	}

	static public void AddEntry( string entry, Vector2 location, Vector2 Size ) {
		//this adds it to the system for checking
		if ( TList == null ) {
			//if its not been created then make it
			TList = new List<string>();
			TouchPoint = new List<Vector2>();
			ScaleList = new List<Vector2>();
		}
		TList.Add( entry );
		TouchPoint.Add ( location );
		ScaleList.Add ( Size );
	}

	static public bool IsEntryIn( string entry ) {
		int Pos;

		if ( TList != null ) {
			for ( Pos = TList.Count-1; Pos >=0; Pos-- ) {
				if ( TList[ Pos ] == entry ) return( true );
			}
		}
		return( false );
	}

	static public Vector2 TouchLocation( string entry ) {
		int Pos;
		Vector2 fail;

		fail.x = 0.0f;
		fail.y = -1.0f;
		
		if ( TList != null ) {
			for ( Pos = TList.Count-1; Pos >=0; Pos-- ) {
				if ( TList[ Pos ] == entry ) return( TouchPoint[ Pos ] );
			}
		}
		return( fail );
	}

	static public Vector2 TouchScale( string entry ) {
		int Pos;
		Vector2 fail;
		
		fail.x = 0.0f;
		fail.y = -1.0f;
		
		if ( TList != null ) {
			for ( Pos = TList.Count-1; Pos >=0; Pos-- ) {
				if ( TList[ Pos ] == entry ) return( ScaleList[ Pos ] );
			}
		}
		return( fail );
	}
};