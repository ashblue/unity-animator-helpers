using UnityEngine;
using UnityEditor;

namespace Adnc.Utility.Drawers {
	[CustomPropertyDrawer(typeof(MinMaxFloatAttribute))]
	public class MinMaxFloatDrawer : MinMaxDrawerBase {
		private MinMaxFloatAttribute _RangeAttr {
			get { return (MinMaxFloatAttribute) attribute; }
		}
		
		protected override float MinRange {
			get { return _RangeAttr.min; }
		}

		protected override float MaxRange {
			get { return _RangeAttr.max; }
		}

		protected override float GetProp (SerializedProperty prop) {
			return prop.floatValue;
		}

		protected override void SetProp (float newVal, SerializedProperty prop) {
			prop.floatValue = Mathf.Round(newVal * 100f) / 100f;
		}

		protected override float FieldNumber (Rect position, float value) {
			return EditorGUI.FloatField(position, value);
		}
	}
}
