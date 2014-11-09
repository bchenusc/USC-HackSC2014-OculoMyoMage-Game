using UnityEngine;
using System.Collections;

public class ScoresUI : MonoBehaviour {
	
	public TextMesh textMesh;
	
	// Use this for initialization
	void Start () {
		textMesh = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		textMesh.text = "Score: " + SingletonObject.Get.getGameState().totalEnemiesKilled;
	}
}
