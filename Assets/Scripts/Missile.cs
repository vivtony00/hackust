using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Missile : MonoBehaviour
{
	public GameManager myGameManager;

	public float time ;					// The player's score.
	private float NowTime;

	public List <Transform> Enemies;
	public Transform SelectedTarget;
	public GameObject explosion;

	void Start () 
	{
		SelectedTarget = null;
		Enemies = new List<Transform>();
		AddEnemiesToList();
		myGameManager = GameManager.getInstance();
	}

	public void AddEnemiesToList()
	{
		GameObject[] ItemsInList = GameObject.FindGameObjectsWithTag("Player");
		foreach(GameObject _Enemy in ItemsInList)
		{
			AddTarget(_Enemy.transform);
		}
	}

	public void AddTarget(Transform enemy)
	{
		Enemies.Add(enemy);
	}

	public void DistanceToTarget()
	{
		Enemies.Sort(delegate( Transform t1, Transform t2){ 
			return Vector3.Distance(t1.transform.position,transform.position).CompareTo(Vector3.Distance(t2.transform.position,transform.position)); 
		});

	}

	public void TargetedEnemy() 
	{
		if(SelectedTarget == null)
		{
			DistanceToTarget();
			SelectedTarget = Enemies[0];
		}


	}

	void Update () 
	{
		TargetedEnemy();
		float dist = Vector3.Distance(SelectedTarget.transform.position,transform.position);
		//if(dist <150)
		//{
		transform.position = Vector3.MoveTowards(transform.position, SelectedTarget.position, 3 * Time.deltaTime);
		//}
		Vector3 vectorToTarget = SelectedTarget.position - transform.position;
		float angle = Mathf.Atan2(vectorToTarget.y, vectorToTarget.x) * Mathf.Rad2Deg;
		Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
		transform.rotation = Quaternion.Slerp(transform.rotation, q, Time.deltaTime * 90);

		time =20.0f - (Time.time - NowTime);
		if (time < -2) {

			UnityEngine.SceneManagement.SceneManager.LoadScene (2);
			Destroy (gameObject);
			/*if (health > 0)
				myGameManager.StageEnd(true);
			else
				myGameManager.StageEnd(false);*/
		}
	}
	void OnExplode()
	{
		// Create a quaternion with a random rotation in the z-axis.
		Quaternion randomRotation = Quaternion.Euler(0f, 0f, Random.Range(0f, 360f));

		// Instantiate the explosion where the rocket is with the random rotation.
		Instantiate(explosion, transform.position, randomRotation);
	}
	void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == "Player") {
			// ... find the Enemy script and call the Hurt function.
			col.gameObject.GetComponent<PlayerHealth> ().Dealth ();

			// Call the explosion instantiation.
			OnExplode ();

			// Destroy the rocket.
			//Destroy (gameObject);
		}
	}
}

