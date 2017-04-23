using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class carrybomb : MonoBehaviour {
	public bool carryingBomb;           // Indicate if the player is carryingBomb;
	public GameObject bomb;             // Prefab of the bomb.
	public GameObject bombCarrying;     // the game object "bomb" which Instantiated

	private float explodetime;
	private float lasttime;
	public float deltaTime;

	// Use this for initialization
	void Start () {
		if (carryingBomb)
		{
			bombCarrying = Instantiate(bomb, transform.position, transform.rotation);
		}
		else
		{
			bombCarrying = Instantiate(bomb, transform.position, transform.rotation);
			bombCarrying.SetActive(false);
		}
		lasttime = Time.time;
		explodetime = Time.time + 20.0f;
	}

	// Update is called once per frame
	void Update() {
		if (carryingBomb)
		{
			bombCarrying.transform.position = transform.position;
			if (Time.time > explodetime)
			{
				bombCarrying.GetComponent<BombForCarry>().Explode();
				UnityEngine.SceneManagement.SceneManager.LoadScene (4);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col)
	{
		if (Time.time - lasttime > deltaTime)
		{
			if (col.gameObject.tag == "Player" && col.gameObject.GetComponent<carrybomb>().carryingBomb)
			{
				swich();
				col.gameObject.GetComponent<carrybomb>().swich();
			} else if (col.gameObject.tag == "Player" && carryingBomb) {
				col.gameObject.GetComponent<carrybomb>().swich();
				swich();
			}
			lasttime = Time.time;
		}
	}
	public void swich()
	{
			if (carryingBomb == true)
			{
				bombCarrying.SetActive(false);
				carryingBomb = false;
			}
			else
			{
				bombCarrying.SetActive(true);
				carryingBomb = true;
			}

	}
}
