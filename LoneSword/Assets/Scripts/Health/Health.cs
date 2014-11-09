using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HP = 10;

	Animation anim;

	// this is the enemy.
	public bool damagedByBullets = true;

	void Start()
	{
		anim = transform.GetComponent<Animation> ();

	}

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
				anim.Play("die");
				Destroy (gameObject, anim.GetClip("die").length);
			} else {
				SingletonObject.Get.getTimer ().RemoveAll ();
				Application.LoadLevel(0);
			}
		}
	}
}
