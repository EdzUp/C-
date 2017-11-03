using UnityEngine;
using System.Collections;

public class SunClass : MonoBehaviour {
	Vector3 Vec3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt( Camera.main.transform.position );
		Vec3 = transform.localEulerAngles;
		Vec3.y += 180.0f;
		transform.localEulerAngles = Vec3;
	}
}
