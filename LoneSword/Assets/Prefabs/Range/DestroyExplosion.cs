using UnityEngine;
using System.Collections;

public class DestroyExplosion : MonoBehaviour {

	public float time = 0.4f;

	// Use this for initialization
	void Start () {
		Destroy (gameObject, time);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
