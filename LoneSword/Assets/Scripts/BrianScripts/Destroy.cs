using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {
	public Transform explosionPrefab;
	public float time = 4.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, time + GetComponent<ProjectileSounds>().end.length);
		GetComponent<ProjectileSounds>().PlaySound(GetComponent<ProjectileSounds>().begin);
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision c) {
		// Immediatedly destroy the collider and rigidbody
		Destroy (rigidbody);
		Destroy (collider);
		if (transform.name.Contains("Bullet"))
						Destroy (transform.GetChild(0).gameObject);
		if (transform.name.Contains("FireBall"))
			Destroy (transform.GetChild(0).gameObject);
		GameObject clone = Instantiate (explosionPrefab, transform.position, Quaternion.identity) as GameObject;
		Destroy (gameObject, GetComponent<ProjectileSounds>().end.length);
		renderer.enabled = false;
		GetComponent<ProjectileSounds>().PlaySound(GetComponent<ProjectileSounds>().end);
	}
}
