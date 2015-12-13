using UnityEngine;
using System.Collections;

public class Game_Design_Hallway : MonoBehaviour {

	public GUIText GDH;
	public Object GDH_Object;
	bool hallway_check = false;

	public IEnumerator OnCollisionEnter(){
		if(hallway_check == false){
			hallway_check = true;
			GDH_Object = Instantiate (GDH);
			yield return new WaitForSeconds(3.0f);
			Destroy (GDH_Object);
		}
	}
}
