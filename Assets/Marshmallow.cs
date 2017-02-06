using UnityEngine;
using System.Collections;

public class Marshmallow : MonoBehaviour {

	public bool isAlive = true;

	public float verticalForce = 150f;
	// Use this for initialization
	void Start () {
		Rigidbody rigidBody = GetComponent<Rigidbody> ();
		rigidBody.AddForce (new Vector3 (
			0, 
			Random.Range(-verticalForce, verticalForce), 
			0
		));
	}

	public void Die() {
		isAlive = false;
//		if (deathParticles) {
//			deathParticles.transform.parent = null;
//			deathParticles.Activate();
//		}
		Destroy(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

//	void OnCollisionEnter(Collision collision) {
//		Debug.Log ("Collision enter");
//	}


	void OnTriggerEnter(Collider other) {
//		Debug.Log ("Collider enter");
		if (isAlive) {
			if (other.gameObject.tag == "Projectile") {
				Debug.Log ("Die");
				Die ();
			} else {
				Debug.Log ("Mug hit");
			}
		
//			SoundManager.Instance.PlayOneShot(SoundManager.Instance.alienDeath);
		}
	}

}
