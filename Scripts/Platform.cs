using UnityEngine;
using System.Collections;

static public class Platform {
	static int SelectedControl;
	static public bool touchScreen;

	static public void Initialise() {
		SelectedControl = 0;
		#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WINRT || UNITY_WP8 || UNITY_BLACKBERRY
		SelectedControl = 1;		//tablet
		#endif
		touchScreen = false;
		#if UNITY_ANDROID
		touchScreen = true;
		#endif
		#if UNITY_IOS
		touchScreen = true;
		#endif
	}

	static public int ControlMethod( ) {
		SelectedControl = 0;
		#if UNITY_ANDROID || UNITY_IPHONE || UNITY_WINRT || UNITY_WP8 || UNITY_BLACKBERRY
		SelectedControl = 1;		//tablet
		#endif
		touchScreen = false;
		#if UNITY_ANDROID
		touchScreen = true;
		#endif
		#if UNITY_IOS
		touchScreen = true;
		#endif

		return( SelectedControl );
	}

	static public void EmulateTouchInterface() {
		//this just turns on the touch interface for testing
		SelectedControl = 1;
	}
}
