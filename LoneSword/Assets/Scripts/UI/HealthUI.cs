using UnityEngine;
using System.Collections;

public class HealthUI : MonoBehaviour {

	public Health health;
	public TextMesh textMesh;

	// Use this for initialization
	void Start () {
		health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = "Health: " + health.HP;
	}
}
