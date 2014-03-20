using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour 
{

	public float speed;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		rigidbody.velocity = transform.forward * speed;
	}
}
