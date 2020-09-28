using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureDevOpsTools.UnitTest.Framework
{
    public abstract class UnitTestBase<TClass>
    {
        [TestInitialize]
        public virtual void Initialize()
        {
        }

        [TestCleanup]
        public virtual void TestCleanup()
        {
        }
    }
}
