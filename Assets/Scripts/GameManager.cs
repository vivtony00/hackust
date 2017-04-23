using UnityEngine;
using System.Collections;

using System.Collections.Generic;       //Allows us to use Lists. 

public class GameManager : MonoBehaviour
{

	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	// private BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.

	// user data
	public int allCoin = 1000;

	// gameplay data
	public int curStage = 0; //get by GameManager.getInstance().curStage
	public int gameCoin = 0;
	public bool gameStarted;
	//public bool stageHlth = true;

	public int p2GameCoin = 0;
	//public bool p2StageHlth = true;

	//Awake is always called before any Start functions
	void Awake()
	{
		//Check if instance already exists
		if (instance == null)
			instance = this; //if not, set instance to this
		else if (instance != this) //If instance already exists and it's not this:
			Destroy(gameObject);    //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.

		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad(gameObject);

		//Get a component reference to the attached BoardManager script
		//boardScript = GetComponent<BoardManager>();

		//Call the InitGame function to initialize the first level 
		InitGame();
	}

	//Initializes the game for each level.
	void InitGame()
	{
		//Call the SetupScene function of the BoardManager script, pass it current level number.
		// boardScript.SetupScene(level);

	}

	public static GameManager getInstance(){
		return instance;
	}

	// called when start of game. initialize all variables
	public void StartNewGame(){
		gameStarted = true;

		// gameplay data
		curStage = 1;
		gameCoin = 0;

		p2GameCoin = 0;
	}

	// called when end of game (before scene transition)
	public void EndGame(){
		gameStarted = false;
		allCoin += gameCoin;
	}

	// called when end of stage. use the return val to determine if game is ended
	public void StageEnd(bool win){
		if (win) {
			gameCoin += 100;
		} else {
			p2GameCoin += 100;
		}
		curStage += 1;
		//return curStage;
	}



	//Update is called every frame.
	void Update()
	{
	}
}