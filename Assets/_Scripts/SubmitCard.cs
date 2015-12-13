using UnityEngine;
using System.Collections;

public class SubmitCard : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;
	AudioSource audioclick;

	void OnMouseUp() {
//		Debug.Log("SubmitCard clicked!");
		GameObject currentcard = GameObject.Find("CardZoomTemplate(Clone)");
		audio.PlayOneShot(audioclick.clip, 1F);

		if(currentcard) {

			 cc.AddtoTimeline(currentcard.GetComponent<Card>().year);
			 Debug.Log(currentcard.GetComponent<Card>().year);
		} 

	}



	// Use this for initialization
	void Start () {
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();
		audioclick = GetComponentInParent<AudioSource>();

//		Debug.Log("SubmitCard.cs Start");
//		Debug.Log(cc);

	}

	
	// Update is called once per frame
	void Update () {
	
	}
}

