using UnityEngine;
using System.Collections;

namespace Adnc.Utility {
	[System.Serializable]
	public class Flipper : MonoBehaviour {
		[Tooltip("Should point at the graphics layer you wish to flip")]
		[SerializeField] Transform target;
		[HideInInspector] public bool facingRight;

		// Required amount of movement speed required to trigger a flip
		const float flipThreshold = 0.1f;

		public void Awake () {
			UpdateDirection();
		}

		public bool Flip (bool facingRight) {
			// Immediately exit if the direciton is the same
			if (facingRight == this.facingRight) return facingRight;

			this.facingRight = facingRight;

			Vector3 theScale = target.localScale;
			theScale.x = facingRight ? 1f : -1f;

			target.localScale = theScale;

			return facingRight;
		}

		public bool Flip () {
			return Flip(!facingRight);
		}

		public void Flip (float dir) {
			// Do not flip if the passed value doesn't break threshold
			if (Mathf.Abs(dir) >= flipThreshold) {
				Flip(dir > 0f);
			}
		}

		public void FaceTarget (GameObject go) {
			FaceTarget(go.transform.position);
		}

		public void FaceTarget (Transform t) {
			FaceTarget(t.position);
		}

		public void FaceTarget (Vector3 pos) {
			Vector3 heading = pos - target.position;
			Flip(heading.x > 0f);
		}

		public int GetHeading () {
			return target.transform.localScale.x > 0f ? 1 : -1;
		}

		// Update facing right based upon the current local scale
		public void UpdateDirection () {
			facingRight = target.localScale.x > 0f;
		}

		public bool IsFacingOtherTarget (Transform targetOther) {
			return IsFacingOtherTarget(targetOther.position);

		}

		public bool IsFacingOtherTarget (GameObject targetOther) {
			return IsFacingOtherTarget(targetOther.transform.position);
		}

		public bool IsFacingOtherTarget (Vector3 targetPos) {
			bool isOtherTargetOnRight = target.position.x < targetPos.x;
			return isOtherTargetOnRight == facingRight;
		}
	}
}
