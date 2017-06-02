using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HDDRotation : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		var camera = transform.parent.GetComponent<Camera>();
        var projectedLookDirection = Vector3.ProjectOnPlane(camera.transform.forward, Vector3.down);
        transform.rotation = Quaternion.LookRotation(projectedLookDirection);
	}
}
