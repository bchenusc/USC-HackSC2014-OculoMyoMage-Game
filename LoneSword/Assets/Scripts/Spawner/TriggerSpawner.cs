using UnityEngine;
using System.Collections;

public class TriggerSpawner : MonoBehaviour {

	public bool turnOn = true;

	void OnTriggerEnter(Collider other)
	{
		if (turnOn && other.CompareTag("Player"))
		{
			turnOn = false;
			GetComponentInParent<Spawner>().TriggerActivated();
		}
	}

	void OnTriggerStay(Collider other)
	{
		if (turnOn && other.CompareTag("Player"))
		{
			turnOn = false;
			GetComponentInParent<Spawner>().TriggerActivated();
		}
	}
}
