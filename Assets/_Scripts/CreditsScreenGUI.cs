using UnityEngine;
using System.Collections;

public class CreditsScreenGUI : MonoBehaviour {

	guessKeeper gk;
	GameObject scores;
	CardController cc;
	GameObject controlCube;

	string correctGuesses;

	public GUIStyle instructionSkin;

	// Use this for initialization
	void Start () {
		scores = GameObject.Find("guessKeeper");
		gk = scores.GetComponent<guessKeeper>();
		correctGuesses = gk.goodGuesses.ToString();
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI () {
		GUI.color = Color.red;
		GUI.backgroundColor = Color.clear;

		// Make a background box
		GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2-180,300,300),"Credits\n\nCoding & Art: Maka Gradin\nSound: Ryan Downey\nAdrian Wojas\n\nRutgers University\nInformation Technology and Informatics\n\nGame Production\nSpring 2015\nProfessor Bill Crosbie");
		
		GUI.color = Color.red;
		if(gk.goodGuesses > 1) {
			GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You successfully submitted "+ correctGuesses +" cards!");
		} else if(gk.goodGuesses == 1) {
			GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You successfully submitted "+ correctGuesses +" card!");
		} else {
			GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You need to study!");
		}


		// Button 1 - loads the actual game.
		if(GUI.Button(new Rect(Screen.width /2-350,Screen.height/4*3+40,200,40), "Begin Challenge")) {
			Application.LoadLevel("TimeLine-GamePlay");
		}
		
//		// Button 2 - loads the credits.
		if(GUI.Button(new Rect(Screen.width /2-100,Screen.height/4*3+40,200,40), "Title Screen")) {
			Application.LoadLevel("TimeLine-GameLoad");
		}
//		// Button 3 - returns to overworld.
		if(GUI.Button(new Rect(Screen.width /2+150,Screen.height/4*3+40,200,40), "Exit")) {
			Application.LoadLevel("_overworld_01");
		}
	}
}

//Original GUI:
// 	void OnGUI () {
// 		GUI.color = Color.black;
// 		GUI.backgroundColor = Color.clear;

// 		// Make a background box
// 		GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2-180,300,300),"Credits\n\nCoding & Art: Maka Gradin\nSound: Ryan Downey\nAdrian Wojas\n\nRutgers University\nInformation Technology and Informatics\n\nGame Production\nSpring 2015\nProfessor Bill Crosbie");
		
// 		GUI.color = Color.red;
// 		if(gk.goodGuesses > 1) {
// 			GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You successfully submitted "+ correctGuesses +" cards!");
// 		} else if(gk.goodGuesses == 1) {
// 			GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You successfully submitted "+ correctGuesses +" card!");
// 		} else {
// 			GUI.Box(new Rect(Screen.width/4*3-140,Screen.height/2+40,300,300),"You need to study!");
// 		}


// 		// Button 1 - loads the actual game.
// 		if(GUI.Button(new Rect(Screen.width /2-350,Screen.height/4*3+40,200,40), "Begin Challenge")) {
// 			Application.LoadLevel("TimeLine-GamePlay");
// 		}
		
// //		// Button 2 - loads the credits.
// 		if(GUI.Button(new Rect(Screen.width /2-100,Screen.height/4*3+40,200,40), "Title Screen")) {
// 			Application.LoadLevel("TimeLine-GameLoad");
// 		}
// //		// Button 3 - returns to overworld.
// 		if(GUI.Button(new Rect(Screen.width /2+150,Screen.height/4*3+40,200,40), "Exit")) {
// 			Application.LoadLevel("overworld_01");
// 		}
// 	}
// }

