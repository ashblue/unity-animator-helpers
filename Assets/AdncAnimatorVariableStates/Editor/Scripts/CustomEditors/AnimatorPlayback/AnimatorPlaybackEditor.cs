using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Adnc.AnimatorVariables.Editors.CustomEditors {
	[CustomEditor(typeof(AnimatorPlayback))]
	public class AnimatorPlaybackEditor : Editor {
		private SortableListAnimatorVariable _listBools;
		private SortableListAnimatorVariable _listFloats;
		private SortableListAnimatorVariable _listInts;
		private SortableListAnimatorVariable _listTriggers;

		private void OnEnable () {
			_listBools = new SortableListAnimatorVariable(this, "bools", "Set Bools");
			_listFloats = new SortableListAnimatorVariable(this, "floats", "Set Floats");
			_listInts = new SortableListAnimatorVariable(this, "ints", "Set Ints");
			_listTriggers = new SortableListAnimatorVariable(this, "triggers", "Set Triggers");
		}

		public override void OnInspectorGUI () {
			_listBools.Update();
			_listFloats.Update();
			_listInts.Update();
			_listTriggers.Update();

			base.OnInspectorGUI();
		}
	}
}


