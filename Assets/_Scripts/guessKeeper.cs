using UnityEngine;
using System.Collections;

public class guessKeeper : MonoBehaviour {

	public int goodGuesses;

	// Use this for initialization
	void Start () {
	}
	// Update is called once per frame
	void Update () {
	}
	void Awake() {
		DontDestroyOnLoad(transform.gameObject);
	}
	public void CorrectAnswer() {
		goodGuesses++;
	}

}