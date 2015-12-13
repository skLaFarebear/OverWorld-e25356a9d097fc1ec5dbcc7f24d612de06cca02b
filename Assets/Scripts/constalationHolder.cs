using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class constalationHolder : MonoBehaviour {

	public int completionCount;
	public int countToComplete=0;

	public Button endGameButton;

	public Text infoPanelName;
	public Text infoPanelInfo;
	public Text infoPanelHint;

	public RectTransform buttonHolder;
	public Button buttonBase;
	public UIManager UImanger;


	public constalation[] cons;

	// Use this for initialization
	void Start () {

		int c=0;
		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(constalation)))!=null){
				c++;
			}
		}
		cons = new constalation[c];
		completionCount = c;
		c = 0;

		foreach (Transform child in transform)
		{
			if((child.GetComponent(typeof(constalation)))!=null){
				cons[c]=(constalation)child.GetComponent(typeof(constalation));
				c++;
			}
		}
		/*
		for(c= 0;c<cons.Length;c++){
			Button butIn = (Button)(GameObject.Instantiate(buttonBase,this.transform.position ,Quaternion.identity));
			//buttonHolder.sizeDelta=new Vector2(15+(60*c),1);
			butIn.transform.SetParent(buttonHolder,false);
			//set position
			RectTransform trans= ((RectTransform)butIn.GetComponent(typeof(RectTransform)));
			trans.anchoredPosition= new Vector2((-30-(45*c)), 0);
			//set text
			((Text)butIn.GetComponentInChildren(typeof(Text))).text =cons[c].conName;
			//set button presses
			this.startButtonPanelHelper(butIn,cons[c]);

			//checks to see if a save of the constalation is completed if it does not exist it makes it. 
		
			if(PlayerPrefs.HasKey(Application.loadedLevelName.ToString()+cons[c].name.ToString())==false){
				PlayerPrefs.SetInt(Application.loadedLevelName.ToString()+cons[c].name.ToString(),0);
			}
			else{
				if (PlayerPrefs.GetInt(Application.loadedLevelName.ToString()+cons[c].name.ToString())==1){
					completedConstalation();
					cons[c].setComplete();
				}
			}

		}
		*/
	}

	void startButtonPanelHelper(Button but, constalation con){
		but.onClick.AddListener(() => {UImanger.ToggleInfoPanel(); con.buttonPress(); });
		}

	public void completedConstalation(){
		countToComplete++;
		if (countToComplete == completionCount) {

			endGameButton.interactable =true;
				}
	}


	public void setInfoPanel(string name,string info,string hint){
		infoPanelName.text = name;
		infoPanelInfo.text = info;
		infoPanelHint.text= hint;
	
	}

}
