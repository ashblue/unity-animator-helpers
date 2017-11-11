using System.Collections;
using System.Collections.Generic;
using Adnc.Utility.Editors;
using UnityEditor;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Editors.CustomEditors {
	public class SortableListAnimatorVariable : SortableListBase {
		public SortableListAnimatorVariable (Editor editor, string property, string title) : base(editor, property, title) {
			_list.drawElementCallback = (rect, index, active, focused) => {
				var element = _serializedProp.GetArrayElementAtIndex(index);
				var propName = element.FindPropertyRelative("name");
				var propValue = element.FindPropertyRelative("value");

				rect.height -= EditorGUIUtility.standardVerticalSpacing;

				if (propValue != null) {
					var col1 = rect;
					col1.width /= 2;
					col1.width -= EditorGUIUtility.standardVerticalSpacing;
					EditorGUI.PropertyField(col1, propName, new GUIContent());

					var col2 = col1;
					col2.x += col1.width + EditorGUIUtility.standardVerticalSpacing;
					EditorGUI.PropertyField(col2, propValue, new GUIContent());
				} else {
					EditorGUI.PropertyField(rect, propName, new GUIContent());
				}
			};
		}
	}
}

