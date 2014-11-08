using UnityEngine;
using System.Collections;

public class Pull : MonoBehaviour {


	public Transform start;
	public Transform end;

	private Vector3 startRotation;

	void Start()
	{
//		startRotation = transform.rotation;
	}
	
	// Update is called once per frame
	void Update () {
		// Scale based on start and end.
		if (end.rigidbody.isKinematic == false)
		{
			transform.up = end.position - start.position;
			transform.localScale = new Vector3( transform.localScale.x, Vector3.Distance (end.position,start.position) / 2 , transform.localScale.z);
		}
	
	}
}
