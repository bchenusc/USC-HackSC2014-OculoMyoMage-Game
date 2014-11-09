using UnityEngine;
using System.Collections;

public class SkeleSpawner : MonoBehaviour {

	public Transform prefab;
	Transform player;

	void Start()
	{
		player = GameObject.Find ("OVRPlayerController").transform;
		SingletonObject.Get.getTimer ().Add (gameObject.GetInstanceID () + "spawn", Spawn, Random.Range (5.0f, 10.0f), true);
	}

	void Spawn()
	{
		Instantiate (prefab, transform.position, Quaternion.identity);
	}
}
