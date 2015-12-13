using UnityEngine;
using System.Collections;

public class Entrance_GUI : MonoBehaviour {

	public GUIText EntranceGUI;
	public Object Entrance_Object;
	public Object Entrance_Textbox;
	
	void Start(){
		Entrance_Object = Instantiate (EntranceGUI);
		Entrance_Textbox = Instantiate (Entrance_Textbox);
		Player.S.movedown = false;
		Player.S.moveup = false;
		Player.S.moveright = false;
		Player.S.moveleft = false;
	}

	void Update(){
		if(Input.GetKey(KeyCode.Space)){
			Destroy(Entrance_Object);
			Destroy(Entrance_Textbox);
			Player.S.movedown = true;
			Player.S.moveup = true;
			Player.S.moveright = true;
			Player.S.moveleft = true;
		}
	}

}
