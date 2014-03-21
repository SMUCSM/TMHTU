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
	private int score;

	// Use this for initialization
	void Start () 
	{
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
			yield return new WaitForSeconds(waveWaitTime);
		}


	}

	public void AddScore (int scoreAmount)
	{
		score += scoreAmount;
		UpdateScore();
	}

	void UpdateScore()
	{
		scoreText.text = "Score: " + score;
	}


	// Update is called once per frame
	void Update () {
	
	}
}
