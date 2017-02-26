using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastShoot : MonoBehaviour {

	public int gunDamage = 1;
	public float fireRate = 0.25f;
	public float weaponRange = 100f;
	public float hitForce = 800f;
	public Transform gunEnd;

	private Camera fpsCam;
	private WaitForSeconds shotDuration = new WaitForSeconds(.07f);
	private LineRenderer laserLine;
	private float nextFire;


	

	// Use this for initialization
	void Start () {
		laserLine = GetComponent<LineRenderer>();
		laserLine.numPositions = 2;
		laserLine.startWidth = 0.25f;
		laserLine.endWidth = 0.25f;
		fpsCam = GetComponentInParent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
		if (GvrViewer.Instance.Triggered || Input.GetButtonDown("Fire1") && Time.time > nextFire) {

			nextFire = Time.time + fireRate;

			StartCoroutine(ShotEffect());

			Vector3 rayOrigin = fpsCam.ViewportToWorldPoint( new Vector3(0.5f, 0.5f, 0));

			RaycastHit hit;

			laserLine.SetPosition(0, gunEnd.position);

			if(Physics.Raycast (rayOrigin, fpsCam.transform.forward, out hit, weaponRange)) {

				laserLine.SetPosition(1, hit.point);

				Marshmallow health = hit.collider.GetComponent<Marshmallow>();

				// If there was a health script attached
                if (health != null)
                {
                    // Call the damage function of that script, passing in our gunDamage variable
                    health.Damage (gunDamage);
                }
			
				if (hit.rigidbody != null)
                {
                    // Add force to the rigidbody we hit, in the direction from which it was hit
                    hit.rigidbody.AddForce (-hit.normal * hitForce);
                }
			}
			else {

				laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * weaponRange));
			}
			
		}

		
	}

	private IEnumerator ShotEffect() {
		laserLine.enabled = true;

		yield return shotDuration;

		laserLine.enabled = false;
	}
}
