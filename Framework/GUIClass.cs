using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUITextClass {
	public long						ID;							//this is the ID of the text for changing or removal
	public GameObject					Text;						//the object
	public Vector2						Position;
	public MeshRenderer				Render;						//a simple renderer
	public Material					Mat;						//material attached to object
	public bool						RemoveMe;					//if true delete the entry
};

public class GUIClass {
	// Use this for initialization
	List<GUITextClass>					TextList;
	int									pos;
	long								NextID;

//	GameObject							WallText;
//	MeshRenderer						Render;
//	Material							Mat;
	Font 								myFont;
	Vector3								Vec3;
	long								GameFont;

	void InitialiseGUI() {
		TextList = new List<GUITextClass>();
		myFont = Resources.Load<Font>( "unispace" );

		AddText ( "Bogies", 1.0f, 1.0f, 0, 0 );

		GameFont = Framework.TextSystem.LoadFont( "EdzUpFont", 18, 18, 96, true );
		Framework.TextSystem.SetFont( GameFont, "!`#$% '()*+,-./0123456789:;<=>?@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_`abcdefghijklmnopqrstuvwxyz{|}~~" );
		Framework.TextSystem.SetCharacter( GameFont, 2, '"' );		//set the char to "
		Framework.TextSystem.DrawText( "Bogies", 1.0f, 1.0f, 0, 0, GameFont );
	}
	
	// Update is called once per frame
	void UpdateGUI() {
		Framework.TextSystem.Update();			//update all GUI text systems

		if ( TextList.Count>-1 ) {
			for ( pos =TextList.Count-1; pos>=0; pos-- ) {
				TextList[ pos ].Text.transform.position = Camera.main.transform.position;
				TextList[ pos ].Text.transform.rotation = Camera.main.transform.rotation;
				Vec3 = TextList[ pos ].Text.transform.position;
				Vec3.x += TextList[ pos ].Position.x;
				Vec3.y -= TextList[ pos ].Position.y;
				Vec3.z += 10.0f;
				TextList[ pos ].Text.transform.position = Vec3;

				if ( TextList[ pos ].RemoveMe == true ) {
					//set to remove so get rid of it
					GameObject.DestroyImmediate( TextList[ pos ].Text );
					TextList.RemoveAt( pos );
				}
			}
		}
	}

	public void AddText( string text, float x, float y, int xalign, int yalign ) {
		GUITextClass Temp = new GUITextClass();
		Temp.ID = NextID;
		Temp.RemoveMe = false;
		Temp.Position.x = x;
		Temp.Position.y = y;
		Temp.Text = new GameObject( "text" );
		Temp.Text.AddComponent<TextMesh>();
		Temp.Text.AddComponent<MeshRenderer>();
		Temp.Render = Temp.Text.GetComponent<MeshRenderer>();
		Temp.Mat = Temp.Render.material;
		Temp.Render.material = Resources.Load<Material>( "unispace" );
		Temp.Text.GetComponent<TextMesh>().text = text;
		Temp.Text.GetComponent<TextMesh>().font = myFont;
		Vec3.x = 0.01f;
		Vec3.y = 0.01f;
		Vec3.z = 0.01f;
		Temp.Text.transform.localScale = Vec3;
		Temp.Text.GetComponent<TextMesh>().characterSize = 10.0f;
		Temp.Text.GetComponent<TextMesh>().fontSize = 10;

		TextList.Add( Temp );
		NextID ++;
	}
}
