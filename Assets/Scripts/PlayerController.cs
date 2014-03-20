using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
	public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour 
{
	public float speed;
	public float tilt;
	public Boundary bounds;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate()
	{
		//Get user input
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		//Apply input to ship
		Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical);
		rigidbody.velocity = movement * speed;

		//Lock the ship
		rigidbody.position = new Vector3
			(
				Mathf.Clamp(rigidbody.position.x, bounds.xMin, bounds.xMax),
				0f,
				Mathf.Clamp(rigidbody.position.z, bounds.zMin, bounds.zMax)
			);

		//Tilt
		rigidbody.rotation = Quaternion.Euler(0f, 0f, rigidbody.velocity.x * -tilt);
	}
}
