using UnityEngine;
using System.Collections;

using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class SwordController : MonoBehaviour {

	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;
	private Pose _lastPose = Pose.Unknown;

	public GameObject player = null;
	public PlayerState playerState = null;

	void Awake()
	{
		myo = GameObject.Find ("Myo");
		player = GameObject.FindGameObjectWithTag("Player");
		playerState = Component.FindObjectOfType<PlayerState>();
	}
	
	// Update is called once per frame
	void Update () {
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a wave out is made.
			if (thalmicMyo.pose == Pose.FingersSpread) {
				thalmicMyo.Vibrate (VibrationType.Short);
				playerState.swordState = PlayerState.PlayerSwordStates.BLOCK;
			} else if(thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Short);
				playerState.swordState = PlayerState.PlayerSwordStates.ATTACK;
			}
		}
	}

	void OnTriggerEnter(Collider collision) {
		if(collision.gameObject.CompareTag("EnemySword"))
		{
			if(Quaternion.Angle(player.transform.rotation, collision.transform.rotation) > 30f)
			{
				Debug.Log(Quaternion.Angle(player.transform.rotation, collision.transform.rotation));
				player.rigidbody.AddForce(player.transform.forward * 50f);
			}
		}
		else if (collision.gameObject.CompareTag("Enemy"))
		{
			if(collision.GetComponent<EnemyMovement>())
			{
				collision.GetComponent<EnemyMovement>().TakeDamage(1);
			}
		}
	}

}
