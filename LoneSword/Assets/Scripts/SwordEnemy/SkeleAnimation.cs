using UnityEngine;
using System.Collections;

public class SkeleAnimation : MonoBehaviour {

	bool nearby;
	Transform player;

	NavMeshAgent agent;

	void Start()
	{
		player = GameObject.Find ("OVRPlayerController").transform;
		agent = transform.GetComponent<NavMeshAgent> ();
	}

	// Update is called once per frame
	void Update () {
		Vector3 direction = player.position - transform.position;
		transform.rotation = Quaternion.LookRotation(Vector3.Normalize(new Vector3(player.position.x - transform.position.x,
		                                                         transform.position.y, player.position.z - transform.position.z)));
		if (Vector3.SqrMagnitude(direction) < 4)
		{
			agent.Stop();
			Animation anim = transform.GetComponent<Animation>();
			if (!anim.IsPlaying("attack")){
				anim.Play("attack");
			}
		} else {

			agent.SetDestination(player.position);
			transform.GetComponent<Animation>().Play ("run");
		}
	}
}
