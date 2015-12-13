﻿using UnityEngine;
using System.Collections;

//Part is another serializable data storage class just like WeaponDefinition
[System.Serializable]
public class Part{
	// These three fields need to be defined in the Inspector pane
	public string				name;		// The name of this part
	public float				health; 	// The amount of health this part has
	public string[]				protectedBy;	// The other parts that protect this

	//these two fields are set automatically in Start().
	// Caching like this makes it faster and easier to find these later

	public GameObject			go;			// The GameObject of this part
	public Material				mat;		// The material to show damage
}

public class Enemy_4 : Enemy {
	// Enemy_4 will start offscreen and then pick a random point on screen to 
	// move to. Once it has arrived, it will pick another random point and
	// continue until the player has shot it down.

	public Vector3[]			points; // Stores the p0 & p1 for interpolation
	public float				timeStart; // Birth time for this Enemy_4
	public float				duration = 4; // Duration of movement

	public Part[]				parts;		// The array of ship Parts

	void Start() {
		points = new Vector3[2];
		// There is already an intial position chosen by Main.SpawnEnemy()
		// so add it to points as the initial p0 & p1
		points[0] = pos;
		points[1] = pos;

		InitMovement();

		// Cashe GameObject & Material of each Part in parts
		Transform t;
		foreach(Part prt in parts) {
			t = transform.Find(prt.name);
				if (t != null) {
				prt.go = t.gameObject;
				prt.mat = prt.go.renderer.material;
			}
		}
	}

	void InitMovement() {
		// Pick a new point to move to that is on screen
		Vector3 p1 = Vector3.zero;
		float esp = Main.S.enemySpawnPadding;
		Bounds cBounds = Utils.camBounds;
		p1.x = Random.Range(cBounds.min.x + esp, cBounds.max.x - esp);
		p1.y = Random.Range(cBounds.min.y + esp, cBounds.max.y - esp);

		points[0] = points[1]; // Shift points[1] to points[0]
		points[1] = p1;			// Add p1 as points[1]

		//Rest the time
		timeStart = Time.time;
	}

	public override void Move() {
		// This completely overrides Enemy.Move() with a linear interpolation

		float u = (Time.time-timeStart)/duration;
		if (u>=1) { // if u >=1...
			InitMovement(); // _then initialize movement to a new point
			u=0;
		}

		u = 1 - Mathf.Pow( 1-u, 2 );		// Apply Ease Out easing to u

		pos = (1-u)*points[0] + u*points[1]; // Simple linear interpolation
	}

	// This will override the OnCollisionEnter that is part of Enemy.cs
	// Becasue of the way that MonoBehaviour declares common Unity functions
	// like OnCollisionEnter(), the override keyword is not necessary.
	void OnCollisionEnter( Collision coll ) {
		GameObject other = coll.gameObject;
		switch (other.tag) {
		case "ProjectileHero":
			Projectile p = other.GetComponent<Projectile>();
			bounds.center = transform.position + boundsCenterOffset;
			if (bounds.extents == Vector3.zero || Utils.ScreenBoundsCheck(bounds, BoundsTest.offScreen) != Vector3.zero) {
				Destroy(other);
				break;
			}

			GameObject goHit = coll.contacts[0] .thisCollider.gameObject;
			Part prtHit = FindPart(goHit);
			if (prtHit == null) {
				goHit = coll.contacts[0] .otherCollider.gameObject;
				prtHit = FindPart(goHit);
			}

			if (prtHit.protectedBy != null) {
				foreach( string s in prtHit.protectedBy ) {
					if (!Destroyed(s)) {
						Destroy(other);
						return;
					}
				}
			}
			prtHit.health -= Main.W_DEFS[p.type].damageOnHit;
			ShowLocalizedDmage(prtHit.mat);

			if (prtHit.health <= 0) {
				prtHit.go.SetActive(false);
			}
			bool allDestroyed = true;
			foreach( Part prt in parts ) {
				if (!Destroyed(prt)) {
					allDestroyed = false;
					break;
				}
			}
			if (allDestroyed) {
				Main.S.ShipDestroyed( this );
				Destroy(this.gameObject) ;
			}
			Destroy(other);
			break;
		}
	}

	Part FindPart(string n) {
		foreach( Part prt in parts ) {
			if (prt.name == n) {
				return( prt );
			}
		}
		return( null );
	}
	Part FindPart(GameObject go){
		foreach( Part prt in parts ) {
			if (prt.go == go) {
				return( prt );
			}
		}
		return( null );
	}

	bool Destroyed(GameObject go) {
		return( Destroyed( FindPart(go) ));
	}
	bool Destroyed(string n) {
		return( Destroyed( FindPart(n) ) );
	}
	bool Destroyed(Part prt) {
		if (prt == null) {
			return(true);
		}
		return (prt.health <= 0);
	}

	void ShowLocalizedDmage(Material m) {
		m.color = Color.red;
		remainingDamageFrames = showDamageForFrames;
	}
}
