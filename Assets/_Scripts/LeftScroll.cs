using UnityEngine;
using System.Collections;

public class LeftScroll : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;
	AudioSource audioclick;

	// Use this for initialization
	void Start () {
		controlCube = GameObject.Find("Card Controller");
		cc = controlCube.GetComponent<CardController>();
		audioclick = GetComponentInParent<AudioSource>();
		
	}

	void OnMouseUp() {
		cc.ScrollTimeline(-1);
		audio.PlayOneShot(audioclick.clip, 1F);
	}


	// Update is called once per frame
	void Update () {
	
	}
}
