using UnityEngine;
using UnityEditor;

namespace Adnc.Utility.Drawers {
	[CustomPropertyDrawer(typeof(MinMaxIntAttribute))]
	public class MinMaxIntDrawer : MinMaxDrawerBase {	
		private MinMaxIntAttribute _RangeAttr {
			get { return ((MinMaxIntAttribute)attribute); }
		}
		
		protected override float MinRange {
			get { return _RangeAttr.min; }
		}

		protected override float MaxRange {
			get { return _RangeAttr.max; }
		}

		protected override float GetProp (SerializedProperty prop) {
			return prop.intValue;
		}

		protected override void SetProp (float newVal, SerializedProperty prop) {
			prop.intValue = Mathf.RoundToInt(newVal);
		}

		protected override float FieldNumber (Rect position, float value) {
			return EditorGUI.IntField(position, Mathf.RoundToInt(value));
		}
	}
}
