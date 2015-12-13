//This represents a card object and controls which face is showing and what year it represents (for sorting).

using UnityEngine;
using System.Collections;

public class Card : MonoBehaviour {

	//year the card represents
	public int year;
	
	public Card CardTemplate;
	public Card CardZoomTemplate;

	public Texture cardback;
	
	public Texture hint;
	
	public Texture reveal;

	CardController cc;
	GameObject controlCube;
	AudioSource audioclick;


	public void SetupCard(int year) {
		//set this card's year to be = to the year sent by CardController.cs
		this.year = year;
		//print the year to testing purposes
////		Debug.Log("Setup Card: " + year);

		//set this card's hint texture 
		this.hint = Resources.Load("Hints/" + year + " B") as Texture;
		this.ShowHint();
		//set this card's reveal texture 
		this.reveal = Resources.Load("Reveals/" + year + " A") as Texture;
////		Debug.Log(hint);
	}

	public void ShowHint() {
		renderer.enabled = true;
		renderer.material.mainTexture = hint;
	}

	public void ShowDate() {
		renderer.enabled = true;
		renderer.material.mainTexture = reveal;
	}

	public void ShowBackground() {
		renderer.enabled = false;
		renderer.material.mainTexture = cardback;
	}

	void OnMouseUp() {
		if(this.tag != "Timeline") {
			cc.CardZoom(year);
		}
		audio.PlayOneShot(audioclick.clip, 1F);

	}
	
	// Use this for initialization
	void Start () {
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();
		audioclick = GetComponentInParent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
