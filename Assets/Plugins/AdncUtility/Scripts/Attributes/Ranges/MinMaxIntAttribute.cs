using UnityEngine;
using System.Collections;

namespace Adnc.Utility {
	public class MinMaxIntAttribute : PropertyAttribute {
		public readonly int min;
		public readonly int max;

		public MinMaxIntAttribute (int min, int max) {
			this.min = min;
			this.max = max;
		}
	}
}
