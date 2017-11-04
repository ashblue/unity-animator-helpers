using UnityEditor;
using UnityEngine;

namespace Adnc.Utility.Drawers {
    [CustomPropertyDrawer(typeof(TagAttribute))]
    public class TagAttributeDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            property.stringValue = EditorGUI.TagField(position, label, property.stringValue);
        }
    }
}