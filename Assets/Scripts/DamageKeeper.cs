using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageKeeper : MonoBehaviour {

	
	public int damage = 100;

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}

	public void IncrementDamage(int amount) {
		
		damage -= amount;
		print("Your damage: " + damage);
	}
}
