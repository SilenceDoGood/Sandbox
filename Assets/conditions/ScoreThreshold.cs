using UnityEngine;
using System.Collections;

public class ScoreThreshold : Condition {

	public int targetScore;

	public override void Initialize(PuzzleManager pm){
		base.Initialize(pm);
		canWin = false;
	}
}
