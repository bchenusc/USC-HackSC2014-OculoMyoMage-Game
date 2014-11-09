using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	public float time = 4.0f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, 4.0f);
	}
	
	// Update is called once per frame
	void OnCollisionEnter (Collision c) {
		Destroy (gameObject);
	}
}
