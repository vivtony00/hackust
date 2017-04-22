using UnityEngine;
using System.Collections;

public class SubScore : MonoBehaviour
{
	public int subscore = 0;					// The player's score.


	private PlayerControl playerControl;	// Reference to the player control script.
	private int previousScore = 0;			// The score in the previous frame.


	void Awake ()
	{
		// Setting up the reference.
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();
	}


	void Update ()
	{
		// Set the score text.
		GetComponent<GUIText>().text = "Score2: " + subscore;

		// If the score has changed...
		if(previousScore != subscore)
			// ... play a taunt.
			playerControl.StartCoroutine(playerControl.Taunt());

		// Set the previous score to this frame's score.
		previousScore = subscore;
	}

}