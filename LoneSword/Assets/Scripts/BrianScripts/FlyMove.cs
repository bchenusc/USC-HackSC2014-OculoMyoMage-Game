using UnityEngine;
using System.Collections;

public class FlyMove : MonoBehaviour {

	public Transform myCharacter;

	bool flyNow = false;

	private CharacterController controller;

	void Start()
	{

	}

	void OnCollisionEnter(Collision other)
	{
		if (!other.transform.CompareTag("Player")){
			// Make urself kinematic.
			rigidbody.isKinematic = true;
			myCharacter.GetComponent<Shoot>().flyNow = true;
			myCharacter.GetComponent<Shoot>().newVel = true;
		}
	}

}
