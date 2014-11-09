using UnityEngine;
using System.Collections;

public class MageSounds : MonoBehaviour {

	public AudioClip fireballLaunch;
	public AudioClip death;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void PlaySound(AudioClip clip) {
		if(audio.isPlaying && audio.clip != clip)
		{
			audio.Stop();
			audio.clip = clip;
			audio.Play();
		} else if (!audio.isPlaying) {
			audio.clip = clip;
			audio.Play();
		}
	}
	
	public void StopSound(AudioClip clip) {
		if(audio.clip == clip) {
			audio.Stop();
			audio.clip = null;
		}
	}
}
