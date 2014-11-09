using UnityEngine;
using System.Collections;

public class FireBallTracker : MonoBehaviour {
	
	public Transform player;

	// Update is called once per frame
	void Update () {
		rigidbody.AddForce (Vector3.Normalize (player.position - transform.position) * 2);
	}
}
