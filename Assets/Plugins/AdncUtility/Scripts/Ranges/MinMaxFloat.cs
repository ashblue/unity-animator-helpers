using UnityEngine;
using System.Collections;

namespace Adnc.Utility {
	[System.Serializable]
	public class MinMaxFloat: MinMaxBase<float> {
		public override float GetRandom () {
			return Random.Range(min, max);
		}
	}
}

