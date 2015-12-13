using UnityEngine;
using System.Collections;

public class Spaceshooter_Controls : MonoBehaviour {

	public GUIText Controls;
	public Object Controls_Object;
	
	public IEnumerator Start(){
		Controls_Object = Instantiate (Controls);
		yield return new WaitForSeconds(4.0f);
		Destroy (Controls_Object);
	}
}
