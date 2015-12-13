﻿using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour {
	// This is an unusual but handy use of Vector2s. x holds a min value
	// and y a max value for a Random.Rage() that will be called later
	public Vector2				rotMinMax = new Vector2(15,90);
	public Vector2				driftMinMax = new Vector2(.25f,2);
	public float				lifeTime = 6f; // Seconds the PowerUp exists
	public float				fadeTime = 4f; // Seconds it will then fade
	public bool ________________________;
	public WeaponType			type; // The type of the PowerUp
	public GameObject			cube; // Reference to the Cube child
	public TextMesh				letter; // Reference to the TextMesh
	public Vector3				rotPerSecond; // Euler rotation speed
	public float				birthTime;

	void Awake() {
		// Find the Cube reference
		cube = transform.Find("Cube").gameObject;
		// Find the TextMesh
		letter = GetComponent<TextMesh>();


		// Set a random velocity
		Vector3 vel = Random.onUnitSphere; // Get Random XYZ velocity
		// Random.onUnitSphere give you a vector point that is somewhere on
		// the surface of the sphere with a radius of 1m around the orgin
		vel.z = 0; // Flatten the vel to the XY plane
		vel.Normalize(); // Make the length of the vel 1
		// Normalizing a Vector3 makes it length 1m
		vel *= Random.Range(driftMinMax.x, driftMinMax.y);
		// Above sets the velocity length to somethng between the x and y
		// values of driftMinMax
		rigidbody.velocity = vel;

		// Set the rotation of this GameObject to R: [0,0,0]
		transform.rotation = Quaternion.identity;
		// Quaternion.identity is equal to no rotation.

		// Set up the rotPerSecond for the Cube child using rotMinMax x& y
		rotPerSecond = new Vector3 (Random.Range (rotMinMax.x, rotMinMax.y),
		                           	Random.Range (rotMinMax.x, rotMinMax.y),
		                            Random.Range (rotMinMax.x, rotMinMax.y));

		// CheckOffscren() every 2 seconds
		InvokeRepeating ("CheckOffscreen", 2f, 2f);

		birthTime = Time.time;
	}

	void Update() {
		// Manually rotate the Cube child every Update()
		// Multiplying it by Time.time causes the rotation to be time-based
		cube.transform.rotation = Quaternion.Euler (rotPerSecond * Time.time);

		// Fade out the PowerUp over time
		// Given the default values, a PowerUp will exist for 10 seconds
		// and then face out over 4 seconds
		float u = (Time.time - (birthTime + lifeTime)) / fadeTime;
		// For lifeTime seconds, u will be <= 0.  Then it will transition to 1
		// over fadeTime seconds.
		// If y >= 1, destroy this PowerUp
		if (u >= 1) {
			Destroy( this.gameObject );
			return;
	}
		// Use u to determine the alpha value of the Cube & Letter
		if (u>0) {
			Color c = cube.renderer.material.color;
			c.a = 1f-u;
			cube.renderer.material.color = c;
			// Fade the Letter too, just not as much
			c = letter.color;
			c.a = 1f - (u*0.5f);
			letter.color = c;
}
	}

	// This SetType() differs from those on Weapon and Projectile
	public void SetType( WeaponType wt ) {
		// Grab the WeaponDefinition from Main
		WeaponDefinition def = Main.GetWeaponDefinition( wt );
		// Set the color of the Cube child
		cube.renderer.material.color = def.color;
		//letter.color = def.color; // We could colorize the letter too
		letter.text = def.letter; // Set the letter that is shown
		type = wt;// Finally actually set the type
	}

	public void AbsorbedBy( GameObject target ) {
		// This function is called by the Hero class when a PowerUp is collected
		// We could tween into the target and shrink in size;
		// but for now, just destroy this.gameObject
		Destroy( this.gameObject );
	}

	void CheckOffscreen() {
		// If the PowerUp has drifted entirely off screen.....
		if ( Utils.ScreenBoundsCheck( cube.collider.bounds, BoundsTest.offScreen) != Vector3.zero ) {
			// .... then destroy this GameObject
			Destroy( this.gameObject );
		}
	}
}