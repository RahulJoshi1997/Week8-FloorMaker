using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	//Count the number of floor tiles and pathmakers
	public int floorCount = 0;
	public int pathMakerCount = 0;

	public float zMax = 0f;
	public float zMin = 0f;
	public float xMax = 0f;
	public float xMin = 0f;

	public GameObject cam;
	Vector3 cameraPos = new Vector3(0f,0f,0f);

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		//Moving Camera
		cameraPos.x = (xMin + xMax) / 2f;
		cameraPos.z = (zMin + zMax) / 2f;

		float zoomFactor = 0;
		if (Mathf.Abs(xMin) + Mathf.Abs(xMax) > Mathf.Abs(zMin) + Mathf.Abs(zMax))
			zoomFactor = Mathf.Abs(xMin) + Mathf.Abs(xMax);
		if (Mathf.Abs(xMin) + Mathf.Abs(xMax) < Mathf.Abs(zMin) + Mathf.Abs(zMax))
			zoomFactor = Mathf.Abs(zMin) + Mathf.Abs(zMax);
		cameraPos.y = zoomFactor;

		cam.transform.position = cameraPos;

		//Have a way to regenerate the map in WebGL
		if (Input.GetKeyDown (KeyCode.R)) {
			SceneManager.LoadScene ("Floors");
		}

	}
}
