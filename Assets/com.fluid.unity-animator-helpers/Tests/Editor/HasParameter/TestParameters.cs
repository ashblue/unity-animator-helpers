using Adnc.AnimatorHelpers.HasParameters;
using NUnit.Framework;

namespace Adnc.AnimatorHelpers.Editors.Testing.HasParameters {
    [TestFixture(Category = "HasParameter")]
    public class TestParameters {
        [Test]
        public void AddIncrementsList () {
            var p = new Parameters<bool>();

            p.Add("a", true);

            Assert.That(p.list.Count, Is.GreaterThan(0));
        }

        [Test]
        public void AddInjectsKeyValueIntoList () {
            var p = new Parameters<bool>();

            var kv = p.Add("a", true);

            Assert.That(p.list, Contains.Item(kv));
        }

        [Test]
        public void AddInjectsKeyValueIntoDictionary () {
            var p = new Parameters<bool>();

            var kv = p.Add("a", true);

            Assert.That(p.dic, Contains.Key(kv.key));
            Assert.IsTrue(p.dic.ContainsValue(kv));
        }
    }
}
