using UnityEngine;
using System.Collections;

public class PathMaker : MonoBehaviour {

	GameManager gm;

	int counter = 0;
	float turnProbablity;
	float babyProbablity;
	int counterLimit;

	public Transform floorPrefab1;
	public Transform floorPrefab2;
	public Transform floorPrefab3;
	public Transform pathmakerSpherePrefab;

	// Use this for initialization
	void Start () {
		gm = GameObject.Find ("GameManager").GetComponent<GameManager> ();

		//Randomize some elements of the pathMaker
		turnProbablity = Random.Range (0.1f, 0.20f);
		babyProbablity = Random.Range (0.75f, 0.99f);
		counterLimit = Random.Range (10, 50);
	}
	
	// Update is called once per frame
	void Update () {
		//Each pathMaker produces only a certain amount of floor tiles
		if (counter < counterLimit) {
			float rand = Random.value;
			if (rand < turnProbablity) {
				this.transform.Rotate (new Vector3 (0f, 90f, 0f));
			} else if (rand < turnProbablity * 2f) {
				this.transform.Rotate (new Vector3 (0f, -90f, 0f));
			} else if (rand > babyProbablity && gm.pathMakerCount < 5) {
				Instantiate (pathmakerSpherePrefab, this.transform.position, this.transform.rotation);
				gm.pathMakerCount++;
			}

			int floorChoice = Random.Range (1, 4);
			if (floorChoice == 1) {
				Instantiate (floorPrefab1, this.transform.position, Quaternion.Euler (0f, 0f, 0f));
			} else if (floorChoice == 2) {
				Instantiate (floorPrefab2, this.transform.position, Quaternion.Euler (0f, 0f, 0f));
			} else if (floorChoice == 3) {
				Instantiate (floorPrefab3, this.transform.position, Quaternion.Euler (0f, 0f, 0f));
			}
			gm.floorCount++;

			transform.position += transform.forward * 5f;
			if (this.transform.position.x > gm.xMax)
				gm.xMax = this.transform.position.x;
			if (this.transform.position.x < gm.xMin)
				gm.xMin = this.transform.position.x;
			if (this.transform.position.z > gm.zMax)
				gm.zMax = this.transform.position.z;
			if (this.transform.position.z < gm.zMin)
				gm.zMin = this.transform.position.z;

			counter++;
		} else {	//Get rid of the pathMaker after the counterLimit has been reached.
			Destroy (this.gameObject);
			gm.pathMakerCount--;
		}

		//Limit the maximum number of floor tiles.
		if (gm.floorCount >= 1000) {
			Destroy (this.gameObject);
		}
	}
}
