using UnityEngine;
using System.Collections;

public class star : MonoBehaviour {


	private playerLogic player;
	private constalation mainConstalation;

	// Use this for initialization
	void Start () {
		player = (playerLogic)(GameObject.FindGameObjectWithTag ("player").GetComponent (typeof(playerLogic)));
				if (gameObject.transform.parent != null) {
						mainConstalation = (constalation)gameObject.transform.parent.GetComponent (typeof(constalation));
				}
	
		}

	void OnMouseEnter(){

		player.over= this;
	}
	void OnMouseExit(){

		player.over = null;

	}
	public bool checkMainConstalation(star begin,star over){
				return mainConstalation.checkLines (begin, over);
		}

	public void clearMainConstalation(){
			mainConstalation.clearLines ();
		}
	public bool getIsHardMode(){
		return mainConstalation.isHardMode;
	}
				
				

		
}
