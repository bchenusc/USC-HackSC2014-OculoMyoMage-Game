using UnityEngine;
using System.Collections;

public class ShooterPlayerController : MonoBehaviour {

	public CharacterController controller;

	public float crouchDistance = 1.6f;
	public float crouchScale = 0.5f;

	public PlayerSounds soundManager;

	public Transform gun;

	// Use this for initialization
	void Start () {
		controller = Component.FindObjectOfType<CharacterController>();
		soundManager = GetComponent<PlayerSounds>();
		gun = GameObject.Find ("MyoSword").transform;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			soundManager.PlaySound(soundManager.crouch);
			transform.position -= new Vector3(0f, crouchDistance);
			//gun.localPosition += new Vector3(0f, crouchDistance * .5f);
		}
		else if(Input.GetKeyUp(KeyCode.LeftControl))
		{
			soundManager.PlaySound(soundManager.crouch);
			transform.position += new Vector3(0f, crouchDistance + .3f);
			//gun.localPosition -= new Vector3(0f, crouchDistance * .5f);
		}
		/*if(controller.velocity.magnitude > 0.1f)
		{
			soundManager.PlaySound(soundManager.footsteps);
		} else {
			soundManager.StopSound(soundManager.footsteps);
		}*/
	}
}
