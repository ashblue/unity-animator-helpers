using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Adnc.AnimatorHelpers.Variables {
    public abstract class VarBase<T> {
        protected const string VALUE_TOOLTIP = "The value that will be set when SetValue is called";

        [Tooltip("Name of the variable")]
        public string name;

        public virtual bool IsValid {
            get { return !string.IsNullOrEmpty(name); }
        }

        public abstract void SetValue (Animator animator);

        public abstract T GetValue (Animator animator);
    }
}