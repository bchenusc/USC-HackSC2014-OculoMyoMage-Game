using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	GameObject player;
	bool canMove = true;

	// Use this for initialization
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		transform.LookAt(player.transform.position);
		float distanceToPlayer = Vector3.Distance(transform.position, player.transform.position);
		if(distanceToPlayer > 5f && canMove)
		{
			rigidbody.velocity = transform.forward.normalized * 3;
		}
		else if (distanceToPlayer < 4f)
		{
			rigidbody.velocity = Vector3.zero;
			canMove = false;
		}
	}
}
