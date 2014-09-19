using UnityEngine;
using System.Collections;

public class QuantityQuality : Condition {

	public int qantity;
	public int quality;

	public override void Initialize(PuzzleManager pm){
		base.Initialize(pm);
		canWin = false;
	}


}
