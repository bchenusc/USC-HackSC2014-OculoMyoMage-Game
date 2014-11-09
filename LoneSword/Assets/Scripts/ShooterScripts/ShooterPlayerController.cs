using UnityEngine;
using System.Collections;

public class ShooterPlayerController : MonoBehaviour {

	public CharacterController controller;

	public float crouchDistance = 1f;

	// Use this for initialization
	void Start () {
		controller = Component.FindObjectOfType<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.LeftControl))
		{
			transform.position -= new Vector3(0f, crouchDistance);
		}
		else if(Input.GetKeyUp(KeyCode.LeftControl))
		{
			transform.position += new Vector3(0f, crouchDistance + .5f);
		}
	}
}
