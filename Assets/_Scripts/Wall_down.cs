using UnityEngine;
using System.Collections;
//stop player from walking down past object/wall
[RequireComponent(typeof(AudioSource))]
public class Wall_down : MonoBehaviour {

	public AudioClip bump;

	void OnCollisionStay(){
		Player.S.movedown = false;
	}

	void OnCollisionEnter(){
		audio.PlayOneShot (bump);
	}
	
	void OnCollisionExit(){
		Player.S.movedown = true;
	}

}
