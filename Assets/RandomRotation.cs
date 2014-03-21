using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {

	public float tumbleSpeed;

	// Use this for initialization
	void Start () 
	{
		rigidbody.angularVelocity = Random.insideUnitSphere * tumbleSpeed;
	}

}
