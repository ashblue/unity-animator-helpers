using System;
using Adnc.AnimatorVariables.Variables;
using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorVariables.Conditions {
	[Serializable]
	public class Condition {
		const float FLOAT_POINT_COMPARE = 0.01f;
		private const string VAR_TOOLTIP = "The variable data to compare against";
		private const string COMPARE_TOOLTIP = "What is required when comparing to trigger a true event";

		[Tooltip("The variable type to target")]
		public ConditionVarType variableType;

		// ***** Bools

		[Tooltip(VAR_TOOLTIP)]
		[ShowToggle("variableType", new []{0})]
		public VarBool variableBool = new VarBool();

		// ***** Numbers

		[Tooltip("How should the animator value be compared to the declared value")]
		[ShowToggle("variableType", new []{1,2})]
		public OperatorAll compareValues;

		[Tooltip(VAR_TOOLTIP)]
		[ShowToggle("variableType", new []{1})]
		public VarFloat variableFloat = new VarFloat();

		[Tooltip(VAR_TOOLTIP)]
		[ShowToggle("variableType", new []{2})]
		public VarInt variableInt = new VarInt();

		public bool IsConditionMet (Animator animator) {
			if (animator == null) {
				return true;
			}

			switch (variableType) {
				case ConditionVarType.Bool:
					return animator.GetBool(variableBool.name) == variableBool.value;
				case ConditionVarType.Float:
					return AreEqual(compareValues, animator.GetFloat(variableFloat.name), variableFloat.value);
				case ConditionVarType.Int:
					return AreEqual(compareValues, animator.GetInteger(variableInt.name), variableInt.value);
				default:
					throw new ArgumentOutOfRangeException();
			}
		}

		static bool AreEqual (OperatorAll operation, int a, int b) {
			switch (operation) {
				case OperatorAll.AreEqual:
					return a == b;
				case OperatorAll.AreNotEqual:
					return a != b;
				case OperatorAll.OriginalIsGreaterThan:
					return a > b;
				case OperatorAll.OriginalIsGreaterThanOrEqualTo:
					return a >= b;
				case OperatorAll.OriginalIsLessThan:
					return a < b;
				case OperatorAll.OriginalIsLessThanOrEqualTo:
					return a <= b;
				default:
					throw new ArgumentOutOfRangeException("operation", operation, null);
			}
		}

		static bool AreEqual (OperatorAll operation, float a, float b) {
			switch (operation) {
				case OperatorAll.AreEqual:
					return Math.Abs(a - b) < FLOAT_POINT_COMPARE;
				case OperatorAll.AreNotEqual:
					return Math.Abs(a - b) > FLOAT_POINT_COMPARE;
				case OperatorAll.OriginalIsGreaterThan:
					return a > b;
				case OperatorAll.OriginalIsGreaterThanOrEqualTo:
					return a >= b;
				case OperatorAll.OriginalIsLessThan:
					return a < b;
				case OperatorAll.OriginalIsLessThanOrEqualTo:
					return a <= b;
				default:
					throw new ArgumentOutOfRangeException("operation", operation, null);
			}
		}
	}
}

