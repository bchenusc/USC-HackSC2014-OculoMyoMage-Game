using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class SwordController : MonoBehaviour {

	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;

	public GameObject player = null;
	
	void Awake()
	{
		myo = GameObject.Find ("Myo");
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.CompareTag("EnemySword"))
		{
			Debug.Log(Quaternion.Angle(player.transform.rotation, collision.transform.rotation));
			player.rigidbody.AddForce(player.transform.forward * 50f);
		}
	}
}
