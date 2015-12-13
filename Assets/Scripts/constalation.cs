using UnityEngine;
using System.Collections;

public class constalation : MonoBehaviour {
	private int completionCount;
	private int countToComplete;

	private SpriteRenderer endImage;

	public line[] lines;


	public string conName;
	public string info;
	public string hint ;


	public bool isComplete;
	public bool isHardMode=false;

	void Start () {
		if (conName == "") {
			conName=this.name+" has not set its name yet";
				}
		if(info==""){
			info= this.name + " has not set its info yet";
		}
		if (hint == "") {
			hint= this.name + " has not set its hint yet";
				}
		int lineCount = 0;
		//adding all lines into refrence///////
		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(line)))!=null){
				lineCount++;
			}
			if(child.name=="endImage"){
				endImage=(SpriteRenderer)child.GetComponent(typeof(SpriteRenderer));
			}
		}
		if(endImage==null){
			Debug.LogError(this.name+"  HAS NO END IMAGE");
		}
		if(lineCount==0){
			Debug.LogError(this.name+"  HAS NO LINES CONNECTED TO IT");
		}
		lines = new line[lineCount];
		completionCount = lineCount;
		lineCount = 0;

		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(line)))!=null){
				lines[lineCount]=(line)child.GetComponent(typeof(line));
				lineCount++;
			}
		}
		///////////////////////////////////////
	
		if(isComplete==true){
			setComplete();
		}
		else{
			endImage.enabled=false;
			countToComplete=0;
		}
		isHardMode = false;
		if(((settings)FindObjectOfType (typeof(settings))!=null)){
			isHardMode=((settings)FindObjectOfType (typeof(settings))).getDifficulty();
		}


	}

	public void setComplete(){
		endImage.enabled=true;

		foreach(line check in lines){
			((LineRenderer)check.GetComponent(typeof(LineRenderer))).enabled=true;
			check.isActive=true;
		}
	}



	public bool checkLines(star one, star two){
		foreach(line check in lines){
			if((check.one==one && check.two==two) || (check.one==two && check.two==one)){

				if(check.isActive==false){
					countToComplete++;
					//check if all are completed
					if(countToComplete==completionCount){
						isComplete=true;
						((constalationHolder)this.transform.parent.GetComponent(typeof(constalationHolder))).completedConstalation();
						endImage.enabled=true;
						PlayerPrefs.SetInt(Application.loadedLevelName.ToString()+this.name.ToString(),1);
						this.audio.Play();
					}
					((LineRenderer)check.GetComponent(typeof(LineRenderer))).enabled=true;
					check.isActive=true;
					return true;
				}
			}
		}
		if(isComplete==false && isHardMode==true){
			clearLines();
			return false;
		}
		return false;
	}

	public void clearLines(){
		if(isHardMode==false){
			return;
		}
		countToComplete=0;
				foreach (line check in lines) {
					check.isActive=false;
					((LineRenderer)check.GetComponent(typeof(LineRenderer))).enabled=false;
				}
		}
	public void buttonPress(){
		if (isComplete == true) {
						((constalationHolder)this.transform.parent.GetComponent (typeof(constalationHolder))).setInfoPanel (conName, info, hint);
						return;		
				} else {
			((constalationHolder)this.transform.parent.GetComponent (typeof(constalationHolder))).setInfoPanel (conName,"Complete constellation for information", hint);
				}

	}


}
