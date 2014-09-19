using UnityEngine;
using System.Collections;
using ProtoBuf;

[ProtoContract]
public class TwoTuple {
	[ProtoMember(1)]
	public int x;
	[ProtoMember(2)]
	public int y;

	public TwoTuple(){
		Debug.Log("TwoTuple was created");
	}

	public TwoTuple(int x, int y)
	{
		this.x = x;
		this.y = y;
	}
}
