using UnityEngine;
using System.Collections;

public class Controller : MonoBehaviour {
	public GameObject[] cubes;

	IEnumerator Start () {
//		GameObject.FindGameObjectsWithTag("cube");
//
//		foreach(GameObject g in cubes){
//
//		}
		yield return null;
	}

	void OnGUI(){
		cubes = GameObject.FindGameObjectsWithTag("cube");

		Vector3 bottom = cubes[1].renderer.GetComponent<MeshFilter>().mesh.bounds.min;

		Vector3 top = cubes[0].renderer.GetComponent<MeshFilter>().mesh.bounds.max;

		Vector3 aDelta = new Vector3(0, cubes[0].transform.position.y - top.y, 0);

		Vector3 bDelta = new Vector3(0, cubes[1].transform.position.y - bottom.y, 0);

		var toMidPoint = Vector3.Distance(aDelta, bDelta) / 2;

		Vector3 tmp = Camera.main.transform.position;

		tmp.y = cubes[0].transform.position.y + toMidPoint;

		Camera.main.transform.position = tmp;

		GUI.Box( new Rect (Screen.width * 0.1f, 10, 100f, 100f), "");
	}

	void Update () {
		
	}
}
