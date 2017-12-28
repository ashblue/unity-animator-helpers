using Adnc.AnimatorHelpers;

namespace Adnc.AnimatorHelpers.Editors.Testing.Stubs {
    public class SingletonStub : Singleton<SingletonStub> {
        public string globalString = "test";
    }
}