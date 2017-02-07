using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

//	public GameObject water;

	public int force = 2;


	// Use this for initialization
	void Start () {
//		GameObject instance = Instantiate (water);
	}
	
	// Update is called once per frame
	void Update () {
//		Rigidbody rigidBody = GetComponent<Rigidbody> ();
//		if (transform.position.y < water.transform.position.y) {
//			Debug.Log ("float");
//			rigidBody.AddForce (transform.up * force * 10	);
//		}
//
//		if (transform.position.y < water.transform.position.y) {
//			Debug.Log ("float");
//			rigidBody.AddForce (transform.up * force * 5);
//		}
//
	}

	void OnBecameInvisible() {
		Destroy(gameObject);
	}

	void OnCollisionEnter(Collision collision) {
		// print("projectile collision");
		Destroy(gameObject);
	}

	/// <summary>
	/// OnTriggerEnter is called when the Collider other enters the trigger.
	/// </summary>
	/// <param name="other">The other Collider involved in this collision.</param>
	void OnTriggerEnter(Collider other)
	{
			// print("projectile collision");
			Destroy(gameObject);
	}


}
