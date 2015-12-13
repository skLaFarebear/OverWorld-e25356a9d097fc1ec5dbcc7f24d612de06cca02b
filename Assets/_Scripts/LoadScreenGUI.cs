using UnityEngine;
using System.Collections;

public class LoadScreenGUI : MonoBehaviour {

	public GUIStyle instructionSkin;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	void OnGUI () {
		GUI.color = Color.red;
		GUI.backgroundColor = Color.clear;
		// Make a background box
		GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2-180,300,300),"How to Play:\n\nMove cards from your Hand into\ntheir proper place on the Timeline.\n\nClick on the Left and Right\narrow keys to scroll the Timeline.\n\nClick on a card in your\nhand to inspect it.\n\nClick on the Up-Arrow\nto Submit the chosen card.");

		GUI.color = Color.red;

		// Button 1 - loads the actual game.
		if(GUI.Button(new Rect(Screen.width /2-350,Screen.height/4*3+40,200,40), "Begin Challenge")) {
			Application.LoadLevel("TimeLine-GamePlay");
		}
//		// Button 2 - loads the credits.
		if(GUI.Button(new Rect(Screen.width /2-100,Screen.height/4*3+40,200,40), "Credits")) {
			Application.LoadLevel("TimeLine-GameCredits");
		}
//		// Button 3 - returns to overworld.
		if(GUI.Button(new Rect(Screen.width /2+150,Screen.height/4*3+40,200,40), "Exit")) {
			Application.LoadLevel("_overworld_01");
		}
	}
}
