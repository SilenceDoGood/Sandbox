using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;

namespace PuzzlePieces
{
	[ProtoContract]
	public class Puzzle  {
		[ProtoMember(1)]
		public Dictionary<TwoTuple, Cell> sCells;

		[ProtoMember(2)]
		public Dictionary<TwoTuple, Gem> sGems;

		public Cell[,] cells;
		public Gem[,] gems;

		[ProtoMember(3)]
		public Condition[] conditions;

		[ProtoMember(4)]
		public int width;
		[ProtoMember(5)]
		public int height;
		[ProtoMember(6)]
		public float[] spawnChances;
		[ProtoMember(7)]
		public float spawnMod;

		public void Initialize(){}

		[ProtoAfterDeserialization]
		void expand(){
			cells = new Cell[width,height];
			gems = new Gem[width,height];
			foreach(TwoTuple t in sCells.Keys){
				cells[t.x, t.y] = sCells[t];
			}

			foreach(TwoTuple t in sGems.Keys){
				gems[t.x, t.y] = sGems[t];
			}


		}

		//[ProtoBeforeSerialization]
		void squish(){
			sCells = new Dictionary<TwoTuple, Cell>();
			sGems = new Dictionary<TwoTuple, Gem>();
			
			for(int x = 0; x < cells.GetLength(0); x++)
			{
				for(int y = 0; y < cells.GetLength(1); y++){
					if(cells[x,y] != null){
						sCells.Add(new TwoTuple(x,y), cells[x,y]);
					}
					if(gems[x,y] != null){
						sGems.Add(new TwoTuple(x,y), gems[x,y]);
					}
				}
			}
			
			width = cells.GetLength(0);
			height = cells.GetLength(1);
		}
	}
}
