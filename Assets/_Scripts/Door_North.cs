using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Door_North : MonoBehaviour {
	
	public bool Space_Check = false;
	public bool Player_Lock = true;
	public GUIText SkyGUI;
	public Object SkyObject;
	
	public void OnCollisionEnter(){
		Space_Check = true;
		SkyObject = Instantiate(SkyGUI);
		LockMovement();
	}

	public void OnCollisionExit(){
		Space_Check = false;
		Player_Lock = true;
		Destroy (SkyObject);
	}
	
	void Update(){
		if(Input.GetKey(KeyCode.Space) && Space_Check == true){
			Application.LoadLevel("Timeline-GameLoad");
		}
		if(Input.GetKey (KeyCode.Backspace)){
			Destroy(SkyObject);
			UpUnLockMovement();	
		}
	}
	
	public void LockMovement(){
		Player.S.moveup = false;
		Player.S.movedown = false;
		Player.S.moveleft = false;
		Player.S.moveright = false;
	}
	
	public void UpUnLockMovement(){
		Player.S.moveright = true;
		Player.S.movedown = true;
		Player.S.moveleft = true;
		Player.S.moveup = false;
	}
	
}

