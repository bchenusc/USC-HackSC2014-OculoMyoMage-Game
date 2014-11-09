using UnityEngine;
using System.Collections;

public class ShooterPlayerController : MonoBehaviour {

	public CharacterController controller;

	public float crouchDistance = 0.6f;
	public float crouchScale = 0.5f;

	public PlayerSounds soundManager;

	// Use this for initialization
	void Start () {
		controller = Component.FindObjectOfType<CharacterController>();
		soundManager = GetComponent<PlayerSounds>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			soundManager.PlaySound(soundManager.crouch);
			transform.position -= new Vector3(0f, crouchDistance);
		}
		else if(Input.GetKeyUp(KeyCode.LeftControl))
		{
			soundManager.PlaySound(soundManager.crouch);
			transform.position += new Vector3(0f, crouchDistance + .5f);
		}
		/*if(controller.velocity.magnitude > 0.1f)
		{
			soundManager.PlaySound(soundManager.footsteps);
		} else {
			soundManager.StopSound(soundManager.footsteps);
		}*/
	}
}
