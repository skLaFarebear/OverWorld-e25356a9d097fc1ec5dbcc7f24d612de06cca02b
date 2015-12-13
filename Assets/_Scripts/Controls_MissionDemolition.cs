using UnityEngine;
using System.Collections;

public class Controls_MissionDemolition : MonoBehaviour {

	public GUIText Controls;
	public Object Controls_Object;
	
	public IEnumerator Start(){
		Controls_Object = Instantiate (Controls);
		yield return new WaitForSeconds(5.0f);
		Destroy (Controls_Object);
	}
}
