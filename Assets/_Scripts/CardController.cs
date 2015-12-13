//Many hints obtained from watching "Unity Blackjack Making a Card"
// video series on YouTube:  https://youtu.be/D0GOgSkHahI

//This is attached to the Card Controller Game Object and controls card spawning.

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardController : MonoBehaviour {

	guessKeeper gk;
	GameObject scores;

	public int cardIndex;
	public List<int> yearlist = new List<int> {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
	public List<int> listOfAvailableDates = new List<int> {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
	public List<int> cardsOnTimeline = new List<int> {};
	public List<int> handOfCards = new List<int> {};
	public Card CardTemplate;
	public Card CardTimelineTemplate;
	public Card CardZoomTemplate;
	public Texture cardback;
	//Arrays of textures for images.
	public Texture[] cardhints; 	public Texture[] cardreveals;
	//The selected card placeholder
	GameObject selectedCard;
	//Timeline place holders
	GameObject TL1; GameObject TL2;	GameObject TL3;	GameObject TL4;
	GameObject H1; GameObject H2;	GameObject H3;	GameObject H4;   GameObject H5;

	public int badGuesses = 0;

	AudioSource audiowrong;

	public int firstTimelineCard = 0;

	// Use this for initialization
	void Start () {
		scores = GameObject.Find("guessKeeper");
		gk = scores.GetComponent<guessKeeper>();
		audiowrong = GetComponentInParent<AudioSource>();

		//STEP 1: Grab 4 Cards for Timeline start
		SetupTimeline();
		//STEP 2: Shuffle the remaining available Cards!
		listOfAvailableDates = ShuffleCards(listOfAvailableDates);
		//STEP 3: Shuffle out 5 Cards from the shuffledyears
		SetupHand (5);
		CardstoHand ();
		CardtoTimeline ();
	}

	//Step 1!
	void SetupTimeline(){
//Debug.Log("SetupTimeline start - number of available cards = "+ listOfAvailableDates.Count);
		for (int i = 0; i < 4; i++ )
		{
			//pick a random date from the List
			int r = Random.Range(i, listOfAvailableDates.Count);
			//save what is in the randomly slots slot in the current slot
			cardsOnTimeline.Add(listOfAvailableDates[r]);
			//save what was in the current slot in the randomly chosen slot
			listOfAvailableDates.RemoveAt(r);
// Debug.Log(cardsOnTimeline[i]+"added to Timeline list and removed from available dates");
		}
//Debug.Log("SetupTimeline end - number of available cards = "+ listOfAvailableDates.Count);
		SortTimeline();
	}

	//STEP 2!
	List<int> ShuffleCards(List<int> listOfAvailableDates) {
//		Debug.Log ("Shuffling Cards");
//		Debug.Log ("Pre-shuffle first card is "+listOfAvailableDates[0]+
//		           ". Pre-shuffle last card is "+ listOfAvailableDates[listOfAvailableDates.Count-1]);

		//for each item in the years array ...
		for (int i = 0; i < listOfAvailableDates.Count; i++ )
		{
			//save the current slotted item into temp
			int temp = listOfAvailableDates[i];
			//pick a random slot between the current slot and the end of the list
			int r = Random.Range(i, listOfAvailableDates.Count);
			//save what is in the randomly slots slot in the current slot
			listOfAvailableDates[i] = listOfAvailableDates[r];
			//save what was in the current slot in the randomly chosen slot
			listOfAvailableDates[r] = temp;
		}
		//send that back to the program
//		Debug.Log ("Post-shuffle first card is "+listOfAvailableDates[0]+
//		           ". Post-shuffle last card is "+ listOfAvailableDates[listOfAvailableDates.Count-1]);
		return listOfAvailableDates;
	}

	//STEP 3!
	void SetupHand(int x){
		for (int i = 0; i < x; i++ )
		{
			if(listOfAvailableDates.Count > 0) {
				//grab the first date from the list of available dates and save into the Hand
				handOfCards.Add(listOfAvailableDates[0]);
				//remove it from the available dates
				listOfAvailableDates.RemoveAt(0);
//Debug.Log ("New card added - there are "+handOfCards.Count+" in the hand.");

			}
		}
	}


	//STEP 4!
	void CardstoHand() {
//Debug.Log ("CardstoHand starts - there are "+handOfCards.Count+" in the hand.");
		for (int i = 0; i < 5; i++) {
			if(i < handOfCards.Count) {
				GameObject temp = GameObject.Find("TL_Hand_"+(i+1));
				Card foo = temp.GetComponent<Card>();
				foo.SetupCard (handOfCards[i]);
				foo.ShowHint();
			} else {
				GameObject temp = GameObject.Find("TL_Hand_"+(i+1));
				temp.renderer.enabled = false;
//Debug.Log("Not enough cards - hide a slot.");
			}

		}
	}

	//STEP 5! - Print cards on Timeline
	void CardtoTimeline() {
		for (int i = 0; i < 4; i++) {
			GameObject temp = GameObject.Find("TL_Space_"+i);
			Card foo = temp.GetComponent<Card>();
			int timelineindex = i+firstTimelineCard;
			if(timelineindex < 0 || timelineindex >= cardsOnTimeline.Count) {
				foo.ShowBackground();
			} else {
				foo.SetupCard (cardsOnTimeline [i+firstTimelineCard]);
				foo.ShowDate();
//Debug.Log("Placing " + cardsOnTimeline[i]+ " to the Timeline.");
			}
		}
	}
	
	public void ScrollTimeline(int x) {
Debug.Log("X = "+x);
		if(x == 1) {
	//		Debug.Log("Add one to firstTimelineCard" + firstTimelineCard);
			firstTimelineCard++;
			if(firstTimelineCard > cardsOnTimeline.Count-2) {
				firstTimelineCard = cardsOnTimeline.Count-2;
			}
Debug.Log("Going Right");
		} else if(x == -1) {
			firstTimelineCard--;
			if(firstTimelineCard < -2) {
				firstTimelineCard = -2;
			}
Debug.Log("Going Left");
		} 
Debug.Log(firstTimelineCard);
		CardtoTimeline();
		}

	//ZOOM in on a card!
	public void CardZoom(int year) {
		// display a second version of the card, larger and in the center of the hand.
// Debug.Log("CardZoom start ...");
			selectedCard =  GameObject.Find("CardZoomTemplate(Clone)");

		if(!selectedCard) {
				Card zoom = (Card)Instantiate (CardZoomTemplate, new Vector3 (-21, 1,-32), Quaternion.identity);
				zoom.SetupCard (year);
				selectedCard =  GameObject.Find("CardZoomTemplate(Clone)");
			} else {
				Card zoom = selectedCard.GetComponent<Card>();
				zoom.SetupCard(year);
			}
		//audio here.


	}


	public void AddtoTimeline(int year){
//		Debug.Log ("Start of Add to Timeline function");

		int firstCard = firstTimelineCard + 1; 
		int secondCard = firstTimelineCard + 2;
		bool ok = false;
		if (firstCard < 0 && year < cardsOnTimeline [secondCard]) {
			ok = true;
		} else if (secondCard >= cardsOnTimeline.Count && year > cardsOnTimeline [firstCard]) {
			ok = true;
		} else if (firstCard >= 0 && secondCard < cardsOnTimeline.Count) {
			if (year > cardsOnTimeline [firstCard] && year < cardsOnTimeline [secondCard]) {
			ok = true;
			}
		}
		if(ok) {
			cardsOnTimeline.Insert(firstTimelineCard + 2,year);
			CardtoTimeline();
	//		Debug.Log (selectedCard);
			Destroy(selectedCard);

			int foo = handOfCards.FindIndex(item => item == year);
	//		Debug.Log("foo = " + foo);
			handOfCards.RemoveAt(foo);
	//		Debug.Log("Card removed from hand - Hand size is now "+ handOfCards.Count);
			gk.CorrectAnswer();
			SetupHand(1);
			CardstoHand();
		} else {
	//		Debug.Log("Does not fit!");
			WrongAnswer();
		}
//		Debug.Log (handOfCards.Count + " cards left in hand.");
//		handOfCards.RemoveAt();
	}
	
	public void WrongAnswer() {
		badGuesses++;
		if (badGuesses > 2) {
			Application.LoadLevel("TimeLine-GameCredits");
		} else {
			GameObject temp = GameObject.Find("Knight"+badGuesses);
			temp.renderer.enabled = true;
			audio.PlayOneShot(audiowrong.clip, 1F);
		}
	}

	public void SortTimeline() {
		cardsOnTimeline.Sort();
	}

	// Update is called once per frame
		void Update () {
	}

	void Awake() {
//		List<int> yearlist = new List<int> {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
//		List<int> listOfAvailableDates = new List<int> {1766,1795,1809,1812,1825,1869,1873,1918,1921,1924,1932,1934,1943,1945,1946,1950,1952,1961,1963,1966,1969,1971,1972,1989,1995,1998,1999,2006,2007,2009,2012,2013};
//		List<int> cardsOnTimeline = new List<int> {};
//		List<int> handOfCards = new List<int> {};
		scores = GameObject.Find("guessKeeper");
		gk = scores.GetComponent<guessKeeper>();
		gk.goodGuesses = 0;
	}

	public void Reset() {
	}
}