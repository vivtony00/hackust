using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class DemoScene : MonoBehaviour {
	public int curSceneImage;
	public GameObject titleImage;//1
	public GameObject startImage;//2
	public GameObject readyImage;//3
	public GameObject endImage;//4
	public GameObject prizeImage;//5
	int count=0;

	public int nextScene;
	// Use this for initialization
	void Start () {
		switch (curSceneImage) { 
			case 0: 
				titleImage.SetActive (true);
				break;
			case 1: 
				startImage.SetActive(true);
				titleImage.SetActive(false);
				break; 
			case 2: 
				readyImage.SetActive(true);
				startImage.SetActive(false);
				break; 
		case 3:
			count++;
			if (count == 3) {
				UnityEngine.SceneManagement.SceneManager.LoadScene (1);
				startImage.SetActive (false);
			}
			break;
			case 4: 
				endImage.SetActive(true);
				break; 
			case 5: 
				prizeImage.SetActive(true); 
				endImage.SetActive(false);
				break; 
			default: 
				curSceneImage = 1;
				break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.anyKey) {
			switch (curSceneImage) { 
			case 0: 
				titleImage.SetActive (true);
				break;
			case 1: 
				
				titleImage.SetActive(false);startImage.SetActive(true);
				break; 
			case 2: 
				count++;
				if (count == 3) {
					
					startImage.SetActive (false);readyImage.SetActive (true);
				}
				break; 
			case 3:
				count++;
				if (count == 6) {
					UnityEngine.SceneManagement.SceneManager.LoadScene (1);
					startImage.SetActive (false);
				}
				break; 
			case 4: 
				endImage.SetActive(true);
				break; 
			case 5: 
				prizeImage.SetActive(true); 
				endImage.SetActive(false);
				break; 
			default: 
				curSceneImage = 1;
				break;
			}
			++curSceneImage;
		}
	}
}