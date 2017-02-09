using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	public static SoundManager Instance = null;
	private GvrAudioSource soundEffectAudio;

	public AudioClip gunFire;
	public AudioClip marshmallowExplosion;
	public AudioClip mugHit;
	public AudioClip playerDeath;
	public AudioClip splash;


	// Use this for initialization
	void Start () {
		if (Instance == null) {
			Instance = this;
		} else if (Instance != this) {
			Destroy(gameObject);
		}

		GvrAudioSource[] sources = GetComponents<GvrAudioSource>();
		
		foreach (GvrAudioSource source in sources) {
			if (source.clip == null) {
				soundEffectAudio = source;
			}
		}
	}
	
	public void PlayOneShot(AudioClip clip) {
		soundEffectAudio.PlayOneShot(clip);
	}
}
