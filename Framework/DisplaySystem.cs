//
//	DisplaySystem.cs - Copyright (C)EdzUp
//	Programmed by Ed 'EdzUp' Upton
//

using UnityEngine;
using System.Collections;

class Mode {
	int Width;
	int Height;
};

public class DisplaySystemClass {
	//DisplayMode[] DisplayRes;
	//DisplayMode DesktopRes;

	public int Width;
	public int Height;

	public void UpdateModes() {
		//DisplayRes = DisplayModes()
		//DesktopRes = DesktopMode()
	}

	public void SetResolution( int width, int height, bool fullscreen ) {
		//this will change the resolution for the given target
	}
}

/*
Class DisplayClass
	Method SetResolution( width:Int, height:Int, fullscreen:Bool = False )
		'this will change the resolution for the given target
		Local SRes:Int
		
		If DisplayRes.Length=0
			Print "ERROR:UpdateModes has not been called before SetResolution"
			Return
		Endif
		
		For SRes = 0 To DisplayRes.Length-1
			If DisplayRes[ SRes ].Width = width And DisplayRes[ SRes ].Height = height
				If fullscreen = True
					SetDeviceWindow( width, height, 1 )
				Else
					SetDeviceWindow( width, height, 0 )
				Endif
				Framework.ChangeResolution( width, height )
				Width = width
				Height = height				
				
				Return
			Endif
		Next
		
		Print "Video resolution not acceptable using default"
		Width = 640
		Height = 480		
	End
End

 * */