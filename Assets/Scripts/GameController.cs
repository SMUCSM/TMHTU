using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject asteroid;		//asteroid prefab reference
	public Vector3 spawnValues; 	//location of where to spawn the asteroid

	public int asteroidCount;		//the amount of asteroids per each wave
	public float spawnWaitTime;		//the time between asteroids spawning
	public float startWaitTime; 	//the time the player has to get ready
	public float waveWaitTime; 		//the time between waves

	public GUIText scoreText;		//reference to the GUI score
	public GUIText restartText;		//reference to the GUI restart
	public GUIText gameOverText; 	//reference to the GUI gameOver

	private int score;				//the current score
	private bool gameOver; 			//is the game over?
	private bool restart;			//can we restart yet?
	
	void Start () 
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		UpdateScore();
		StartCoroutine(SpawnWaves());
	}

	//Coroutine that spawns waves infinitely
	IEnumerator SpawnWaves()
	{
		//give the start wait time
		yield return new WaitForSeconds(startWaitTime);

		//infinte loop
		while(true)
		{
			//spawn a wave
			for (int i=0; i<asteroidCount; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWaitTime);
			}

			//test for gameover
			if (gameOver)
			{
				restartText.text = "Press R to restart";
				restart = true;
				break;
			}

			//wait for next wave
			yield return new WaitForSeconds(waveWaitTime);
		}
	}

	//public method to allow the DestroyByContact to add score
	public void AddScore (int scoreAmount)
	{
		score += scoreAmount;
		UpdateScore();
	}

	//public method to set game over state
	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	//update the GUI
	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}

	// Update is called once per frame
	void Update () 
	{
		//if we can restart, show the player and wait for input
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				//reload the current level
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}