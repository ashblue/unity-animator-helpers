using UnityEditor;
using UnityEngine;

namespace Adnc.Utility.Drawers {
    public abstract class MinMaxDrawerBase : PropertyDrawer {
        protected const float _LINE_GAP = 2;
        protected float _blockHeight;
        
        protected abstract float MinRange { get; }
        protected abstract float MaxRange { get; }
        
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            var line1 = position;
            line1.height = _blockHeight;
			
            var line2 = line1;
            line2.y += _blockHeight + _LINE_GAP;

            var colA = line2;
            colA.width /= 3;

            var colB = line2;
            colB.width /= 3;
            colB.x += line2.width / 3;

            var colC = line2;
            colC.width /= 3;
            colC.x += line2.width / 3 * 2;
			
            var propMin = property.FindPropertyRelative("min");
            var propMax = property.FindPropertyRelative("max");

            var min = GetProp(propMin);
            var max = GetProp(propMax);
            
            EditorGUI.BeginProperty(position, label, property);
            EditorGUI.MinMaxSlider(line1, label, ref min, ref max, MinRange, MaxRange);

            min = FieldNumber(colA, min);
            max = FieldNumber(colC, max);
            EditorGUI.LabelField(colB, "Range: " + Mathf.Abs(min - max), EditorStyles.centeredGreyMiniLabel);

            SetProp(min, propMin);
            SetProp(max, propMax);

            EditorGUI.EndProperty();
        }
        
        protected abstract float GetProp (SerializedProperty propMin);
        protected abstract void SetProp (float newVal, SerializedProperty prop);
        protected abstract float FieldNumber (Rect position, float value);

        public override float GetPropertyHeight (SerializedProperty property, GUIContent label) {
            _blockHeight = EditorStyles.textField.CalcHeight(new GUIContent("Test"), EditorGUIUtility.currentViewWidth);
			
            var height = _blockHeight * 2;
            height += _LINE_GAP;

            return height;
        }
    }
}