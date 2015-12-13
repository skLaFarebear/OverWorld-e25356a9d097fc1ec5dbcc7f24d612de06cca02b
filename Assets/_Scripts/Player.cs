using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	static public Player S;
	public float speed = 2f;
	public bool moveright = true;
	public bool moveleft = true;
	public bool moveup = true;
	public bool movedown = true;
	//23.28, 2.51, -17.57

	void Awake(){
		S = this;
	}

	void OnLevelWasLoaded(){
		if(SCI_Spawner.S.Spawn_SCI == true){
			SCI_Spawner.S.Spawn_SCI = false;
			this.transform.position = new Vector3 ((float)23.28, (float)2.51, (float)-17.57);
		}

	}

	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.F)) {
			speed = 15f;
			if(Input.GetKey(KeyCode.RightArrow)){
				if(moveright){
					transform.position += Vector3.right * speed * Time.deltaTime;
					return;
				}
			}
			else if(Input.GetKey(KeyCode.LeftArrow)){
				if(moveleft){
					transform.position += Vector3.left * speed * Time.deltaTime;
					return;
				}
			}
			else if(Input.GetKey(KeyCode.DownArrow) && movedown){
				if(movedown){
					transform.position += Vector3.back * speed *Time.deltaTime;
					return;
				}
			}
			else if(Input.GetKey(KeyCode.UpArrow) && moveup){
				if(moveup){
					transform.position += Vector3.forward * speed *Time.deltaTime;
					return;
				}
			}
		}
		speed = 8.5f;
		if(Input.GetKey(KeyCode.RightArrow)){
			if(moveright){
				transform.position += Vector3.right * speed * Time.deltaTime;
				return;
			}
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
			if(moveleft){
				transform.position += Vector3.left * speed * Time.deltaTime;
				return;
			}
		}
		else if(Input.GetKey(KeyCode.DownArrow) && movedown){
			if(movedown){
				transform.position += Vector3.back * speed *Time.deltaTime;
				return;
			}
		}
		else if(Input.GetKey(KeyCode.UpArrow) && moveup){
			if(moveup){
				transform.position += Vector3.forward * speed *Time.deltaTime;
				return;
			}
		}
	}
}
