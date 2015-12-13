using UnityEngine;
using System.Collections;

public class SCI_Spawner : MonoBehaviour {
	
	static public SCI_Spawner S;
	public bool Spawn_SCI = false;
	
	void Awake(){
		S = this;
	}

	void OnTriggerEnter(){
		Spawn_SCI = true;
	}

	void OnTriggerExit(){
		Spawn_SCI = false;
	}

}
