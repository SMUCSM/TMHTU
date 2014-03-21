using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour 
{
	public float tumbleSpeed;	//the speed to rotate
	
	void Start () 
	{
		//Set the angularVelocity to a random value inside a sphere
		rigidbody.angularVelocity = Random.insideUnitSphere * tumbleSpeed;
	}
}