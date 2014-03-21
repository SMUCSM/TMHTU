using UnityEngine;
using System.Collections;

public class DestroyByBoundary : MonoBehaviour 
{
	//When a trigger leaves this trigger, destroy the other gameObject
	void OnTriggerExit(Collider other)
	{
		Destroy(other.gameObject);
	}
}