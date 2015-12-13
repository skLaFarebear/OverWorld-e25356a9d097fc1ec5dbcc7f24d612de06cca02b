using UnityEngine;
using System.Collections;

public class mainMenuBackgroundSpinner : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//this.transform.localRotation.Set(this.transform.position.x,this.transform.position.y,this.transform.position.z,1);

		transform.Rotate(0, 0, .01f);
		//transform.Rotate(0, Time.deltaTime, 0, Space.World);

	}
}
