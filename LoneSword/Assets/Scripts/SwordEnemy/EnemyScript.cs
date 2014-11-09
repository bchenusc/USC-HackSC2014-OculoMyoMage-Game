using UnityEngine;
using System.Collections;

public class EnemyScript : MonoBehaviour {

	public Transform player;
	public Transform playerSword;

	float atkTimer;
	float maxAtkTimer = 1.0f;

	public enum EnemyState{
		Move,
		Attack,
		Die
	}

	EnemyState state = EnemyState.Move;

	// Use this for initialization
	void Start () {
		// cache player
		// cache playerSword.
	}
	
	// Update is called once per frame
	void Update () {

	}
}
