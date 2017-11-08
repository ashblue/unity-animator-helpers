using System;
using System.Collections;
using System.Collections.Generic;
using Adnc.AnimatorVariables.Variables;
using UnityEngine;

namespace Adnc.AnimatorVariables {
	[CreateAssetMenu(fileName = "Playback", menuName = "ADNC/Animator Variables/Animator Playback", order = 1)]
	public class AnimatorPlayback : ScriptableObject {
		[HideInInspector]
		public List<VarBool> bools = new List<VarBool>();

		[HideInInspector]
		public List<VarFloat> floats = new List<VarFloat>();

		[HideInInspector]
		public List<VarInt> ints = new List<VarInt>();

		[HideInInspector]
		public List<VarTrigger> triggers = new List<VarTrigger>();

		[Tooltip("If a condition is required to complete the animator playback")]
		public bool waitForCondition;

		/// <summary>
		/// Set the Animator variables
		/// </summary>
		/// <param name="anim"></param>
		/// <param name="completeCallback">Fired when the complete condition is met. No complete
		/// condition will cause this to fire immediately</param>
		public void Play (Animator anim, Action completeCallback = null) {
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

			// @TODO Start coroutine here (see old implementation in pathfinding 2D)
		}
	}
}

