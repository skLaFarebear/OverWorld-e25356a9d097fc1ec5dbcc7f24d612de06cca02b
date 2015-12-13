using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {
	static public Slingshot S;

	public GameObject prefabProjectile;
	public bool ______________________;
	public GameObject launchPoint;
	public Vector3 launchPos;
	public GameObject projectile;
	public float velocityMul = 4f;
	public bool aimingMode;

	void Awake(){
		S = this;
		Transform launchPointTrans = transform.Find ("LaunchPoint");
		launchPoint = launchPointTrans.gameObject;
		launchPoint.SetActive (false);
		launchPos = launchPointTrans.position;
	}

	void OnMouseEnter(){
		print ("Slingshot:OnMouseEnter()");
		launchPoint.SetActive (true);
	}

	void OnMouseExit(){
		print ("Slingshot:OnMouseExit()");
		launchPoint.SetActive (false);
	}

	void OnMouseDown(){
		//The player has pressed the mouse button over slingshot
		aimingMode = true;
		//Instantiate a Projectile
		projectile = Instantiate (prefabProjectile) as GameObject;
		//Start it at launch point
		projectile.transform.position = launchPos;
		//Set to isKinematic for now
		projectile.rigidbody.isKinematic = true;
	}

	void Update(){
		if (!aimingMode){
			return;
		}
		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = -Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);
		Vector3 mouseDelta = mousePos3D - launchPos;
		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;
		if(mouseDelta.magnitude > maxMagnitude){
			mouseDelta.Normalize();
			mouseDelta *= maxMagnitude;
		}
		Vector3 projPos = launchPos + mouseDelta;
		projectile.transform.position = projPos;
		if(Input.GetMouseButtonUp(0)){
			aimingMode = false;
			projectile.rigidbody.isKinematic = false;
			projectile.rigidbody.velocity = -mouseDelta * velocityMul;
			FollowCamm.S.poi = projectile;
			projectile = null;
			MissionDemolition.ShotsFired();
		}
	}

}