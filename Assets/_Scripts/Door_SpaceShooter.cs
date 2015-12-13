using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door_SpaceShooter : MonoBehaviour {

	public bool Space_Check = false;
	public bool Player_Lock = true;
	public GUIText SkyGUI;
	public Object SkyObject;

	public void OnCollisionEnter(){
		Space_Check = true;
		if (Player_Lock == true) {
			SkyObject = Instantiate(SkyGUI);
			LockMovement();
		}
	}

	public void OnCollisionExit(){
		Space_Check = false;
		Player_Lock = true;
		if (Input.GetKey (KeyCode.LeftArrow)) {
			Player.S.moveright = true;
		}
		Destroy (SkyObject);
	}

	void Update(){
		if(Input.GetKey(KeyCode.Space) && Space_Check == true){
			Application.LoadLevel("_Scene_0");
		}
		if(Input.GetKey (KeyCode.Backspace)){
			Destroy(SkyObject);
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
