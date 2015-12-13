using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour {

	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update(){
		if (Input.GetKey (KeyCode.F)) {
			if(Input.GetKey(KeyCode.RightArrow)){
				if(Player.S.moveright){
					animator.speed = 1.3f;
					animator.SetInteger("Direction", 3);
					return;
				}
			}
			else if(Input.GetKey(KeyCode.LeftArrow)){
				if(Player.S.moveleft){
					animator.speed = 1.3f;
					animator.SetInteger("Direction", 1);
					return;
				}
			}
			else if(Input.GetKey(KeyCode.DownArrow)){
				if(Player.S.movedown){
					animator.speed = 1.3f;
					animator.SetInteger("Direction", 0);
					return;
				}
			}
			else if(Input.GetKey(KeyCode.UpArrow)){
				if(Player.S.moveup){
					animator.speed = 1.3f;
					animator.SetInteger("Direction", 2);
					return;
				}
			}
			if (Input.anyKey == false) {
				animator.speed = 0;
			}
		}
		if(Input.GetKey(KeyCode.RightArrow)){
			if(Player.S.moveright){
				animator.speed = 1;
				animator.SetInteger("Direction", 3);
				return;
			}
		}
		else if(Input.GetKey(KeyCode.LeftArrow)){
			if(Player.S.moveleft){
				animator.speed = 1;
				animator.SetInteger("Direction", 1);
				return;
			}
		}
		else if(Input.GetKey(KeyCode.DownArrow)){
			if(Player.S.movedown){
				animator.speed = 1;
				animator.SetInteger("Direction", 0);
				return;
			}
		}
		else if(Input.GetKey(KeyCode.UpArrow)){
			if(Player.S.moveup){
				animator.speed = 1;
				animator.SetInteger("Direction", 2);
				return;
			}
		}
		if (Input.anyKey == false) {
			animator.speed = 0;
		}
	}
}
