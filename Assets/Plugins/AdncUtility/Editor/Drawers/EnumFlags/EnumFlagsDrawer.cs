using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Adnc.Utility.Drawers {
	[CustomPropertyDrawer(typeof(EnumFlagsAttribute))]
	public class EnumFlagsDrawer : PropertyDrawer {
		public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
			EditorGUI.BeginChangeCheck();
			var newVal = EditorGUI.MaskField(position, label, property.intValue, property.enumNames);

			if (EditorGUI.EndChangeCheck()) {
				property.intValue = newVal;
			}
		}
	}
}
