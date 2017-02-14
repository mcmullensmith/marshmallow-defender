﻿using UnityEngine;
using System.Collections;

public class Marshmallow : MonoBehaviour {

	public bool isAlive = true;
	public GameObject explosion;

	public int scorePerHit = 50;
	public int damagePerPlayerHit = 20;

	public int damagePerCocoaHit = 10;

	private float delay = 3.0f;

	MarshMallowEmitter marshmallowEmitter;

	public float verticalForce = 200f;
	private float minVerticalForce = 200f;
	// Use this for initialization
	void Start () {
		marshmallowEmitter = FindObjectOfType<MarshMallowEmitter>();
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (new Vector3 (
			0, 
			Random.Range(-minVerticalForce, verticalForce), 
			0
		));
	}

	public void Die() {
		isAlive = false;
		Explode();
		Destroy(gameObject);
	}

	void Explode() {
        Instantiate(explosion, transform.position, transform.rotation);
		SoundManager.Instance.PlayOneShot(SoundManager.Instance.marshmallowExplosion);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision collision) {
		if (isAlive) {
			if (collision.gameObject.tag == "Projectile") {
				ScoreKeeper scoreKeeper = FindObjectOfType<ScoreKeeper>();
				scoreKeeper.IncrementScore(scorePerHit);
				Die ();
				marshmallowEmitter.marshmallowHits++;
				marshmallowEmitter.marshmallowsDestroyed++;
				
			} 

			if (collision.gameObject.tag == "Player") {
				DamageKeeper damageKeeper = FindObjectOfType<DamageKeeper>();
				damageKeeper.IncrementDamage(damagePerPlayerHit);
				CameraShake.Shake(1, 1);
				Die ();
				marshmallowEmitter.marshmallowHits++;
			
			} 

			if (collision.gameObject.tag == "Cocoa") {
				isAlive = false;
				DamageKeeper damageKeeper = FindObjectOfType<DamageKeeper>();
				damageKeeper.IncrementDamage(damagePerCocoaHit);
				marshmallowEmitter.marshmallowHits++;
				SoundManager.Instance.PlayOneShot(SoundManager.Instance.splash);
			} 

			if (collision.gameObject.tag == "OutOfBounds") {
				Destroy(gameObject);
				marshmallowEmitter.marshmallowHits++;
			
			} 

			if (collision.gameObject.tag == "Mug") {
				SoundManager.Instance.PlayOneShot(SoundManager.Instance.mugHit);
			}

		}
	}

	private IEnumerator WaitAndDestroy(){
    	yield return new WaitForSeconds(delay);
    	Destroy (gameObject);
 	}

}
