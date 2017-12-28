using Adnc.AnimatorHelpers;

namespace Adnc.AnimatorHelpers.Stubs {
    /// <summary>
    /// Testing only class
    /// </summary>
    public class SingletonStub : Singleton<SingletonStub> {
        public string globalString = "test";
    }
}