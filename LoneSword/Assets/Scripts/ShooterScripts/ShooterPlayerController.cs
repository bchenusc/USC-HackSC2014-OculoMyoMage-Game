using UnityEngine;
using System.Collections;

public class ShooterPlayerController : MonoBehaviour {

	public CharacterController controller;

	public float crouchDistance = 0.3f;
	public float crouchScale = 0.5f;

	public PlayerSounds soundManager;

	public Transform gun;

	bool canCrouch = true;
	bool crouched = false;

	// Use this for initialization
	void Start () {
		controller = Component.FindObjectOfType<CharacterController>();
		soundManager = GetComponent<PlayerSounds>();
		gun = GameObject.Find ("MyoSword").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftControl) && canCrouch)
		{
			soundManager.PlaySound(soundManager.crouch);
			transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
			crouched = true;
			//gun.localPosition += new Vector3(0f, crouchDistance * .5f);
		}
		else if(Input.GetKeyUp(KeyCode.LeftControl) && canCrouch && crouched)
		{
			crouched  = false;
			soundManager.PlaySound(soundManager.crouch);
			transform.position += new Vector3(0f, crouchDistance + 2.0f);
			canCrouch = false;
			SingletonObject.Get.getTimer().Add("EnableCrouch", enableCrouch, 0.10f, false);
			//gun.localPosition -= new Vector3(0f, crouchDistance * .5f);
		}
		/*if(controller.velocity.magnitude > 0.1f)
		{
			soundManager.PlaySound(soundManager.footsteps);
		} else {
			soundManager.StopSound(soundManager.footsteps);
		}*/
	}

	void enableCrouch() {
		canCrouch = true;
	}
}
