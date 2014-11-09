using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Spawner : MonoBehaviour {

	public GameObject enemyPrefab;

	public int spawnCounter = 0;

	public LinkedList<GameObject>  nodes = new LinkedList<GameObject>();

	private LinkedList<GameObject> activeNodes = new LinkedList<GameObject>();



	public void Start()
	{
		foreach (Transform child in transform)
		{
			if (child.name != "Trigger")
			nodes.AddLast(child.gameObject);
		}

		foreach (GameObject g in nodes)
		{
			activeNodes.AddLast(g);
		}
	}

	public void TriggerActivated()
	{

		LinkedList<GameObject> tempNodes = new LinkedList<GameObject> ();
		//int randomSpawnCount = Random.Range (4, nodes.Count);
		spawnCounter++;
		if (spawnCounter >= nodes.Count)
		{
			spawnCounter = nodes.Count;
		}

		for (int i=0; i<spawnCounter; i++) {
			GameObject clone = Instantiate (enemyPrefab, transform.position, Quaternion.identity) as GameObject;
			clone.transform.GetComponent<EnemyShoot>().destination = activeNodes.First.Value.transform.position;
			tempNodes.AddLast(activeNodes.First);
			activeNodes.RemoveFirst();
			SingletonObject.Get.getGameState().CurEnemies++;
		}

		while (tempNodes.Count > 0)
		{
			activeNodes.AddLast(tempNodes.First);
			tempNodes.RemoveFirst();
		}

	}
}


















