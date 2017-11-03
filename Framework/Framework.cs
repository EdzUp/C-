/*
 * 
 *	Framework.cs - Copyright (C)EdzUp
 *	Programmed by Ed 'EdzUp' Upton
 */

using UnityEngine;
using System.Collections;

static class Framework {
	static float DrawRotation;
	static float DrawScaleX;
	static float DrawScaleY;
	static float DrawAlpha;

	static float DisplayWidth;
	static float DisplayHeight;

	static public MathClass Math = new MathClass();
	static public DisplaySystemClass Display = new DisplaySystemClass();
	static public ConversionClass Conversion = new ConversionClass();
	static public FileSystemClass FileSystem = new FileSystemClass();
	static public RandomClass RandomSystem = new RandomClass();
	static public TextFileSystemClass TextFileSystem = new TextFileSystemClass();
	static public MeshClass MeshSystem = new MeshClass();
	static public TextSystemClass TextSystem = new TextSystemClass();
	static public GUIClass GUiSystem = new GUIClass();

	static public bool Test(){
		Debug.Log ( "Test" );
		return( true );
	}
};

/*
Class FrameworkClass
	Public
	Field GUI:GUIClass = New GUIClass
	Field FileSystem:FileHandlerClass = New FileHandlerClass
	Field Display:DisplayClass = New DisplayClass
	Field Math:MathClass = New MathClass
	Field Convert:ConvertClass = New ConvertClass
	
	Method Startup:Bool( Width:Float, Height:Float )
		DrawRotation = 0.0
		DrawScaleX = 1.0
		DrawScaleY = 1.0
		DrawAlpha = 1.0
		SetDesignScale( Width, Height )
		
		DisplayWidth = Width
		DisplayHeight = Height
		
		Return( True )
	End
	
	Method ChangeResolution:Bool( Width:Float, Height:Float )
		DrawRotation = 0.0
		DrawScaleX = 1.0
		DrawScaleY = 1.0
		DisplayWidth = Width
		DisplayHeight = Height
	End
	
	Method VirtualWidth:Int()
		Return( DisplayWidth )
	End
	
	Method VirtualHeight:Int()
		Return( DisplayHeight )
	End
	
	Method SMouseX:Int()
		Return( MouseX() /PixelScaleX )
	End

	Method SMouseY:Int()
		Return( MouseY() /PixelScaleY )
	End
	
	Method Line:Int( SX:Float, SY:Float, EX:Float, EY:Float )
		DrawLine( SX *PixelScaleX, SY *PixelScaleY, EX *PixelScaleX, EY *PixelScaleY )
		
		Return( 0 )
	End
	
	Method Box:Int( X:Float, Y:Float, Width:Float, Height:Float )
		DrawRect( X *PixelScaleX, Y *PixelScaleY, Width *PixelScaleX, Height *PixelScaleY )

		Return( 0 )
	End
	
	Method xScale:Float()
		Return( ScaledX() )
	End
	
	Method YScale:Float()
		Return( ScaledY() )
	End
	
	Method ChangeScale( X:Float, Y:Float )
		DrawScaleX = X
		DrawScaleY = Y
	End
	
	Method ChangeRotation( Rotation:Float )
		DrawRotation = Rotation
	End
	
	Method ChangeAlpha( Alpha:Float )
		DrawAlpha = Alpha
	End
	
	Method LoadGraphic:Image( filename:String, Center:Bool = False )
		Local Temp:Image = LoadImage( filename )
		If ( Temp = Null ) Error "No image loaded <"+filename+">"
		
		If ( Center = True ) 
		'MidHandleImage( Temp )
			Temp.SetHandle( Temp.Width() *0.5, Temp.Height() *0.5 )
		Endif
		
		Return( Temp )
	End

	Method LoadAnimGraphic:Image( filename:String, Width:Int, Height:Int, Count:Int, Center:Bool = False )
		Local Temp:Image = LoadImage( filename, Width, Height, Count )
		If ( Temp = Null ) Error "No image loaded <"+filename+">"
		
		If ( Center = True ) MidHandleImage( Temp )
		
		Return( Temp )
	End

	Method PasteImage( image:Image, X:Float, Y:Float, Frame:Int =0 )
		If ( image = Null ) Error "No image loaded"
		SetAlpha( DrawAlpha )
		DrawImage( image, X *PixelScaleX, Y *PixelScaleY, DrawRotation, DrawScaleX *PixelScaleX, DrawScaleY *PixelScaleY, Frame )
		SetAlpha( 1.0 )
	End
	
	Method PasteScaledImage( image:Image, X:Float, Y:Float, XScale:Float, YScale:Float, Frame:Int =0 )
		If ( image = Null ) Error "No image loaded"
		SetAlpha( DrawAlpha )
		DrawImage( image, X *PixelScaleX, Y *PixelScaleY, DrawRotation, XScale, YScale, Frame )
		SetAlpha( 1.0 )
	End
	
	Function MidHandleImage(im:Image)
		If ( im = Null ) Error "No image loaded"
		im.SetHandle Int(im.Width () * 0.5), Int(im.Height () * 0.5)
	End
End

Global Framework:FrameworkClass = New FrameworkClass

  * */