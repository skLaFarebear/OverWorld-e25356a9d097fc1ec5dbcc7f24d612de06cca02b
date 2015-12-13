using UnityEngine;
using System.Collections;
//stop player from moving west past object/wall
[RequireComponent(typeof(AudioSource))]
public class Wall_west : MonoBehaviour {

	public AudioClip bump;

	void OnCollisionStay(){
		Player.S.moveleft = false;
	}

	void OnCollisionEnter(){
		audio.PlayOneShot (bump);
	}
	
	void OnCollisionExit(){
		Player.S.moveleft = true;
	}
}
