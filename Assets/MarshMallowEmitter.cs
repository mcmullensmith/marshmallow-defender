using UnityEngine;
using System.Collections;

public class MarshMallowEmitter : MonoBehaviour {

	public GameObject[] marshmallows;

	public float horizontalArea = 10.0f;

	private float spawnDuration = 3.0f;

	private float spawnTimer;

	// Use this for initialization
	void Start () {
		spawnTimer = spawnDuration;
	}
	
	// Update is called once per frame
	void Update () {
		spawnTimer -= Time.deltaTime;
		if (spawnTimer <= 0f) {
			spawnTimer = spawnDuration;
			for (int i = 0; i < marshmallows.Length; i++) {
				GameObject marshmallow = Instantiate (marshmallows [Random.Range (0, marshmallows.Length)]);
				marshmallow.transform.position = new Vector3 (
					Random.Range (-horizontalArea, horizontalArea),
					100.0f,
					Random.Range (-horizontalArea, horizontalArea)
				);
			}
		}

	}
}
