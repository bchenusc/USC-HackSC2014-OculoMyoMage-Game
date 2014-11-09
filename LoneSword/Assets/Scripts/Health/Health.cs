using UnityEngine;
using System.Collections;

public class Health : MonoBehaviour {

	public int HP = 10;

	void TakeDamage()
	{
		HP -= 1;
		if (HP == 0)
		{
			Application.LoadLevel(0);
		}
	}
}
