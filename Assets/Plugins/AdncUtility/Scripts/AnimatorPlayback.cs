using UnityEngine;

namespace Adnc.Utility {
	[System.Serializable]
	public class AnimatorPlayback {
		// When playing an animation twice it will always reset
		[System.NonSerialized, HideInInspector] public bool resetAnimationOnPlay = true;

		[Tooltip("Name of the state to play")]
		public string state;

		[Tooltip("Layer of the state to play")]
		public int layer;

		/// <summary>
		/// Plays a specific animation state if a string was passed
		/// </summary>
		/// <param name="anim">Animation.</param>
		public void Play (Animator anim) {
			if (anim != null && !string.IsNullOrEmpty(state)) {
				if (resetAnimationOnPlay) {
					anim.Play(state, layer, 0f);
				} else {
					anim.Play(state, layer);
				}
			}

		}
			
		/// <summary>
		/// Check if the current animation is fully complete.
		/// @NOTE You need a full frame to pass for this to take effect from calling Play().
		/// </summary>
		/// <returns><c>true</c> if this instance is complete the specified anim; otherwise, <c>false</c>.</returns>
		/// <param name="anim">Animation.</param>
		public bool IsComplete (Animator anim) {
			if (anim == null) return true;
			return !anim.GetCurrentAnimatorStateInfo(layer).IsName(state);
		}
	}
}
