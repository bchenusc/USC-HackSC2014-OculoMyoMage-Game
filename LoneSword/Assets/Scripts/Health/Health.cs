﻿using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HP = 10;

	// this is the enemy.
	public bool damagedByBullets = true;

	void OnCollisionEnter(Collision c)
	{
		if (damagedByBullets && c.transform.CompareTag("Projectile"))
		{
			Destroy(c.gameObject);
			TakeDamage();
		}
	}

	public void TakeDamage()
	{
		HP -= 1;
		if (HP == 0)
		{
			if (damagedByBullets)
			{
				Destroy (gameObject);
			} else {
				SingletonObject.Get.getTimer ().RemoveAll ();
				Application.LoadLevel(0);
			}
		}
	}
}
