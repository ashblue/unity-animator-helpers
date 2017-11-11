using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

namespace Adnc.Utility.Editors {
	public abstract class SortableListBase {
		protected ReorderableList _list;
		protected Editor _editor;

		protected SerializedObject _serializedObject;
		protected SerializedProperty _serializedProp;

		public SortableListBase (Editor editor, string property, string title) {
			if (editor == null) {
				Debug.LogError("Editor cannot be null");
				return;
			}
            
			_serializedProp = editor.serializedObject.FindProperty(property);
			_serializedObject = editor.serializedObject;

			if (_serializedProp == null) {
				Debug.LogErrorFormat("Could not find property {0}", property);
				return;
			}

			_list = new ReorderableList(
				_serializedObject, 
				_serializedProp, 
				true, true, true, true);
            
			_list.drawHeaderCallback = rect => {  
				EditorGUI.LabelField(rect, title);
			};
		}

		public void Update () {
			_serializedObject.Update();

			if (_list != null) {
				_list.DoLayoutList();
			}

			_serializedObject.ApplyModifiedProperties();
		}
	}
}