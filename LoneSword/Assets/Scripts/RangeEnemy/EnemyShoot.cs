using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour {

	public enum State {
		Move,
		Shoot,
		Shooting,
		Die
	}

	NavMeshAgent agent;
	public Vector3 destination;
	public State state = State.Move;
	GameObject player;

	public GameObject bulletPrefab;
	Animation anim;

	// Use this for initialization
	void Start () {
		agent = transform.GetComponent<NavMeshAgent> ();
		player = GameObject.Find ("OVRPlayerController");
		anim = transform.GetComponent<Animation> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(anim.IsPlaying("die")) {
			state = State.Die;
			return;
		}
		if (state == State.Move)
		{
			if (Vector3.SqrMagnitude(destination - transform.position) <= 1)
			{
				state = State.Shoot;
				transform.rotation = Quaternion.LookRotation(Vector3.Normalize(new Vector3(player.transform.position.x - transform.position.x,
				                                                                           transform.position.y, player.transform.position.z - transform.position.z)));
			}
			agent.SetDestination(destination);
		}
		else if (state == State.Shoot)
		{
			state = State.Shooting;
			SingletonObject.Get.getTimer().Add(gameObject.GetInstanceID() + "shoot", Shoot, Random.Range (3f, 5f), true);
		}
	}

	void Shoot()
	{
		if (!anim)
						return;
		anim.Play ("attack");
		GameObject clone = Instantiate (bulletPrefab, transform.position + transform.forward * 2 + Vector3.up * 1.1f, Quaternion.identity) as GameObject;
		clone.transform.rotation = Quaternion.LookRotation (player.transform.position - transform.position);
		clone.GetComponent<FireBallTracker> ().player = player.transform;
		clone.rigidbody.AddForce (transform.forward * Random.Range (0.0f, 3.0f));

		MageSounds sounds = GetComponent<MageSounds>();
		sounds.PlaySound(sounds.fireballLaunch);
		
	}
}

			                                 












