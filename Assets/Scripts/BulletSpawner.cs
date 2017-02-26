using UnityEngine;
using System.Collections;

public class BulletSpawner : MonoBehaviour {

	public Camera gameCamera;
	public GameObject bulletPrefab;
	public float bulletSpeed = 10f;

	public float shootingCooldown = 0.5f;
	private float shootingTimer = 0f;

	MarshMallowEmitter marshmallowEmitter;


	// Use this for initialization
	void Start () {
		marshmallowEmitter = FindObjectOfType<MarshMallowEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if( marshmallowEmitter.isGameOver) {
			return;
		}

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
				bullet.transform.rotation = Quaternion.LookRotation(Camera.main.transform.forward, Camera.main.transform.up);

				SoundManager.Instance.PlayOneShot(SoundManager.Instance.gunFire);

			}

		}
	}

}
