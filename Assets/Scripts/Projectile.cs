using UnityEngine;
using System.Collections;

public class Projectile : MonoBehaviour {

//	public GameObject water;

	public int force = 2;
	public float speed;

	public Vector3 direction;
	public float lifeTime = 100f;


	// Use this for initialization
	void Start () {
//		GameObject instance = Instantiate (water);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += direction * speed * Time.deltaTime;
		lifeTime -= Time.deltaTime;

		if(lifeTime < 0) {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// OnCollisionEnter is called when this collider/rigidbody has begun
	/// touching another rigidbody/collider.
	/// </summary>
	/// <param name="other">The Collision data associated with this collision.</param>
	void OnCollisionEnter(Collision other)
	{
		Destroy(gameObject);
	}

}
