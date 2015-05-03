using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public int stayingAliveScore;
	public static int score;        // The player's score.
	Text text;                      // Reference to the Text component.
	
	
	void Awake ()
	{
		// Set up the reference.
		text = GetComponent <Text> ();
		
		// Reset the score.
		score = 0;
	}

	void Start(){
		InvokeRepeating("addScore", 1f, 1f);
	}
	
	void Update ()
	{
		// Set the displayed text to be the word "Score" followed by the score value.
		text.text = "Score: " + score;
	}

	void addScore(){
		score += stayingAliveScore;
	}

}
