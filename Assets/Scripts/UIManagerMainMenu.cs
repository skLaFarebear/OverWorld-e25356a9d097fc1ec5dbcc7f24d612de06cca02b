using UnityEngine;
using System.Collections;

public class UIManagerMainMenu : MonoBehaviour {

//	public Animator titlePanel;
	public Animator mainButtonsPanel;
	public Animator settingsPanel;
	public Animator deleteConformationPanel;
	public Animator levelSelectPanel;

	public string levelToLoad;

	void Start () {
			
		}

	public void levelSpring(){
		Application.LoadLevel("temp");
	}

	public void levelTutorial(){
		Application.LoadLevel("Tutorial");
	}


	
	public void setDifficulty(bool dif){

		((settings)FindObjectOfType (typeof(settings))).setDifficulty (dif);

		if (((settings)FindObjectOfType (typeof(settings))).difficulty==true) {
			PlayerPrefs.SetInt("diff",1);
		} else {
			PlayerPrefs.SetInt("diff",0);	
		}

	}
	
	public void setSound(float soundIn){
		((settings)FindObjectOfType (typeof(settings))).setSound (soundIn);

		PlayerPrefs.SetFloat ("soundLevel",((settings)FindObjectOfType (typeof(settings))).soundLevel);
	}

	public void toggleDeletePanel(){
			deleteConformationPanel.SetBool ("isHidden",!deleteConformationPanel.GetBool("isHidden"));
		}

	public void toggleSettings(){
		if(deleteConformationPanel.GetBool("isHidden")==false){
			toggleDeletePanel();
		}
		settingsPanel.SetBool ("isHidden",!settingsPanel.GetBool("isHidden"));
		mainButtonsPanel.SetBool ("isHidden",!mainButtonsPanel.GetBool("isHidden"));
	//	titlePanel.SetBool ("isHidden",!titlePanel.GetBool("isHidden"));
	}

	public void toggleLevelPanel(){
		levelSelectPanel.SetBool ("isHidden",!levelSelectPanel.GetBool("isHidden"));
		mainButtonsPanel.SetBool ("isHidden",!mainButtonsPanel.GetBool("isHidden"));
	//	titlePanel.SetBool ("isHidden",!titlePanel.GetBool("isHidden"));
		settingsPanel.SetBool ("isHidden",true);

	}
	public void deleteData(){
		PlayerPrefs.DeleteAll ();
		PlayerPrefs.SetFloat ("soundLevel",((settings)FindObjectOfType (typeof(settings))).soundLevel);
		if (((settings)FindObjectOfType (typeof(settings))).difficulty==true) {
			PlayerPrefs.SetInt("diff",1);
		} else {
			PlayerPrefs.SetInt("diff",0);	
		}
		PlayerPrefs.Save ();
	}

	public void overWorldExit(){
		//show mouse
		Screen.showCursor = true;
		//remove settings object
		settings set = (settings)FindObjectOfType (typeof(settings));
		if(set!=null){
			Destroy(set);
		}
		if (levelToLoad != "") {
						Application.LoadLevel (levelToLoad);
				} else {
					Application.Quit();
				}
	}




}
