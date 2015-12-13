using UnityEngine;
using System.Collections;

public class Timeline_Note_Credits : MonoBehaviour {

	public GUIText Timeline_Credits;
	public Object Timeline_Object;

	public void OnCollisionEnter(){
		Timeline_Object = Instantiate (Timeline_Credits);
	}

	public void OnCollisionExit(){
		Destroy (Timeline_Object);
	}

}
