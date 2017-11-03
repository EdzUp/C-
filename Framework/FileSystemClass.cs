/*
	FileSystem.cs - Copyright (C)EdzUp
	Programmed by Ed 'EdzUp' Upton
*/

using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;

class HeaderClass {
	string Name;					//name of the data (for retrieval)
	string Size;					//size of the data in hex
	string Data;					//data thats in the file
};

public class FileSystemClass {
	//FileStream		FileHand;	//this will be the stream that is for reading of the data file
	bool				FileOk;
	bool				writing;
	MemoryStream		Stream;
	BinaryReader		Binary;
	BinaryWriter		BinaryWrite;

	TextAsset			asset;

	public bool OpenResource( string filename ) {
		//this is used to read data files from the resources directory
		if ( Stream!=null ) return( false );

		asset = Resources.Load ( filename ) as TextAsset;
		if ( asset == null ) {
			Debug.LogError( ">>COULD NOT LOAD RESOURCE FILE "+filename );
			return( false );
		}
		Stream = new MemoryStream( asset.bytes );
		Binary = new BinaryReader( Stream );
		FileOk = true;
		writing = false;
		return( true );
	}

	public bool Eof( ) {
		if ( Binary.BaseStream.Position >= Binary.BaseStream.Length ) {
			return( true );
		}

		return( false );
	}

	public bool Openfile( string filename, bool writefile = false ) {
		byte[] localfile;

		if ( Stream != null ) return( false );

		localfile = System.Text.Encoding.UTF8.GetBytes( filename );

		Stream = new MemoryStream( localfile );

		if ( writefile == false ) {
			//we want to read a file
			Binary = new BinaryReader( Stream );
		} else {
			//now we want to write the file
			BinaryWrite = new BinaryWriter( Stream );
		}
		FileOk = true;
		writing = writefile;
		return( true );
	}

	public bool IsOk() {
		return( FileOk );
	}

	public void CloseFile() {
		if ( Binary != null ) Binary.Close();
		if ( Stream != null ) Stream.Close();
		if ( BinaryWrite != null ) BinaryWrite.Close();
	}

	public bool ReadBool() {
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( false );
		}
		return ( Binary.ReadBoolean() );
	}

	public int ReadInt() {
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( 0 );
		}
		return ( Binary.ReadInt32() );
	}

	public float ReadFloat() {
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( 0 );
		}

		return( Binary.ReadSingle() );
	}

	public long ReadLong() {
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( 0 );
		}

		return( Binary.ReadInt64() );
	}

	public char ReadChar() {
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( (char)0x00 );
		}

		return( Binary.ReadChar() );
	}

	public char ReadByte() {
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( (char)0x00 );
		}
		
		return( Binary.ReadChar() );
	}

	public string ReadLine() {
		char 	Temp;
		string	output;

		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( "" );
		}

		output = "";
		do {
			Temp = Binary.ReadChar();
			if ( Temp!=13 && Temp!=10 ) output +=Temp.ToString();
		} while ( Temp !=13 && Temp !=10 );

		return( output );
	}

	public string ReadString( ) {
		char 	Temp;
		int 	Length;
		string	output;
		int		pos;

		output = "";
		if ( writing == true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to read from a file set to write mode" );
			return( "" );
		}
		Length = Binary.ReadInt32();			//read in the length first
		Debug.Log ( "***String length:"+Length );
		if ( Length >200 ) Debug.LogError ( ">>>>> STRING SIZE WAY TO BIG <<<<<" );
		for ( pos=0; pos<Length; pos++ ) {
			Temp = Binary.ReadChar ();
			output += Temp.ToString();
		}
		return( output );
	}

	//writers
	public void WriteBool( bool value ) {
		if ( writing == false ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write( value );
	}

	public void WriteInt( int value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write( value );
	}
	
	public void WriteFloat( float value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write ( value );
	}
	
	public void WriteLong( long value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write ( value );
	}
	
	public void WriteChar( char value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write ( value );
	}

	public void WriteByte( char value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write ( value );
	}

	public void WriteLine( string value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write ( value );
	}
	
	public void WriteString( char[] value ) {
		if ( writing != true ) {
			Debug.LogError( "Framework.FileSystem >> Trying to write to a file in read mode" );
			return;
		}
		BinaryWrite.Write( value.Length );
		BinaryWrite.Write( value, 0, value.Length );
	}


	public bool FileExists( string filename ) {
		//see if a file exists
		if (System.IO.File.Exists( filename ) ) {
			//do stuff
			return( true );
		}

		return( false );
	}
};

/*
static void R()
	{
		// 1.
		using (BinaryReader b = new BinaryReader(File.Open("file.bin", FileMode.Open)))
		{
			// 2.
			// Position and length variables.
			int pos = 0;
			// 2A.
			// Use BaseStream.
			int length = (int)b.BaseStream.Length;
			while (pos < length)
			{
				// 3.
				// Read integer.
				int v = b.ReadInt32();
				Console.WriteLine(v);
				
				// 4.
				// Advance our position variable.
				pos += sizeof(int);
			}
		}
	}
*/

/*
	Class FileHandlerClass
	End
#Endif
#rem
Strict

Import brl.filestream

Function WriteTestFile:Int(fname: String)
	Local textFile: FileStream

' This line causes the app to fail
	Local filename: String = "monkey://data/"+fname+".txt"

' But this line works just fine
'	Local filename: String = "/Users/lindsay/Monkey/Learning/FileIOTest/FileIOTest.data/"+fname+".txt"
	
	Print "Attempting to create: "+filename
	textFile = New FileStream(filename,"w")
	If textFile = Null
		Print "Can't create text file"
		Return 0
	End
	
	textFile.WriteString("Bananas!")
	textFile.Close()
	
	Return 1 ' Success
End	

Function Main:Int()
	If WriteTestFile("test") = 0
		Print "Failure"
	Else
		Print "Success"
	End
	
	Return 0
End
#end
 */