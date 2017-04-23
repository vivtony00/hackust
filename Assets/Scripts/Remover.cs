using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Remover : MonoBehaviour
{
	public GameObject splash;
	public int dealthCount = 0;
	public int nextScene;


	void OnTriggerEnter2D(Collider2D col)
	{
		// If the player hits the trigger...
		if(col.gameObject.tag == "Player")
		{
			// .. stop the camera tracking the player
		//	GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraFollow>().enabled = false;

			// .. stop the Health Bar following the player
		//	if(GameObject.FindGameObjectWithTag("HealthBar").activeSelf)
		//	{
		//		GameObject.FindGameObjectWithTag("HealthBar").SetActive(false);
		//	}

			// ... instantiate the splash where the player falls in.
			Instantiate(splash, col.transform.position, transform.rotation);
			// ... destroy the player.
			Destroy (col.gameObject);
			// ... reload the level.
			dealthCount++;
			if (dealthCount >= 2)
			{
				StartCoroutine("ReloadGame");
			}
		}
		else
		{
			// ... instantiate the splash where the enemy falls in.
			Instantiate(splash, col.transform.position, transform.rotation);

			// Destroy the enemy.
			Destroy (col.gameObject);	
		}
	}

	IEnumerator ReloadGame()
	{
		dealthCount = 0;
		// ... pause briefly
		yield return new WaitForSeconds(2);
		// ... and then reload the level.
		//SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex, LoadSceneMode.Single);
		UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
	}
}
