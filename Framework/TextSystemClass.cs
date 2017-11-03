using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class RenderedText {
	public GameObject 		Entity;
	public Texture				Image;
	public Vector2				Position;
	public bool				RemoveMe;
}

public class FontTexture {
	public long				ID;
	public Texture				FontImage;
	public float				Width;
	public float				Height;
	public int					Characters;
	public string				CharacterSet;
	public bool				LowerCase;

	public int					xChars;
	public int					yChars;
}

/*
		GameFont.LoadFont( "EdzUpFont.png", 14, 15, 92 )
		GameFont.SetFont(  "!`#$% '()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\]^_`abcdefghijklmnopqrstuvwxyz{|}~~" )
		GameFont.SetChar( 2, 34 )		'set the char to "
		GameFont.ChangeFontSize( 14, 15 )
		GameFont.LowerCase = True
 * */

public class TextSystemClass {
	List<RenderedText>			Text = new List<RenderedText>();
	List<FontTexture>			LoadedFont = new List<FontTexture>();
	long						NextID =0;

	int 						pos;
	Vector3						Vec3;
	char[]						charArray;

	public const int			alignLeft = 0;
	public const int			alignCenter = 1;
	public const int			alignRight = 2;
	public const int			alignTop = 3;
	public const int			alignBottom = 4;

	public void DrawText( string text, float x, float y, int xalign, int yalign, long FontID ) {
		float pos;
		float xPos;
		float yPos;
		float fWidth = FontWidth ( FontID );
		float fHeight = FontHeight ( FontID );
		RenderedText RText = new RenderedText();

		//setup the alignment so they can be positioned correctly
		switch( xalign ) {
		case alignRight:
			xPos = x +( text.Length *fWidth );
			break;
		case alignCenter:
			xPos = x +( ( text.Length *fWidth ) /2.0f );
			break;
		case alignLeft:
		default:
			xPos = x;
			break;
		}
		switch( yalign ) {
		case alignBottom:
			yPos = y-fHeight;
			break;
		case alignCenter:
			yPos = y -( fHeight /2.0f );
			break;
		case alignTop:
		default:
			yPos = y;
			break;
		}

		RText.Entity = new GameObject( text );
		RText.Entity.AddComponent<MeshFilter>();

		for ( pos =0; pos<text.Length; pos++ ) {
			//need to use Framework.MeshSystem.CreateQuad( offsetx, offsety, u1, v1, u2, v2 ) :)
			RText.Entity.GetComponent<MeshFilter>().mesh = Framework.MeshSystem.CreateQuad( xPos +( pos *1.0f ), yPos, -0.5f, -0.5f, 0.5f, 0.5f );
		}
		Text.Add( RText );
	}

	public long LoadFont( string filename, int width, int height, int count, bool lowerCase ) {
		FontTexture Temp;

		Temp = new FontTexture();
		Temp.FontImage = (Texture)Resources.Load( filename );
		Temp.Width = 1.0f /( Temp.FontImage.width /width );
		Temp.Height = 1.0f /( Temp.FontImage.height /height );
		Temp.ID = NextID;
		Temp.Characters = count;
		Temp.LowerCase = lowerCase;
		Temp.xChars = width;
		Temp.yChars = height;
		LoadedFont.Add( Temp );
		NextID ++;

		return( Temp.ID );
//		Debug.Log( "X:"+Temp.Width+" Y:"+Temp.Height );
	}

	public int AlignCenter() {
		return( alignCenter );
	}

	public int AlignLeft() {
		return( alignLeft );
	}

	public int AlignRight() {
		return( alignRight );
	}

	public int AlignTop() {
		return( alignTop );
	}

	public int AlignBottom() {
		return( alignBottom );
	}

	public float FontWidth( long ID ) {
		if ( LoadedFont.Count <=-1 ) return( 0.0f );
		
		for ( pos =LoadedFont.Count-1; pos>=0; pos -- ) {
			if ( ID == LoadedFont[ pos ].ID ) {
				return( LoadedFont[ pos ].Width );
			}
		}

		return( 0.0f );
	}

	public float FontHeight( long ID ) {
		if ( LoadedFont.Count <=-1 ) return( 0.0f );
		
		for ( pos =LoadedFont.Count-1; pos>=0; pos -- ) {
			if ( ID == LoadedFont[ pos ].ID ) {
				return( LoadedFont[ pos ].Height );
			}
		}

		return( 0.0f );
	}

	public void SetCharacter( long ID, int position, char NewChar ) {
		if ( LoadedFont.Count <=-1 ) return;

		for ( pos =LoadedFont.Count-1; pos>=0; pos -- ) {
			if ( ID == LoadedFont[ pos ].ID ) {
				charArray = LoadedFont[ pos ].CharacterSet.ToCharArray();
				charArray[ position ] = NewChar;
				LoadedFont[ pos ].CharacterSet = charArray.ToString();
			}
		}
	}

	public void SetFont( long ID, string fontset ) {
		if ( LoadedFont.Count <=-1 ) return;

		for ( pos =LoadedFont.Count-1; pos>=0; pos -- ) {
			if ( ID == LoadedFont[ pos ].ID ) {
				LoadedFont[ pos ].CharacterSet = fontset;
			}
		}
	}

	public void Update( ) {
		if ( Text.Count <=-1 ) return;

		for ( pos =Text.Count-1; pos>=0; pos -- ) {
			Text[ pos ].Entity.transform.position = Camera.main.transform.position;
			Text[ pos ].Entity.transform.rotation = Camera.main.transform.rotation;
			Vec3 = Text[ pos ].Entity.transform.position;
			Vec3.x += Text[ pos ].Position.x;
			Vec3.y -= Text[ pos ].Position.y;
			Vec3.z += 10.0f;
			Text[ pos ].Entity.transform.position = Vec3;
		}
	}
}
