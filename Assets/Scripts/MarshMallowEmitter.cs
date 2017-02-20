using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MarshMallowEmitter : MonoBehaviour {

	private int BASE_LOOP = 4;
	public GameObject[] marshmallows;

	//total collisions of marshmallows whether projectile, ground hit or destroyed outside mug
	public int marshmallowHits = 0;

	public int marshmallowsDestroyed = 0;

	public int level = 1;

	//max marshmallows per level
	private int maxMarshmallows = 15;
	//max loops per level
	private int maxLoops = 5;

	public float horizontalArea = 10.0f;

	private float spawnDuration = 3.0f;

	private float spawnTimer;

	public bool isGameOver = false;

	DamageKeeper damageKeeper;

	ScoreKeeper scoreKeeper;

	BulletSpawner bulletSpawner;

	Marshmallow marshmallow;

	private IEnumerator coroutine;

	GameObject levelUI;

	GameObject gameUI;

	GameObject gameOverUI;

	Timer timer;

	private bool levelComplete = false;


	// Use this for initialization
	void Start () {
		
		timer = FindObjectOfType<Timer>();
		spawnTimer = spawnDuration;

		damageKeeper = FindObjectOfType<DamageKeeper>();
		damageKeeper.damage = 100;

		scoreKeeper = FindObjectOfType<ScoreKeeper>();

		bulletSpawner = FindObjectOfType<BulletSpawner>();

		marshmallow = FindObjectOfType<Marshmallow>();

		scoreKeeper.score = 0;

		coroutine = LevelLoader();
		StartCoroutine(coroutine);

		levelUI = GameObject.FindGameObjectWithTag("LevelUI");
		levelUI.SetActive(false);

		gameUI = GameObject.FindGameObjectWithTag("GameUI");

		gameOverUI = GameObject.FindGameObjectWithTag("GameOverUI");
		gameOverUI.SetActive(false);

	}
	
	// Update is called once per frame
	void Update () {

		if (damageKeeper.damage == 0) {
			isGameOver = true;
			gameOverUI.SetActive(true);
			gameUI.SetActive(false);
			StopAllCoroutines();
		}

		//decrease shootingCooldown as levels progress
		//increase marshmallow vertical force
		//increase horizontal horizontalArea
		//decrease spawn duration
		if (level > 3) {
			marshmallow.verticalForce = 225;
			horizontalArea = 10.25f;
			spawnDuration = 2.75f;
		} else if (level > 6) {
			bulletSpawner.shootingCooldown = 0.4f;
			marshmallow.verticalForce = 250;
			horizontalArea = 10.5f;
			spawnDuration = 2.5f;
		} else if (level > 9) {
			bulletSpawner.shootingCooldown = 0.3f;
			marshmallow.verticalForce = 300;
			horizontalArea = 11f;
			spawnDuration = 2.25f;
		} else if (level > 12) {
			bulletSpawner.shootingCooldown = 0.2f;
			marshmallow.verticalForce = 350;
			horizontalArea = 12;
			spawnDuration = 2.0f;
		} else {
			bulletSpawner.shootingCooldown = 0.5f;
		}

		print("marshmallow hits: " + marshmallowHits);
		// print("max marshmallows: " + maxMarshmallows);

	}

	private IEnumerator LevelLoader() {
	
		spawnTimer -= Time.deltaTime;		
		
		if(maxLoops != 0) {

			for ( int i = 0; i< marshmallows.Length; i++ ) {
				SpawnMarshmallows();
			}
			maxLoops--;

			yield return new WaitForSeconds (2f);
			
			StartCoroutine(LevelLoader());

		}
		
		yield return new WaitForSeconds (10f);
		

		if ( marshmallowHits == maxMarshmallows && isGameOver == false ) {
			levelComplete = true;
			yield return StartCoroutine( ShowMessage() );
			
		} 


	}

	private IEnumerator ShowMessage () {

			if(levelComplete) {

				print("level complete: " + levelComplete);
				ResetLevel();
			
				levelUI.SetActive(true);
				gameUI.SetActive(false);

				yield return new WaitForSeconds(10f);
			
				levelUI.SetActive(false);
				gameUI.SetActive(true);

				marshmallowsDestroyed = 0;
			
				StartCoroutine(LevelLoader());

				
			}
			
		
 	}

	private void ResetLevel() {
		print("reset level called: " + level);
		levelComplete = false;

		timer.timer = 10;

		GameObject[] clones = GameObject.FindGameObjectsWithTag("Marshmallow");
			
		foreach(var clone in clones) {
			Destroy(clone);
		}

		maxMarshmallows += 3;
		level++;
		marshmallowHits = 0;
		maxLoops = BASE_LOOP + level;
		damageKeeper.damage = 100;
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
