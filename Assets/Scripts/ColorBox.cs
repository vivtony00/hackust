using UnityEngine;
using System.Collections;

public class ColorBox : MonoBehaviour
{
	public int ID = 0;
	public Renderer rend;
	private Score score;
	private SubScore subscore;
	static public Color color;


	void Awake ()
	{
		// Setting up the reference.\
		score = GameObject.Find("Score").GetComponent<Score>();
		subscore = GameObject.Find ("SubScore").GetComponent<SubScore>();
		rend = GetComponent<Renderer>();
		ID = 0;
		color = Color.white;

	}

//	void changeColor(Color newcolor){
//		Debug.Log (newcolor);
//		color = newcolor;
//	}
//	void OnGUI(){
//		GUI.Box (new Rect (10, 10, 100, 90), "Color Menu");
//
//		if (GUI.Button (new Rect (20, 40, 80, 20), "Blue")) {			
//			changeColor (Color.blue);
//		}
//		else if (GUI.Button (new Rect (20, 70, 80, 20), "Red")) {
//			changeColor (Color.red);
//		}
//	}
//
	void Update ()
	{
		// Set the position to the player's position  with the offset.


	}
//	void OnCollisionEnter2D(Collision2D col){
//		if (col.gameObject.tag == "Player") {
//			Debug.Log (color);
//			rend.material.color = color;
//			if (ID == 0) {
//				score.score += 1;
//			}
//			ID = 1;
//			return;
//		}
//
//		if (ID == 1) {
//			score.score -= 1;
//		}
//		ID = 0;
//		if (color == Color.blue) {
//			rend.material.color = Color.red;
//		} else {
//			rend.material.color = Color.blue;
//		}
//
//	}
	void OnCollisionEnter2D(Collision2D col){


		if (col.gameObject.name == "hero") {
			rend.material.color = Color.blue;
			if (ID == 0 || ID == 2) {
				if (ID == 2) {
					subscore.subscore -= 1;
				}
				score.score += 1;
				ID = 1;
				return;
			} 
		} else if (col.gameObject.name == "hero (1)") {
			rend.material.color = Color.red;
			if (ID == 0 || ID == 1) {
				if (ID == 1) {
					score.score -= 1;
				}
				subscore.subscore += 1;
				ID = 2;
				return;
			} 
		}



//		if (col.gameObject.name == "hero") {
//			rend.material.color = Color.blue;
//			if (ID == 0) {
//				score.score += 1;
//			}
//			ID = 1;
//			return;
//		}
//
//		if (ID == 1) {
//			score.score -= 1;
//			subscore.subscore += 1;
//		}
//		ID = 0;
//		if (col.gameObject.name == "hero (1)") {
//			rend.material.color = Color.yellow;
//			return;
//		}

	}


}
