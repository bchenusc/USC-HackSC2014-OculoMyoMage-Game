using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public int waves = 4;

	public LinkedList<GameObject>  nodes = new LinkedList<GameObject>();

	private LinkedList<GameObject> activeNodes = new LinkedList<GameObject>();

	public int enemies;

	public void Start()
	{
		foreach (Transform child in transform)
		{
			if (child.name != "Trigger")
			nodes.AddLast(child.gameObject);
		}
	}

	public void TriggerActivated()
	{
		foreach (GameObject g in nodes)
		{
			activeNodes.AddLast(g);
		}

		int randomSpawnCount = Random.Range (4, nodes.Count);

		for (int i=0; i<randomSpawnCount; i++) {
			GameObject clone = Instantiate (enemyPrefab, transform.position, Quaternion.identity) as GameObject;
			clone.transform.GetComponent<EnemyShoot>().destination = activeNodes.First.Value.transform.position;
			activeNodes.RemoveFirst();
			enemies ++;
		}

	}

	void Update() {
		if(enemies <= 0) {
			Component.FindObjectOfType<TriggerSpawner>().turnOn = true;
		}
	}
}


















