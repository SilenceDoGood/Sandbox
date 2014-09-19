using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using ProtoBuf;

namespace PuzzlePieces
{
	public enum CellType
	{
		Nothing,
		Floor,
		Wall
	}

	[ProtoContract]
	public class Cell : MonoBehaviour {
		[ProtoMember(1)]
		public CellType type;

		public bool isEligible(){
			return this.type == CellType.Floor;
		}

		public void Initialize(){
			
		}

//		public void OnGatherCells(List<Cell> openCells){
//
//		}
	}
}