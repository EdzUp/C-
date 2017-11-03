using UnityEngine;
using System.Collections;

public class SpaceDustClass : MonoBehaviour {
	public GameObject	DustObject;
	public float		MaxDistance;
	Vector3				Vec3;

	// Use this for initialization
	void Start () {
	}

	public void StartPosition() {
		transform.position = Camera.main.transform.position;
		transform.rotation = Camera.main.transform.rotation;
		
		Vec3 = Camera.main.transform.localEulerAngles;
		Vec3.x = Random.Range( 0.0f, 360.0f );
		Vec3.y = Random.Range( 0.0f, 360.0f );
		Vec3.z = Random.Range( 0.0f, 360.0f );
		transform.localEulerAngles = Vec3;
		transform.Translate( Vector3.forward *Random.Range( 0.0f, MaxDistance ) );
	}
	
	// Update is called once per frame
	void Update () {
		if ( Framework.Math.DistanceVec3( Camera.main.transform.position, transform.position ) >MaxDistance ) {
			//item needs to be rehashed to make it work
			transform.position = Camera.main.transform.position;
			transform.rotation = Camera.main.transform.rotation;

			Vec3 = Camera.main.transform.localEulerAngles;
			Vec3.y += 180.0f;
			Vec3.x = Random.Range( 0.0f, 60.0f ) -Random.Range( 0.0f, 60.0f );
			Vec3.y = Random.Range( 0.0f, 60.0f ) -Random.Range( 0.0f, 60.0f );
			transform.localEulerAngles = Vec3;
			transform.Translate( Vector3.forward *( ( ( MaxDistance /8.0f ) *7.0f ) +Random.Range( 0.0f, MaxDistance /8.0f ) ) );
		}

		//rotate the dust so its facing the same place as the player
		transform.rotation = Camera.main.transform.rotation;
		transform.Translate( Vector3.back *Variable.PlayerSpeed );
		transform.LookAt( Camera.main.transform.position );
		Vec3 = transform.localEulerAngles;
		Vec3.y += 180.0f;
		transform.localEulerAngles = Vec3;
	}
}
