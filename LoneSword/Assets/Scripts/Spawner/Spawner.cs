using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public int waves = 4;

	public LinkedList<GameObject>  nodes = new LinkedList<GameObject>();

	private LinkedList<GameObject> activeNodes = new LinkedList<GameObject>();

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

		//int randomSpawnCount = Random.Range (4, nodes.Count);
		int randomSpawnCount = 1;

		for (int i=0; i<randomSpawnCount; i++) {
			GameObject clone = Instantiate (enemyPrefab, transform.position, Quaternion.identity) as GameObject;
			clone.transform.GetComponent<EnemyShoot>().destination = activeNodes.First.Value.transform.position;
			activeNodes.RemoveFirst();
			SingletonObject.Get.getGameState().CurEnemies++;
		}

	}
}


















