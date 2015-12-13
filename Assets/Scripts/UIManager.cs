using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	//public Animator contentPanel;
	public Animator settingsPanel;
	public Animator mainMenuPanel;
	public Animator infoPanel;

	public Text info;
	public Text hint;

	//public Image backgroundBlocker;




	// Use this for initialization
	void Start()
	{
		//SIDE MENU
	/*	RectTransform transform = contentPanel.gameObject.transform as RectTransform;        
		Vector2 position = transform.anchoredPosition;
		position.x += transform.rect.width;
		transform.anchoredPosition = position;
*/
		//MAIN MENU
		RectTransform transform = mainMenuPanel.gameObject.transform as RectTransform;        
		Vector2 position = transform.anchoredPosition;
		position.y += transform.rect.height+300;
		transform.anchoredPosition = position;

		//SETTINGS MENU
		transform = settingsPanel.gameObject.transform as RectTransform;        
		position = transform.anchoredPosition;
		position.y -= transform.rect.height+300;
		transform.anchoredPosition = position;

		//Info Panel
		transform = infoPanel.gameObject.transform as RectTransform;        
		position = transform.anchoredPosition;
		position.y += transform.rect.height+400;
		transform.anchoredPosition = position;
		//backgroundBlocker.enabled = false;


	}
	/*
	public void ToggleSideMenu()
	{
		contentPanel.enabled = true;
		
		bool isHidden = contentPanel.GetBool("isHidden");
		contentPanel.SetBool("isHidden", !isHidden);
	}
*/

	public void ToggleMainMenu(){
		mainMenuPanel.enabled = true;


		bool isHidden = mainMenuPanel.GetBool("isHidden");
		mainMenuPanel.SetBool("isHidden", !isHidden);

		if((settingsPanel.enabled==true )&& (settingsPanel.GetBool("isHidden")==false)){
			settingsPanel.SetBool("isHidden", true);
		}
		//backgroundBlocker.enabled = isHidden;
	}


	public void ToggleSettingsMenu(){
		settingsPanel.enabled = true;
		mainMenuPanel.enabled = true;

		bool isHidden = mainMenuPanel.GetBool("isHidden");
		mainMenuPanel.SetBool("isHidden", !isHidden);

		 isHidden = settingsPanel.GetBool("isHidden");
		settingsPanel.SetBool("isHidden", !isHidden);
	
	}

	public void ToggleInfoPanel(){

				infoPanel.enabled = true;
	

				mainMenuPanel.SetBool ("isHidden", true);
				settingsPanel.SetBool ("isHidden", true);

				
						//backgroundBlocker.enabled = true;
						infoPanel.SetBool ("isHidden", false);
		info.enabled = true;
		hint.enabled = false;

	}
	public void CloseInfoPanel (){
		//backgroundBlocker.enabled = false;
		infoPanel.SetBool ("isHidden", true);
	
	}

	public void ShowInfo(){
		info.enabled = true;
		hint.enabled = false;
		}
	public void ShowHint (){
		info.enabled = false;
		hint.enabled = true;
		}

	public void setDifficulty(bool dif){
		
		((settings)FindObjectOfType (typeof(settings))).setDifficulty (dif);
	}
	
	public void setSound(float soundIn){
		((settings)FindObjectOfType (typeof(settings))).setSound (soundIn);
	}
	

	public void levelComplete(){
		PlayerPrefs.Save ();
		Application.LoadLevel("mainMenu");
		}


}
