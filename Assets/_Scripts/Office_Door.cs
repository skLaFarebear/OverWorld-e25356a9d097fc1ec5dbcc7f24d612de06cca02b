using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Office_Door : MonoBehaviour {

	public bool Space_Check = false;
	public bool Player_Lock = true;
	public GUIText Credits;
	public Object CreditsObject;
	
	public void OnCollisionEnter(){
		Space_Check = true;
		if (Player_Lock == true) {
			CreditsObject = Instantiate(Credits);
			LockMovement();
		}
	}
	
	public void OnCollisionExit(){
		Space_Check = false;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Player.S.moveright = true;
		}
		Destroy(CreditsObject);
	}
	
	void Update(){
		if(Input.GetKey (KeyCode.Backspace)){
			Destroy(CreditsObject);
			RightUnLockMovement();
		}
	}
	
	public void LockMovement(){
		Player.S.moveup = false;
		Player.S.movedown = false;
		Player.S.moveleft = false;
		Player.S.moveright = false;
	}
	
	public void RightUnLockMovement(){
		Player.S.moveup = true;
		Player.S.movedown = true;
		Player.S.moveleft = true;
	}
}
