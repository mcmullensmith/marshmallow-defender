using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MarshMallowEmitter : MonoBehaviour {

	private int BASE_LOOP = 4;
	public GameObject[] marshmallows;

	//total collisions of marshmallows whether projectile, ground hit or destroyed outside mug
	public int marshmallowHits = 0;

	public int level = 1;

	//max marshmallows per level
	private int maxMarshmallows = 15;
	//max loops per level
	private int maxLoops = 5;

	public float horizontalArea = 10.0f;

	public float spawnDuration = 3.0f;

	private float spawnTimer;

	private bool isGameOver = false;

	DamageKeeper damageKeeper;

	private IEnumerator coroutine;

	GameObject levelUI;

	private bool levelComplete = false;


	// Use this for initialization
	void Start () {
		
		spawnTimer = spawnDuration;
		damageKeeper = FindObjectOfType<DamageKeeper>();
		coroutine = LevelLoader();
		StartCoroutine(coroutine);

		levelUI = GameObject.FindGameObjectWithTag("LevelUI");
		levelUI.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {

		if (damageKeeper.damage == 0) {
			isGameOver = true;
			print("Game Over");
			SceneManager.LoadScene("GameOver");
		}

		// print("marshmallow hits: " + marshmallowHits);
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
			print("did this run twice?");
			levelComplete = true;
			yield return StartCoroutine( ShowMessage() );
			
		} 


	}

	private IEnumerator ShowMessage () {

			if(levelComplete) {
				print("level complete: " + levelComplete);
				ResetLevel();
				levelUI.SetActive(true);

				yield return new WaitForSeconds(10f);
			
				levelUI.SetActive(false);
				StartCoroutine(LevelLoader());

				
			}
			
		
 	}

	 private void ResetLevel() {
		 print("reset level called: " + level);
		 levelComplete = false;

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
					Random.Range (-20, 20)
				);
	}
}
