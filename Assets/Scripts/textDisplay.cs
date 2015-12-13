using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class textDisplay: MonoBehaviour {

	public string intro;
	public string about;
	public string howToFind;

	private Text textOut;
	private string textIn;

	public float delay;

	int c=0;
	int count=0;

	void Start(){
		textOut = GetComponent <Text>();

		textIn = intro;

		StartCoroutine("textWait");

	}

	void Update () {
		if(Input.GetMouseButtonDown(0)==true){

			//about the constilation text
			if(count==0){
				//interupts old text display
				StopCoroutine("textWait");

				//primes methods on what to display
				textIn=about;
				textOut.text="";
				c=0;

				//starts new text display
				StartCoroutine("textWait");
			}
			//how to find it
			if(count==1){

				//interupts old text display
				StopCoroutine("textWait");
				
				//primes methods on what to display
				textIn=howToFind;
				textOut.text="";
				c=0;
				
				//starts new text display
				StartCoroutine("textWait");

			}
			if(count==2){

			}
			count++;

		}

	
	}


	IEnumerator textWait(){
		for ( ;c<textIn.Length;c++){
			yield return new WaitForSeconds (delay);
			textOut.text = textOut.text+ textIn[c];
		} 

	}

}