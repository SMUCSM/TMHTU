using UnityEngine;
using System.Collections;

public class DestroyByContact : MonoBehaviour 
{
	public GameObject explosion;		//reference to explosion prefab
	public GameObject playerExplosion;	//reference to explosion prefab
	public int scoreValue;				//the score amount to increase by when collides with bullet

	private GameController gameController;	//reference to the GameController object

	void Start()
	{
		//Find a GameController script in the scene
		GameObject gameControllerObject = GameObject.FindWithTag("GameController");

		//if not null save the reference
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent<GameController>();
		}
		//else log error
		else
		{
			Debug.Log ("Cannot find GameController script");
		}
	}

	//When a trigger enters this trigger
	void OnTriggerEnter(Collider other)
	{
		//If collision with boundary return as DestroyByBoundary will take care of it
		if (other.tag == "Boundary")
		{
			return;
		}

		//Instantiate the explosion
		Instantiate(explosion, transform.position, transform.rotation);

		//If collision with player, instantiate player explosion and set GameOver state
		if (other.tag == "Player")
		{
			Instantiate(playerExplosion, other.transform.position, other.transform.rotation);
			gameController.GameOver();
		}

		//If collision with a bullet add score
		if (other.tag == "Bullet")
		{
			gameController.AddScore(scoreValue);
		}

		//Destroy the other gameObject and this one
		Destroy(other.gameObject);
		Destroy(gameObject);
	}
}