using UnityEngine;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using PuzzlePieces;
using ProtoBuf;
using System.IO;

public class Sandbox : MonoBehaviour {

	public GameObject cellPrefab;
	public GameObject gemPrefab;
	public GameObject[] foundCells;
	public GameObject[] foundGems;
	public float width;
	public float height;

	public Dictionary<TwoTuple, Cell> sObjects = new Dictionary<TwoTuple, Cell>();
	public Dictionary<TwoTuple, Gem> sGems = new Dictionary<TwoTuple, Gem>();

	public Puzzle puzzle;

	// Use this for initialization
	IEnumerator Start () {
		//CREATE TEST BOARD
		var startingX = -2;
		var startingY = -2;
		var index = 0;
		for (int y = startingY; y < height + startingY; y++) {
			for(int x = startingX; x < width + startingY; x++){
				var clone = (GameObject)Instantiate(cellPrefab, new Vector3(x, y, 0), Quaternion.identity);
				var gem = clone.GetComponent<Cell>();

				if(x % 2 == 0){
					var cloneGem = (GameObject)Instantiate(gemPrefab, new Vector3(x, y, 5), Quaternion.identity);
					cloneGem.GetComponent<Gem>().size = index++;
				}
				yield return new WaitForSeconds(0.01f);
			}
		}


		//FIND ALL OBJECT WITH THE TAG CUBE
		foundCells = GameObject.FindGameObjectsWithTag("cube");

		//FIND height from sorted vectors of y
		var hQuery = from k in foundCells orderby k.transform.position.y select k;
		var hResults = hQuery.ToArray();
		height = hResults[0].transform.position.y - hResults[hResults.Length - 1].transform.position.y;
		height = Mathf.Abs(height);

		//FIND width from sorted vectors of x 
		var wQuery = from k in foundCells orderby k.transform.position.x select k;
		var wResults = wQuery.ToArray();
		width = wResults[0].transform.position.x - wResults[wResults.Length - 1].transform.position.x;
		width = Mathf.Abs(width);


		//CRAM INTO DICTIONARY
		for(float i = hResults[0].transform.position.y; i <= hResults[hResults.Length - 1].transform.position.y; i++){
			var set = from s in hResults where s.transform.position.y == i orderby s.transform.position.x select s;
			var subset = set.ToArray();
			foreach(GameObject s in subset){
				int x =	Mathf.FloorToInt(s.transform.position.x - hResults[0].transform.position.x);
				int y = Mathf.FloorToInt(s.transform.position.y - hResults[0].transform.position.y);

				sObjects.Add(new TwoTuple(x,y), s.GetComponent<Cell>());
			}
		}

		foundGems = GameObject.FindGameObjectsWithTag("gem");
		var gemQuery = from k in foundGems orderby k.transform.position.y select k;
		var gemResult = gemQuery.ToArray();

		for(float i = hResults[0].transform.position.y; i <= hResults[hResults.Length - 1].transform.position.y; i++){
			var set = from s in gemResult where s.transform.position.y == i orderby s.transform.position.x select s;
			var subset = set.ToArray();
			foreach(GameObject s in subset){
				int x =	Mathf.FloorToInt(s.transform.position.x - hResults[0].transform.position.x);
				int y = Mathf.FloorToInt(s.transform.position.y - hResults[0].transform.position.y);
				
				sGems.Add(new TwoTuple(x,y), s.GetComponent<Gem>());
			}
		}

		puzzle = new Puzzle();
		puzzle.sCells = sObjects;
		puzzle.sGems = sGems;
		puzzle.height = (int)height;
		puzzle.width = (int)width;

		var file = File.Create("testPuzzle.lel");
		Serializer.Serialize(file, puzzle);

		yield return null;


		//EXPAND To ARRAY
//		Cell[,] cells = new Cell[(int)width + 1, (int)height + 1];
//		var keys = sObjects.Keys.ToArray();
//		foreach(TwoTuple t in keys){
//			cells[(int)t.x, (int)t.y] = sObjects[t];
//		}
//
//
//		//TEST RESULTS
//		foreach(GameObject g in cubes){
//			Destroy(g);
//			yield return new WaitForSeconds(.1f);
//		}
//
//		for(int y = 0; y <= cells.GetLength(1); y++){
//			for(int x = 0; x <= cells.GetLength(0); x++){
//				var clone = (GameObject)Instantiate(cube, new Vector3(x * 2, y * 2, 0), Quaternion.identity);
//				yield return new WaitForSeconds(0.25f);
//			}
//		}
	}
}
