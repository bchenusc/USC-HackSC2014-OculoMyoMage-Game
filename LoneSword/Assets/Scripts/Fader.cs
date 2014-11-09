using UnityEngine;
using System.Collections;

public class Fader : MonoBehaviour {

	bool fading = false;
	float timeToFade = 0.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(fading) {
			timeToFade += Time.deltaTime;
			if(timeToFade >= 3f) {
				renderer.material.color = Color.black;
			} else {
				renderer.material.color = new Color(0, 0, 0, Mathf.Lerp(0, 1, timeToFade / 3f));
			}
		}
		if(timeToFade >= 6f) {
			SingletonObject.Get.getGameState().ResetWaypointNums();
			SingletonObject.Get.getTimer ().RemoveAll ();
			SingletonObject.Get.getGameState().totalEnemiesKilled = 0;
			Application.LoadLevel(0);
		}
	}

	public void FadeToWhite() {
		renderer.enabled = true;
		fading = true;
	}
}
