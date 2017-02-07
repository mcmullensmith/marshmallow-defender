using UnityEngine;
using System.Collections;

public class Marshmallow : MonoBehaviour {

	public bool isAlive = true;
	public GameObject explosion;

	private AudioSource audioSource;

	public float verticalForce = 150f;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (new Vector3 (
			0, 
			Random.Range(-verticalForce, verticalForce), 
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
		// audioSource.PlayOneShot(SoundManager.Instance.marshmallowExplosion);
		SoundManager.Instance.PlayOneShot(SoundManager.Instance.marshmallowExplosion);
    }
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision) {
		// Debug.Log ("Collision enter");
		// Debug.Log ("Collider enter");
		if (isAlive) {
			if (collision.gameObject.tag == "Projectile") {
				Debug.Log ("Die");
				Die ();
			} else {

			}

		}
	}


	void OnTriggerEnter(Collider other) {
		Debug.Log ("Collider enter");
		if (isAlive) {
			if (other.gameObject.tag == "Projectile") {
				Debug.Log ("Die");
				Die ();
			} else {
				Debug.Log ("Die");
				Die ();
			}
	
		}
	}

}
