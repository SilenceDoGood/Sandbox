using UnityEngine;
using System.Collections;
using ProtoBuf;

namespace PuzzlePieces
{
	[ProtoContract]
	public class Gem : MonoBehaviour {
		[ProtoMember(1)]
		public int size;
		
		public void Initialize(int size){
			//SELECT TEXTURE BASED ON SIZE
		}
		
		public int CompareTo(Object other){
			return 0;
		}
		
		public IEnumerator AnimateIn(){
			yield return null;
		}
		
		public IEnumerator AnimateOut(){
			yield return null;
		}
		
		public IEnumerator AnimateMove(Vector2 dir){
			yield return null;
		}
		
		public IEnumerator AnimateFuse(Vector2 dir){
			yield return null;
		}
		
	}
}