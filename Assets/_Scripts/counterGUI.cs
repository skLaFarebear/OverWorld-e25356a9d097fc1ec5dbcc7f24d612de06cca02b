using UnityEngine;
using System.Collections;

public class counterGUI : MonoBehaviour {

	guessKeeper gk;
	GameObject scores;
	string correctGuesses;

	CardController cc;
	GameObject controlCube;

	public GUIStyle counterSkin;
	public GUIStyle instructionSkin;

	// Use this for initialization
	void Start () {
		scores = GameObject.Find("guessKeeper");
		gk = scores.GetComponent<guessKeeper>();
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();

	}

	// Update is called once per frame
	void Update () {
		correctGuesses = gk.goodGuesses.ToString();

		}
	void OnGUI() {
		if(gk.goodGuesses > 0) {
			GUI.Label(new Rect(Screen.width-240, Screen.height-50, 100, 20), "Correct: "+correctGuesses, counterSkin);
		}

		if(cc.badGuesses > 0) {
			GUI.Label(new Rect(20, Screen.height-50, 100, 20), "Incorrect: ", counterSkin);
		}

		GUI.Label(new Rect(20, Screen.height/2, 280, 20), "Left-click to select a card from your Hand (below) and left-click the left and right arrows to scroll the timeline left or right.", instructionSkin);
		
		GUI.Label(new Rect(Screen.width-320, Screen.height/2-15, 280, 20), "Left-click the up arrow to attempt to place the selected event into the timeline.", instructionSkin);

	}
}
