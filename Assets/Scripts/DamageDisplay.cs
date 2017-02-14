using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DamageDisplay : MonoBehaviour {

	DamageKeeper damageKeeper;

	Text text;

	// Use this for initialization
	void Start () {
		damageKeeper = FindObjectOfType<DamageKeeper>();
		text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Damage : " + damageKeeper.damage;

		if (damageKeeper.damage <= 70  && damageKeeper.damage > 40) {
			text.color = Color.yellow;
		} else if (damageKeeper.damage <= 40) {
			text.color = Color.red;
		} else {
			text.color = Color.white;
		}
	}
}
