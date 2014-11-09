using UnityEngine;
using System.Collections;

public class PlayerState : MonoBehaviour {

	public int Health = 3;

	public enum PlayerSwordStates
	{
		NONE = 0,
		ATTACK,
		BLOCK
	}
	public PlayerSwordStates swordState = PlayerSwordStates.ATTACK;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(swordState);
	}

	public void TakeDamage(int damage)
	{
		Health -= damage;
		if(Health <= 0)
		{
			Application.LoadLevel(0);
		}
		else
		{
			rigidbody.AddForce(transform.forward * 100f);
		}
	}

}
