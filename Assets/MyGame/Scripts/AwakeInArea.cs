using UnityEngine;
using System.Collections;

public class AwakeInArea : MonoBehaviour {
	
	public GameObject awakeRoot;

	void OnTriggerEnter(Collider other) 
	{
		if ( other.CompareTag("Car") == true ) {
			awakeRoot.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other) 
	{
		if ( other.CompareTag("Car") == true ) {
			awakeRoot.SetActive(false);
		}
	}
}
