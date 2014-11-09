using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	enum State {
		Move,
		Shoot,
		Shooting
	}

	NavMeshAgent agent;
	public Vector3 destination;
	State state = State.Move;
	GameObject player;

	public GameObject bulletPrefab;

	// Use this for initialization
	void Start () {
		agent = transform.GetComponent<NavMeshAgent> ();
		player = GameObject.Find ("OVRPlayerController");
	}
	
	// Update is called once per frame
	void Update () {
		if (state == State.Move)
		{
			if (Vector3.SqrMagnitude(destination - transform.position) <= 1)
			{
				state = State.Shoot;
			}
			agent.SetDestination(destination);
		}
		else if (state == State.Shoot)
		{
			state = State.Shooting;
			SingletonObject.Get.getTimer().Add(gameObject.GetInstanceID() + "shoot", Shoot, Random.Range (0.6f, 2.0f), true);
		}
	}

	void Shoot()
	{
		Debug.Log ("hi");

		GameObject clone = Instantiate (bulletPrefab, transform.position + Vector3.forward * 2 + Vector3.up * 5, Quaternion.identity) as GameObject;
		clone.transform.rotation = Quaternion.LookRotation (player.transform.position);
		clone.rigidbody.AddForce(Vector3.forward * 3f, ForceMode.Impulse);

	}
}

			                                 












