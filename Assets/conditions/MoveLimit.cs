using UnityEngine;
using System.Collections;
using ProtoBuf;

[ProtoContract]
public class MoveLimit : Condition {
	[ProtoMember(1)]
	private int limit;
	[ProtoMember(2)]
	private int movesMade;

	public void Initialize(PuzzleManager pm, int limit){
		base.Initialize(pm);
		pm.validMove += OnMove;
		canWin = true; //this is a lose condition, so canWin is on by default
	}

	public void OnMove(){//ignored in this case
		if (++movesMade >= limit){
			base.Lose();
		}
	}
}
