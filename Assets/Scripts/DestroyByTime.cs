using UnityEngine;
using System.Collections;

public class DestroyByTime : MonoBehaviour 
{
	public float lifeTime; 	//how long the object will last

	void Start () 
	{
		Destroy(gameObject, lifeTime);
	}
}