using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelDisplay : MonoBehaviour {

	Text text;

	MarshMallowEmitter marshmallowEmitter;

	// Use this for initialization
	void Start () {
		text = GetComponent<Text>();
		marshmallowEmitter = FindObjectOfType<MarshMallowEmitter>();

	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Level " + marshmallowEmitter.level;
	}
}
