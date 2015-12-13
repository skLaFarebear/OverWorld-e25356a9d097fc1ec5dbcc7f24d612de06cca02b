using UnityEngine;
using System.Collections;

public class KnightSCI_Credits : MonoBehaviour {

	public GUIText KnightSCI_GUI;
	public Object KnightSCI_Object;
	
	void OnCollisionEnter(){
		KnightSCI_Object = Instantiate (KnightSCI_GUI);
	}
	
	void OnCollisionExit(){
		Destroy(KnightSCI_Object);
	}
}
