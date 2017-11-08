using UnityEngine;

namespace Adnc.Utility {
    public class ShowToggleAttribute : PropertyAttribute {
        private const ShowToggleDisplay DEFAULT_VALID_DISPLAY = ShowToggleDisplay.Show;
        private const ShowToggleDisplay DEFAULT_INVALID_DISPLAY = ShowToggleDisplay.Hide;

        /// <summary>
        /// Name of the field required to show this attribute. Accepts dot notation.
        /// Example `myObj.myProp`. Must point to a field that is a boolean.
        /// </summary>
        public string fieldName;

        /// <summary>
        /// Value required by the fieldName's value when turned into a bool
        /// </summary>
        public bool requiredValue;

        /// <summary>
        /// Value required by the fieldName's value when turned into an enum
        /// </summary>
        public int[] requiredEnumValue;

        /// <summary>
        /// How to handle displaying an invalid value
        /// </summary>
        public ShowToggleDisplay invalidDisplay;

        /// <summary>
        /// How to handle displaying a valid value
        /// </summary>
        public ShowToggleDisplay validDisplay;

        public bool IsEnum {
            get { return requiredEnumValue != null; }
        }

        public ShowToggleAttribute (
            string fieldName, bool requiredValue = true, ShowToggleDisplay invalidDisplay = DEFAULT_INVALID_DISPLAY,
            ShowToggleDisplay validDisplay = DEFAULT_VALID_DISPLAY) {
            this.fieldName = fieldName;
            this.requiredValue = requiredValue;
            this.invalidDisplay = invalidDisplay;
            this.validDisplay = validDisplay;
        }

        public ShowToggleAttribute (
            string fieldName, int[] requiredEnumValue, ShowToggleDisplay invalidDisplay = DEFAULT_INVALID_DISPLAY,
            ShowToggleDisplay validDisplay = DEFAULT_VALID_DISPLAY) {
            this.fieldName = fieldName;
            this.requiredEnumValue = requiredEnumValue;
            this.invalidDisplay = invalidDisplay;
            this.validDisplay = validDisplay;
        }
    }
}