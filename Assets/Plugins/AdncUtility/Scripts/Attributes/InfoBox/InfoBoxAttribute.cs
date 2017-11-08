using UnityEngine;

namespace Adnc.Utility {
    public class InfoBoxAttribute : PropertyAttribute {
        public readonly string text;
        public readonly InfoBoxType type;

        public InfoBoxAttribute (string text, InfoBoxType type = InfoBoxType.Info) {
            this.text = text;
            this.type = type;
        }
    }
}