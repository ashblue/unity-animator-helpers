using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Adnc.Utility.Drawers {
    [CustomPropertyDrawer(typeof(ShowToggleAttribute))]
    public class ShowToggleDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            var toggle = (ShowToggleAttribute)attribute;
            var display = GetDisplay(toggle, property);

            switch (display) {
                case ShowToggleDisplay.Show:
                    EditorGUI.PropertyField(position, property, label, true);
                    break;
                case ShowToggleDisplay.Hide:
                    break;
                case ShowToggleDisplay.Disable:
                    GUI.enabled = false;
                    EditorGUI.PropertyField(position, property, label, true);
                    GUI.enabled = true;
                    break;
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
            var toggle = (ShowToggleAttribute)attribute;
            var display = GetDisplay(toggle, property);

            switch (display) {
                case ShowToggleDisplay.Show:
                    return EditorGUI.GetPropertyHeight(property, label);
                case ShowToggleDisplay.Hide:
                    return 0;
                case ShowToggleDisplay.Disable:
                    return EditorGUI.GetPropertyHeight(property, label);
                default:
                    throw new System.ArgumentOutOfRangeException();
            }
        }

        static ShowToggleDisplay GetDisplay (ShowToggleAttribute toggle, SerializedProperty property) {
            var isValid = GetIsValid(toggle, property);

            return isValid ? toggle.validDisplay : toggle.invalidDisplay;
        }

        static bool GetIsValid (ShowToggleAttribute toggle, SerializedProperty property) {
            if (toggle.IsEnum) {
                return GetIsValidEnum(toggle, property);
            }

            return GetIsValidBool(toggle, property);
        }

        static bool GetIsValidBool (ShowToggleAttribute toggle, SerializedProperty property) {
            var propertyPath = property.propertyPath;
            var conditionPath = propertyPath.Replace(property.name, toggle.fieldName);
            var condition = property.serializedObject.FindProperty(conditionPath);

            if (condition != null) {
                return condition.boolValue == toggle.requiredValue;
            }

            Debug.LogWarningFormat("[ShowToggle] could not find attribute {0}", toggle.fieldName);

            return true;
        }

        static bool GetIsValidEnum (ShowToggleAttribute toggle, SerializedProperty property) {
            var propertyPath = property.propertyPath;
            var conditionPath = propertyPath.Replace(property.name, toggle.fieldName);
            var condition = property.serializedObject.FindProperty(conditionPath);

            if (condition != null) {
                return toggle.requiredEnumValue.Contains(condition.enumValueIndex);
            }

            Debug.LogWarningFormat("[ShowToggle] could not find attribute {0}", toggle.fieldName);

            return true;
        }
    }
}
