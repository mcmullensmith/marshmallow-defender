using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MarshMallowEmitter : MonoBehaviour {

	public GameObject[] marshmallows;

	//total collisions of marshmallows whether projectile, ground hit or destroyed outside mug
	public int marshmallowHits = 0;

	private int level = 1;

	//max marshmallows per level
	private int maxMarshmallows;
	//max loops per level
	private int maxLoops = 5;

	public float horizontalArea = 10.0f;

	public float spawnDuration = 3.0f;

	private float spawnTimer;

	private bool isGameOver = false;

	DamageKeeper damageKeeper;

	// Use this for initialization
	void Start () {
		maxMarshmallows = marshmallows.Length * maxLoops;
		spawnTimer = spawnDuration;
		damageKeeper = FindObjectOfType<DamageKeeper>();
		// StartCoroutine(LevelLoader());
	}
	
	// Update is called once per frame
	void Update () {
		print("marshmallow hits: " + marshmallowHits);
		print("maxmarshmallows : " + maxMarshmallows);
		print("Level: " + level);
		print("Max : " + maxLoops);

		if (damageKeeper.damage == 0) {
			isGameOver = true;
			print("Game Over");
			SceneManager.LoadScene("GameOver");
		}

		
		GenerateMarshmallows();

	}

	private IEnumerator LevelLoader() {

		// while (marshmallowHits <  maxMarshmallows ) {
			for (int i = 0; i< marshmallows.Length; i++) {
				SpawnMarshmallows();
				yield return new WaitForSeconds(spawnDuration);
			}
			
		// }
		
		yield return new WaitForSeconds (5f);


		if (marshmallowHits == maxMarshmallows && isGameOver == false) {
			maxMarshmallows += 2;
		 	level++;
		 	marshmallowHits = 0;

			StartCoroutine (LevelLoader ());
		}
	}

	void GenerateMarshmallows() {
		if ( marshmallowHits == maxMarshmallows && isGameOver == false ) {
			print("Level over");
			return;
		}
		
		spawnTimer -= Time.deltaTime;
		if(maxLoops > 0) {
			if ( spawnTimer <= 0f ) {
				spawnTimer = spawnDuration;
				for ( int i = 0; i< marshmallows.Length; i++ ) {
					SpawnMarshmallows();
				}
				maxLoops--;
			}
		}
		
	}

	void SpawnMarshmallows() {

		GameObject marshmallow = Instantiate (marshmallows [Random.Range (0, marshmallows.Length)]);
				marshmallow.transform.position = new Vector3 (
					Random.Range (-horizontalArea, horizontalArea),
					100.0f,
					Random.Range (-horizontalArea, horizontalArea)
				);
	}
}
