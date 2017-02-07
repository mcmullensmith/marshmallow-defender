using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

//	Transform target;
//
//	public GameObject water;
//	public int force = 2;
//
//	public float speed = 5.0f;
//
//	public float autoDestroyAfter = 5.0f;

	/* Represents the homing sensitivity of the missile.
Range [0.0,1.0] where 0 will disable homing and 1 will make it follow the target like crazy.
This param is fed into the Slerp (defines the interpolation point to pick) */
//	public float homingSensitivity = 0.1f;


	// Use this for initialization
//	void Start () {
//		GameObject instance = Instantiate (water);
//		StartCoroutine(AutoExplode());
//	}


//	private void ExplodeSelf() {
//		Instantiate(explosion,transform.position,Quaternion.identity);
//		Destroy(gameObject);
//	}
//
//	float AutoExplode() {
//		yield return WaitForSeconds(autoDestroyAfter);
//		ExplodeSelf();
//	}
//	
	// Update is called once per frame
//	void Update () {
//		Rigidbody rigidBody = GetComponent<Rigidbody> ();
//		if (transform.position.y < water.transform.position.y) {
//			Debug.Log ("float");
//			rigidBody.AddForce (transform.up * force * 10	);
//		}

//		if (transform.position.y < water.transform.position.y) {
//			Debug.Log ("float");
//			rigidBody.AddForce (transform.up * force * 5);
//		}
//		if(target != null) {
//			Vector3 relativePos = target.position - transform.position;
//			Quaternion rotation = Quaternion.LookRotation(relativePos);
//
//			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, homingSensitivity);
//		}
//
//		transform.Translate(0,0,speed * Time.deltaTime,Space.Self);
//	}
}
