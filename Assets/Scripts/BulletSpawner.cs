using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

	public Camera gameCamera;
	public GameObject bulletPrefab;
	public float bulletSpeed = 10f;

	public float shootingCooldown = 0.5f;
	private float shootingTimer = 0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// float velocity = 20.0f;
		// if(Input.GetKeyDown(KeyCode.Space)) {
		// 	GameObject instance = Instantiate (ballPrefab);
		// 	instance.transform.position = transform.position;
		// 	Rigidbody rb = instance.GetComponent<Rigidbody> ();

		// 	Camera camera = GetComponentInChildren<Camera> ();

		// 	rb.velocity = camera.transform.rotation * Vector3.forward * velocity;
		// }

		shootingTimer -= Time.deltaTime;
	
		RaycastHit hit;

		if (Physics.Raycast(gameCamera.transform.position, gameCamera.transform.forward, out hit)) {

			if (hit.transform.GetComponent<Marshmallow> () != null && shootingTimer <= 0f) {

				shootingTimer = shootingCooldown;

				GameObject bulletObject = Instantiate (bulletPrefab);
				bulletObject.transform.position = this.transform.position;

				Projectile bullet = bulletObject.GetComponent<Projectile> ();
				bullet.direction = transform.forward;
				bullet.speed = bulletSpeed;

				SoundManager.Instance.PlayOneShot(SoundManager.Instance.gunFire);

			}

		}
	}

}
