using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyedDisplay : MonoBehaviour {

	Text text;
	MarshMallowEmitter marshmallowEmitter;

	// Use this for initialization
	void Start () {
		marshmallowEmitter = FindObjectOfType<MarshMallowEmitter> ();
		text = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = marshmallowEmitter.marshmallowsDestroyed + " Marshmallows Destroyed";
	}
}
