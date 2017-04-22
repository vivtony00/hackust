using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
	public float time ;					// The player's score.
	private float NowTime;
	private Score score;
	private SubScore subscore;
	public PlayerControl pc;
	public PlayerControl2 pc2;


	void Awake ()
	{
		score = GameObject.Find("Score").GetComponent<Score>();
		subscore = GameObject.Find ("SubScore").GetComponent<SubScore>();
		// Setting up the reference.
		NowTime = Time.time;
		pc = GetComponent<PlayerControl>();
		pc2 = GetComponent<PlayerControl2> ();
	}


	void Update ()
	{
		time =20.0f - (Time.time - NowTime);
		// Set the score text.
		if (time > 0) {
			GetComponent<GUIText> ().text = "Time: " + (int)time;
		} else {

			if (score.score > subscore.subscore) {
				GetComponent<GUIText> ().text = "Blue Win!";
			} else if (score.score < subscore.subscore) {
				GetComponent<GUIText> ().text = "Red Win!";
			} else {
				GetComponent<GUIText> ().text = "Tie!";
			}

		}
		if (time < -2) {
			UnityEngine.SceneManagement.SceneManager.LoadScene (2);
		}

	}

}