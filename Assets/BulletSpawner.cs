using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

	public GameObject ballPrefab;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float velocity = 20.0f;
		if(Input.GetKeyDown(KeyCode.Space)) {
			GameObject instance = Instantiate (ballPrefab);
			instance.transform.position = transform.position;
			Rigidbody rb = instance.GetComponent<Rigidbody> ();

			Camera camera = GetComponentInChildren<Camera> ();

			rb.velocity = camera.transform.rotation * Vector3.forward * velocity;
		}
	}

}
