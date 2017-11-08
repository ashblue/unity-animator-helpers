using System.Linq;
using UnityEditor;
using UnityEngine;

namespace Adnc.Utility.Drawers {
    [CustomPropertyDrawer(typeof(SortLayerAttribute))]
    public class SortLayerDrawer : PropertyDrawer {
        public override void OnGUI (Rect position, SerializedProperty property, GUIContent label) {
            // Draw label
            var rectLabel = position;
            rectLabel.width = EditorGUIUtility.labelWidth;

            GUI.Label(rectLabel, label);

            // Draw Menu
            var rectMenu = position;
            rectMenu.width -= rectLabel.width;
            rectMenu.x += rectLabel.width;

            var current = property.intValue;
            if (GUI.Button(rectMenu, SortingLayer.IDToName(current), EditorStyles.popup)) {
                var menu = GetMenu(current, i => {
                    property.intValue = i.id;
                    property.serializedObject.ApplyModifiedProperties();
                });

                menu.ShowAsContext();
            }
        }

        public static void LayoutPopup (GUIContent label, int current, System.Action<SortingLayer> callback) {
            EditorGUILayout.BeginHorizontal();

            GUILayout.Label(label, GUILayout.Width(EditorGUIUtility.labelWidth));

            if (GUILayout.Button(SortingLayer.IDToName(current), EditorStyles.popup)) {
                var menu = GetMenu(current, callback);
                menu.ShowAsContext();
            }

            EditorGUILayout.EndHorizontal();
        }

        public static GenericMenu GetMenu (int current, System.Action<SortingLayer> callback) {
            var menu = new GenericMenu();

            SortingLayer.layers.ToList().ForEach(l => {
                menu.AddItem(
                    new GUIContent(l.name),
                    current == l.id,
                    () => callback(l));
            });

            return menu;
        }
    }
}