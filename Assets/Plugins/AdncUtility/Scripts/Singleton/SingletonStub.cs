namespace Adnc.Utility.Singletons {
    /// <summary>
    /// Testing only class
    /// </summary>
    public class SingletonStub : SingletonBase<SingletonStub> {
        [InfoBox("For testing purposes only. Do not implement", InfoBoxType.Error)]
        public string globalString = "test";
    }
}