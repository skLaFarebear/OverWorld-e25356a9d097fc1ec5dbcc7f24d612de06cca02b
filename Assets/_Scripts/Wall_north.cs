using UnityEngine;
using System.Collections;
//stop player from moving north past object/wall
[RequireComponent(typeof(AudioSource))]
public class Wall_north : MonoBehaviour {

	public AudioClip bump;

	void OnCollisionStay(){
		Player.S.moveup = false;
	}

	void OnCollisionEnter(){
		audio.PlayOneShot (bump);
	}
	
	void OnCollisionExit(){
		Player.S.moveup = true;
	}

}
