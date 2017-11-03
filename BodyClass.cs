using UnityEngine;
using System.Collections;

/*
 * This is for all spacial bodies from planets and moons to asteroids and suns
 * */

public class BodyClass : MonoBehaviour {
	public string 		Name;
	public string 		Description;

	public string		Atmosphere;
	public long		Population;
	public string		PopulationType;

	public int			Seed;
	public float		RotationSpeed;
	public float		DockingRadius;					//this is where the player has to be in range before docking
	public float		CollisionRadius;				//if the player goes in here they crash

	Vector3				Vec3;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		Vec3 = transform.localEulerAngles;
		Vec3.y += RotationSpeed;
		transform.localEulerAngles = Vec3;
	}
}
