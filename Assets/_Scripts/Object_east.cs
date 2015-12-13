using UnityEngine;
using System.Collections;
//stops player from walking past the east wall/object
[RequireComponent(typeof(AudioSource))]
public class Object_east : MonoBehaviour {

	public AudioClip bump;

	void OnCollisionStay(){
		Player.S.moveright = false;
	}

	void OnCollisionEnter(){
		audio.PlayOneShot (bump);
	}

	void OnCollisionExit(){
		Player.S.moveright = true;
	}

}
