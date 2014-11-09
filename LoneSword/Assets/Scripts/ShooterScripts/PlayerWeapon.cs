using UnityEngine;
using System.Collections;


using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class PlayerWeapon : MonoBehaviour {
	
	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;

	public GameObject bulletPrefab;
	
	public Transform myCharacter;
	public CharacterController controller;

	public Transform myArm;
	
	// The pose from the last update. This is used to determine if the pose has changed
	// so that actions are only performed upon making them rather than every frame during
	// which they are active.
	private Pose _lastPose = Pose.Unknown;
	
	void Start()
	{
		myo = GameObject.Find ("Myo");
		myCharacter = GameObject.Find ("OVRPlayerController").transform;
		controller = myCharacter.GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();
		
		
		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a wave out is made.
			if (thalmicMyo.pose == Pose.Fist || thalmicMyo.pose == Pose.WaveOut  || thalmicMyo.pose == Pose.WaveIn) {
				thalmicMyo.Vibrate (VibrationType.Short);
				GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
				newBullet.rigidbody.AddForce(transform.forward * 500f);
			}
		}

		if(Input.GetKeyDown(KeyCode.Tab))
		{
			GameObject newBullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as GameObject;
			newBullet.rigidbody.AddForce(transform.forward * 500f);
		}
	}
	
}
















