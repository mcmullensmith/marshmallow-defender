using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Float : MonoBehaviour {

	float waterLevel = 4;
	float floatHeight = 2;
	float bounceDamp = 5;
	Vector3 buoyancyCenterOffset;
	float forceFactor;
	Vector3 actionPoint;
	Vector3 upLift;
	public Rigidbody rb;

	void Start()  {
		rb = GetComponent<Rigidbody>();
	}

	void Update() {
		actionPoint = transform.position + transform.TransformDirection(buoyancyCenterOffset);
		forceFactor = 1f - ((actionPoint.y - waterLevel)/ floatHeight);

		if(forceFactor  > 0f ) {
			upLift = -Physics.gravity * (forceFactor - rb.velocity.y * bounceDamp);
			rb.AddForceAtPosition(upLift, actionPoint);
		}
	}



}
