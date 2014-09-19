using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using PuzzlePieces;
using ProtoBuf;
using System.IO; //TEMP

public class PuzzleManager : MonoBehaviour {
	
	public delegate void moveDelegate();
	public event moveDelegate validMove;
	public Puzzle cPuzzle;
	public List<Vector2> eligiblePositions;

	void  Start(){
		validMove += trySpawn;
		//DebugCode();

#region levelLoading
		

#endregion
		gatherPostions();
	}

	public void Swipe(Vector2 dir){
		int width = cPuzzle.cells.GetLength(0);
		int height = cPuzzle.cells.GetLength(1);
		bool didMove = false;
		for (int x = 1; x < width; x++){
			for (int y = 1; y < height; y++){
				didMove = tryMove (new Vector2((dir.x > 0 ? width - 1 - x : x),(dir.y > 0 ? height - 1 - y : y)), dir) || didMove;
			}
		}

		if(didMove){
			validMove();
		}
	}

	public bool tryMove(Vector2 position, Vector2 dir)
	{
		return true;
	}

	public void moveGem(Vector2 pos, Vector2 dir){

	}

	public void fuseGem(){

	}

	public void trySpawn(){
		List<Vector2> open = new List<Vector2>();
		foreach(Vector2 v in eligiblePositions){
			if(cPuzzle.gems[(int)v.x, (int)v.y] == null){
				open.Add(v);
			}
		}

		float chance = 1f - (1f - cPuzzle.spawnMod) * (1f - ((float)open.Count / (float)eligiblePositions.Count));

		if(Random.value < chance){
			var openPos = open[Random.Range(0, open.Count)];

			int gemSize = 0;
			while(gemSize < cPuzzle.spawnChances.Length && Random.value > cPuzzle.spawnChances[gemSize]){
				gemSize++;
			}

			//cPuzzle.gems[openPos.x, openPos.y] = ; //CREATE GEM FROM OBJECTMANAGER
		}
	}

	public void OnLoseGame(){

	}

	public void OnCheckWin(){

	}

	public void gatherPostions(){
		eligiblePositions = new List<Vector2>();
		for(int x = 0; x < cPuzzle.cells.GetLength(0); x++){
			for(int y = 0; y < cPuzzle.cells.GetLength(1); y++){
				if(cPuzzle.cells[x, y].isEligible()){
					eligiblePositions.Add(new Vector2(x, y));
				}
			}
		}
	}

	public Vector3 GridToWorldSpace(Vector2 GridVect){ return Vector3.zero; }

	public Vector2 WorldToGridSpace(Vector3 WorldVect){ return Vector3.zero; }

	public void DebugCode()
	{
		cPuzzle = Serializer.Deserialize<Puzzle>(File.OpenRead("Assets/puzzles/testPuzzle.lel"));
//		cPuzzle = new Puzzle();
//		cPuzzle.cells = new Cell[4,4];
//		cPuzzle.gems = new Gem[4,4];
//		for(int i = 0; i < cPuzzle.cells.GetLength(0); i++)
//		{
//			cPuzzle.cells[i,i] = new Cell();
//			cPuzzle.cells[i,i].type = CellType.Floor;
//			cPuzzle.gems[i,i] = new Gem();
//			cPuzzle.gems[i,i].size = Random.Range(0, 62);
//		}
//		
//		var file = File.Create("Assets/puzzles/testPuzzle.lel");
//		Serializer.Serialize(file, cPuzzle);
	}
}
