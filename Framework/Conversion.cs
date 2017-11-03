//
//	Conversion.cs - Copyright (C)EdzUp
//	Programmed by Ed 'EdzUp' Upton
//

using UnityEngine;
using System.Collections;

public class ConversionClass {
	static public bool InOval( float x, float y, float ox, float oy, float w, float h ) {
		float dx = ( x- ox ) /w;
		float dy = ( y -oy ) /h;
			
		if ( ( dx *dx ) +( dy * dy ) <1.0 ) {
			return( true );
		} else {
			return( false );
		}
	}
}

/*
Global ConvertRGBA:Int[ 4 ]

Class ConvertClass
	Function HexToRGBA( InHex:String )
		If InHex.Length=8
			ConvertRGBA[ 0 ] = HexToDec( InHex[ 0..2 ] )
			ConvertRGBA[ 1 ] = HexToDec( InHex[ 2..4 ] )
			ConvertRGBA[ 2 ] = HexToDec( InHex[ 4..6 ] )
			ConvertRGBA[ 3 ] = HexToDec( InHex[ 6..8 ] )
			
			Print "RGBA ["+InHex+"]:"+ConvertRGBA[ 0 ]+"  "+ConvertRGBA[ 1 ]+"  "+ConvertRGBA[ 2 ]+"  "+ConvertRGBA[ 3 ]
		Else
			Error "Wrong string length"
		Endif
	End
	
	Function HexToDec:Int( Hex:String )
		Local Value:Int = 0
		Local Char:Int =0
		
		If Hex.Length() <8
			'add 0's to beginning of thing so FF becomes 000000FF
			Local TempHex:String = ""
			For Char =Hex.Length() To 7
				TempHex += "0"
			Next
			TempHex += Hex
			Hex = TempHex
		Endif
		
		Local Conversion:Int = 1		'starts at 1 then 16, 256, 4096, 
		'now the characters are 'eight bytes' now begin conversion
		For Char=7 To 0 Step -1
			If Hex[ Char ]<58
				Value += ( ( Hex[ Char ] -48 ) *Conversion )
			Else
				Value += ( ( Hex[ Char ] -55 ) *Conversion )
			Endif			
			Conversion *= 16	'multiply conversion by 16 for next byte
		Next
				
		Return Value
	End
End
 * */