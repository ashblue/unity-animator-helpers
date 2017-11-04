using UnityEngine;
using System.Collections;

namespace Adnc.Utility {
	public class MinMaxFloatAttribute : PropertyAttribute {
		public readonly float min;
		public readonly float max;

		public MinMaxFloatAttribute (float min, float max) {
			this.min = min;
			this.max = max;
		}
	}
}
