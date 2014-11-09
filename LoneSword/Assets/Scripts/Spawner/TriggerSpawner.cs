using UnityEngine;
using System.Collections;

public class TriggerSpawner : MonoBehaviour {

	bool turnOn = true;

	void OnTriggerEnter(Collider other)
	{
		if (turnOn && other.CompareTag("Player"))
		{
			turnOn = false;
			GetComponentInParent<Spawner>().TriggerActivated();
		}
	}
}
