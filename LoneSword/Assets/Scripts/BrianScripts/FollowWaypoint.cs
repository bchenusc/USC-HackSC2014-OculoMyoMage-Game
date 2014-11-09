using UnityEngine;
using System.Collections;

public class FollowWaypoint : MonoBehaviour {

	NavMeshAgent agent;

	Transform nextWayPoint;
	bool Moving = false;

	void Start()
	{
		agent = transform.GetComponent<NavMeshAgent> ();
		MoveToNextWaypoint ();
	}

	public void MoveToNextWaypoint(){
		Moving = true;
		agent.enabled = true;
		nextWayPoint = SingletonObject.Get.getGameState ().NextWaypoint ();
		agent.SetDestination (nextWayPoint.position);
	}

	void Update()
	{
		if (Moving)
		{
			if (Vector3.Distance(nextWayPoint.position, transform.position) < .1f)
			{
				Debug.Log ("hello");
				Moving = false;
				agent.Stop();
				agent.enabled = false;
			}
		}
	}


}
