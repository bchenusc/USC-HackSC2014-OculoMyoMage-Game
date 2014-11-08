using UnityEngine;
using System.Collections;


using Pose = Thalmic.Myo.Pose;
using VibrationType = Thalmic.Myo.VibrationType;

public class Shoot : MonoBehaviour {

	// Myo game object to connect with.
	// This object must have a ThalmicMyo script attached.
	public GameObject myo = null;
	public Transform bulletPrefab;
	public Transform stringPrefab;

	public Transform lastShotString;
	public Transform lastShotSphere;

	public Transform myCharacter;
	public CharacterController controller;

	Vector3 velocity = Vector3.zero;

	public bool flyNow = false;
	public bool newVel = false;

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
	void Update () {
		// Access the ThalmicMyo component attached to the Myo game object.
		ThalmicMyo thalmicMyo = myo.GetComponent<ThalmicMyo> ();


		if (thalmicMyo.pose != _lastPose) {
			_lastPose = thalmicMyo.pose;
			
			// Vibrate the Myo armband when a wave out is made.
			if (thalmicMyo.pose == Pose.Fist) {
				thalmicMyo.Vibrate (VibrationType.Short);
				if (lastShotSphere != null)
					Destroy(lastShotSphere.gameObject);
				if (lastShotString != null)
					Destroy(lastShotString.gameObject);
				flyNow = false;
				lastShotSphere = Instantiate(bulletPrefab, transform.position, Quaternion.identity) as Transform;
				lastShotString= Instantiate(stringPrefab, transform.position, transform.parent.parent.rotation) as Transform;
				Pull pullScript = lastShotString.GetComponent<Pull>();
				lastShotSphere.GetComponent<FlyMove>().myCharacter = transform;
				pullScript.start = transform;
				pullScript.end = lastShotSphere;
				lastShotSphere.rigidbody.AddForce(transform.forward * 2000);
			}
		}

		if (flyNow)
		{
			if (newVel && lastShotSphere != null) {
				newVel = false;
				Debug.Log ("FLY!");
				Vector3 direction = lastShotSphere.position - transform.position;
				if (Vector3.SqrMagnitude(direction) < 4) {
					Debug.Log ("Stop " + lastShotSphere.position);

					DestroyPrevString();
				}
				direction = Vector3.Normalize(direction);
				velocity = new Vector3(direction.x, direction.y , direction.z) * .5f;
			}
			controller.Move (velocity);
		}	
	}

	void DestroyPrevString()
	{
		Debug.Log ("Hit");
		myCharacter.rigidbody.velocity = Vector3.zero;
		if (lastShotSphere != null)
			Destroy(lastShotSphere.gameObject);
		if (lastShotString != null)
			Destroy(lastShotString.gameObject);
		flyNow = false;
	}

}
















