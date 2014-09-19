using UnityEngine;
using System.Collections;
using ProtoBuf;

[ProtoContract]
public class TimeLimit : Condition {

	[ProtoMember(1)]
	public float timeLimit;

	public override void Initialize(PuzzleManager pm){
		base.Initialize(pm);
		/*
		 Invoke("Lose", timeLimit);//quick and dirty. Mostly dirty - does not respect pausing.
		//or
		//*/
		//endStamp = Core.gameTime + timeLimit;//respects GameTime pausing
		//Core.tHeartbeat += checkTimer;
	}

	private float endStamp;

	public void checkTimer(){
//		if (Core.gameTime >=endStamp) {
//			Lose ();
//		}
	}


	public void OnDestroy(){
		//Core.tHeartbeat -= checkTimer;//must make sure this is never destroyed before being Initialize()d.
	}
	//*/
}
