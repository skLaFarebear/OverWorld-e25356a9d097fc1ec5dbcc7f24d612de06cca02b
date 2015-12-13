using UnityEngine;
using System.Collections;

public class RightScroll : MonoBehaviour {

	CardController cc;
	
	GameObject controlCube;
	AudioSource audioclick;

	void OnMouseUp() {
		cc.ScrollTimeline(1);
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
