using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerLogic : MonoBehaviour {



	private LineRenderer lineRend;

	//public ScrollRect backGroundScrollRect;
	//public RectTransform backGround;
	//private Vector3[] worldCorners= new Vector3[4];
	// 1 top left 3 bottom right

	public AudioClip[] successChimes;
	int successChimeNumber=0;
	public AudioClip failSound;
	float lastSuccess;
	public int timeToKeepChain;



	public star begin;
	public star over;

	// Use this for initialization
	void Start () {
		lineRend = (LineRenderer)GetComponent (typeof(LineRenderer));
		//backGround.GetWorldCorners(worldCorners) ;
	}
	
	// Update is called once per frame
	void Update () {
		//player movement



		//line movement
		if(begin==null){
			lineRend.enabled=false;
			//backGroundScrollRect.horizontal=true;
			//backGroundScrollRect.vertical=true;
		}
		else{

			//backGroundScrollRect.horizontal=false;
			//backGroundScrollRect.vertical=false;
			//makes scroll rect movable if player is next to the edge
		/*	if(worldCorners[1].x- (worldCorners[1].x/10) > this.transform.position.x){
				backGroundScrollRect.horizontalNormalizedPosition = backGroundScrollRect.horizontalNormalizedPosition-(backGroundScrollRect.horizontalNormalizedPosition/1000);
			}
			if(worldCorners[3].x- (worldCorners[3].x/10) < this.transform.position.x){
				backGroundScrollRect.horizontalNormalizedPosition = backGroundScrollRect.horizontalNormalizedPosition+(backGroundScrollRect.horizontalNormalizedPosition/1000);
			}
			if(worldCorners[1].y- (worldCorners[1].y/10) > this.transform.position.y){
				backGroundScrollRect.verticalNormalizedPosition = backGroundScrollRect.verticalNormalizedPosition-(backGroundScrollRect.verticalNormalizedPosition/1000);
			}
			if(worldCorners[3].y- (worldCorners[3].y/10) < this.transform.position.y){
				backGroundScrollRect.verticalNormalizedPosition = backGroundScrollRect.verticalNormalizedPosition+(backGroundScrollRect.verticalNormalizedPosition/1000);
			}*/


			lineRend.enabled=true;
			lineRend.SetPosition(0,begin.transform.position);
			if(over==null){
				lineRend.SetPosition(1,new Vector3 (this.transform.position.x ,this.transform.position.y, 90));
			}
			else{
				lineRend.SetPosition(1,over.transform.position);		
			}
		}

		//star logic
		if(Input.GetMouseButtonDown(0)==true){
			begin=over;
		}
		if(Input.GetMouseButtonUp(0)==true){
			if(begin!=null){
				if(over==null){
					begin=null;
				}
				else{
					if(over.checkMainConstalation(begin,over)==false){
						if(begin.getIsHardMode()==true){
							begin.clearMainConstalation();
						}
												
						playFailSound();
					}else{
						playChainSound();
					}
					begin=null;
				}
			}
		}

	}



	void playChainSound(){
		//check to see if last chime happened 5 min ago

	


		if (Time.time - lastSuccess < 5) {

			this.audio.clip=successChimes[successChimeNumber];
			this.audio.Play();

			successChimeNumber++;

			if(successChimeNumber>successChimes.Length-1){
				successChimeNumber=successChimes.Length-1;
			}
		} else {
			successChimeNumber=1;
			this.audio.clip=successChimes[successChimeNumber];
			this.audio.Play();
		}
		lastSuccess = Time.time;

	}

	void playFailSound(){
		this.audio.clip=failSound;
		this.audio.Play();
		successChimeNumber = 0;
		lastSuccess = Time.time - 6;
	}

}
