using System;
using UnityEditor;
using UnityEngine;

namespace Adnc.Utility.Drawers {
    [CustomPropertyDrawer(typeof(InfoBoxAttribute))]
    public class InfoBoxDrawer : DecoratorDrawer {
        InfoBoxAttribute InfoBox {
            get { return (InfoBoxAttribute)attribute; }
        }

        private float _helpHeight;
        private const float _GAP_MIDDLE = 3;

        public override float GetHeight () {
            var style = EditorStyles.helpBox;
            var content = new GUIContent(InfoBox.text);
            _helpHeight = style.CalcHeight(content, EditorGUIUtility.currentViewWidth);

            return _helpHeight + _GAP_MIDDLE;
        }

        public override void OnGUI (Rect position) {
            var infoBox = position;
            infoBox.height = _helpHeight;
            EditorGUI.HelpBox(infoBox, InfoBox.text, InfoBoxTypeToHelpBoxType(InfoBox.type));
        }

        static MessageType InfoBoxTypeToHelpBoxType (InfoBoxType type) {
            switch (type) {
                case InfoBoxType.None:
                    return MessageType.None;
                case InfoBoxType.Info:
                    return MessageType.Info;
                case InfoBoxType.Warning:
                    return MessageType.Warning;
                case InfoBoxType.Error:
                    return MessageType.Error;
                default:
                    throw new ArgumentOutOfRangeException("type", type, null);
            }
        }
    }
}