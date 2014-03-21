using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{
	public float speed;	//The speed of movement
	
	// Update is called once per frame
	void Update () 
	{
		//update the velocity based on speed
		rigidbody.velocity = transform.forward * speed;
	}
}