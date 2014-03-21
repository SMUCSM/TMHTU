using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour 
{
	public GameObject asteroid;
	public Vector3 spawnValues;

	public int asteroidCount;
	public float spawnWaitTime;
	public float startWaitTime;
	public float waveWaitTime;

	public GUIText scoreText;
	public GUIText restartText;
	public GUIText gameOverText;

	private int score;
	private bool gameOver;
	private bool restart;

	// Use this for initialization
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

	IEnumerator SpawnWaves()
	{
		yield return new WaitForSeconds(startWaitTime);

		while(true)
		{
			for (int i=0; i<asteroidCount; i++)
			{
				Vector3 spawnPosition = new Vector3(Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate(asteroid, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWaitTime);
			}
			if (gameOver)
			{
				restartText.text = "Press R to restart";
				restart = true;
				break;
			}

			yield return new WaitForSeconds(waveWaitTime);


		}


	}

	public void AddScore (int scoreAmount)
	{
		score += scoreAmount;
		UpdateScore();
	}

	public void GameOver()
	{
		gameOverText.text = "Game Over!";
		gameOver = true;
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}


	// Update is called once per frame
	void Update () 
	{
		if (restart)
		{
			if (Input.GetKeyDown(KeyCode.R))
			{
				Application.LoadLevel(Application.loadedLevel);
			}
		}
	}
}
