using UnityEngine;
using System.Collections;

namespace Adnc.Utility {
	[System.Serializable]
	public class MinMaxInt: MinMaxBase<int> {
		public override int GetRandom () {
		    // +1 added since it calculates max minus 1
			return Random.Range(min, max + 1);
		}
	}
}

