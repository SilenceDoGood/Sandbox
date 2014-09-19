using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

public class Sandbox : MonoBehaviour {

	public GameObject cube;
	public GameObject[] cubes;
	public List<GameObject> cubeList;
	public int width;
	public int height;

	// Use this for initialization
	void Start () {
		for (int x = 0; x < width; x ++) {
			for(int y = 0; y < height; y++){
				Instantiate(cube, new Vector3(x * 2, y * 2, 0), Quaternion.identity);
			}
		}

		cubes = GameObject.FindGameObjectsWithTag("cube");

		var results = from k in cubes orderby k.transform.position.x select k;



		foreach (GameObject g in results) {
			Debug.Log(g.transform.position.x);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
