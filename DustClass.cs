using UnityEngine;
using System.Collections;

public class DustClass : MonoBehaviour {
	public long			DustCount;
	public float			MaximumDistance;
	public GameObject[]	spacedust;
	public GameObject[]	Nebula;
	public GameObject[]	Asteroid;
	public GameObject[]	Mine;
	public GameObject[]	Debris;

	GameObject 			Temp;
	SpaceDustClass			TempDC;

	void Start() {
		//this will allow us to create the standard space dust
		//spacedust and nebulas would need to look at the camera
		int Pos;


		for ( Pos =0; Pos<DustCount; Pos++ ) {
			if ( spacedust.Length>0 ) {
				Temp = GameObject.Instantiate( spacedust[ Random.Range ( 0, spacedust.Length ) ] );
				Temp.AddComponent<SpaceDustClass>();
				TempDC = Temp.GetComponent<SpaceDustClass>();
				TempDC.DustObject = Temp;
				TempDC.MaxDistance = MaximumDistance;
				TempDC.StartPosition();
			}
		}
	}

	void Update() {
	}
}
