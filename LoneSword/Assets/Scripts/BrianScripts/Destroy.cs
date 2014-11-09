using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float time = 4.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, time + GetComponent<ProjectileSounds>().end.length);
		GetComponent<ProjectileSounds>().PlaySound(GetComponent<ProjectileSounds>().begin);
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision c) {
		Destroy (gameObject, GetComponent<ProjectileSounds>().end.length);
		GetComponent<ProjectileSounds>().PlaySound(GetComponent<ProjectileSounds>().end);
	}
}
