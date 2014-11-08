using UnityEngine;
using System.Collections;

public class EnemySwordController : MonoBehaviour {

	SwordController playerSwordController = null;

	// Use this for initialization
	void Start () {
		SingletonObject.Get.getTimer().Add("PlayerSwordCheck" + gameObject.GetInstanceID(),
		                                   ReorientSword,
		                                   5f,
		                                   true);
		playerSwordController = Component.FindObjectOfType<SwordController>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ReorientSword() {
		Quaternion playerSwordRotationBlocked = Quaternion.AngleAxis(90, playerSwordController.transform.forward);
		transform.rotation = Quaternion.RotateTowards(transform.rotation, playerSwordRotationBlocked, 90f);
	}

	void OnDestroy() {
		SingletonObject.Get.getTimer().Remove("PlayerSwordCheck" + gameObject.GetInstanceID());
	}

	void OnTriggerEnter(Collider collision) {
		if (collision.gameObject.CompareTag("Player"))
		{
			if(collision.GetComponent<PlayerState>())
			{
				collision.GetComponent<PlayerState>().TakeDamage(1);
			}
		}
	}
}
