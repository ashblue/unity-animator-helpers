using System;
using System.Collections;
using System.Collections.Generic;
using Adnc.AnimatorHelpers.Conditions;
using Adnc.AnimatorHelpers.Variables;
using Adnc.Utility;
using UnityEngine;

namespace Adnc.AnimatorHelpers {
	[CreateAssetMenu(fileName = "Playback", menuName = "ADNC/Animator Variables/Animator Playback", order = 1)]
	public class AnimatorPlayback : ScriptableObject, IAnimatorPlayback {
		[HideInInspector]
		public List<VarBool> bools = new List<VarBool>();

		[HideInInspector]
		public List<VarFloat> floats = new List<VarFloat>();

		[HideInInspector]
		public List<VarInt> ints = new List<VarInt>();

		[HideInInspector]
		public List<VarTrigger> triggers = new List<VarTrigger>();

		[Tooltip("If a condition is required to complete the animator playback. When the condition is met" +
		         " a true event will be fired")]
		public bool waitForCondition;

		public List<Condition> conditions = new List<Condition> {
			new Condition()
		};

		/// <summary>
		/// Play the animation without a callback that checks if a specific condition has been met
		/// </summary>
		/// <param name="anim"></param>
		/// <returns></returns>
		public bool Play (Animator anim) {
			if (anim == null) {
				return false;
			}

			foreach (var varBool in bools) {
				anim.SetBool(varBool.name, varBool.value);
			}

			foreach (var varFloat in floats) {
				anim.SetFloat(varFloat.name, varFloat.value);
			}

			foreach (var varInt in ints) {
				anim.SetInteger(varInt.name, varInt.value);
			}

			foreach (var varTrigger in triggers) {
				anim.SetTrigger(varTrigger.name);
			}

			return true;
		}

		/// <summary>
		/// Play the animation with a coroutine that returns when the required condition has been met
		/// </summary>
		/// <param name="anim"></param>
		/// <returns></returns>
		public IEnumerator PlayCoroutine (Animator anim) {
			if (!Play(anim) || !waitForCondition) {
				yield break;
			}

			while (!IsConditionsMet(anim)) {
				yield return null;
			}
		}

		/// <summary>
		/// Checks if all conditions on the animator have been met
		/// </summary>
		/// <param name="anim"></param>
		/// <returns></returns>
		public bool IsConditionsMet (Animator anim) {
			var isValid = true;
			foreach (var condition in conditions) {
				isValid = condition.IsConditionMet(anim);
				if (!isValid) break;
			}

			return isValid;
		}
	}
}

