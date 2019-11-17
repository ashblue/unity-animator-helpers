using System.Collections;
using UnityEngine;

namespace Adnc.AnimatorHelpers {
    public interface IAnimatorPlayback {
        bool Play (Animator anim);
        IEnumerator PlayCoroutine (Animator anim);
        bool IsConditionsMet (Animator anim);
    }
}
