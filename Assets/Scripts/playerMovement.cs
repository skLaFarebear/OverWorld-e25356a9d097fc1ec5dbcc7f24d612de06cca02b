using UnityEngine;
using System.Collections;

public class playerMovement : MonoBehaviour {

	public Vector3 mousePosition;
		
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position =  new Vector3 (mousePosition.x , mousePosition.y,5);
	
	}
}
