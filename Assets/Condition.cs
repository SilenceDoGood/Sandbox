using UnityEngine;
using System.Collections;
using ProtoBuf;

[ProtoContract]
[ProtoInclude(1, typeof(MoveLimit))]
[ProtoInclude(2, typeof(QuantityQuality))]
[ProtoInclude(3, typeof(TimeLimit))]
[ProtoInclude(4, typeof(ScoreThreshold))]
public class Condition  {

	public delegate void GameEvent();
	public event GameEvent OnLose;
	public event GameEvent OnWin; //try to win

	public bool canWin = false;

	public virtual void Initialize(PuzzleManager pm){
		OnLose += pm.OnLoseGame;
		OnWin += () =>  canWin = true;
		OnWin += pm.OnCheckWin;
		//each child should call base.Initialize(pm); and then subscribe to relevant events. On those events, either canWin=false;, Lose();, or win();.
	}

	public void Lose(){
		OnLose();
	}

	public void Win(){
		OnWin();
	}
}
