﻿using UnityEngine;
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
		Destroy(gameObject);
	}


}
