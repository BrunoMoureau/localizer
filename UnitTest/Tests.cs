using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace UnitTest
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        private IApp _app;
        private Platform _platform;

        public Tests(Platform platform)
        {
            _platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            _app = AppInitializer.StartApp(_platform);
        }

        [Test]
        public void CanNavigateToSettings()
        {
            //todo

            //AppResult[] results = _app.WaitForElement(c => c.Marked("GO"));

            //Assert.IsTrue(results?.Any());

            //_app.Tap("GO");

            //results = _app.WaitForElement(c => c.Marked("Select a language"));

            //Assert.IsTrue(results?.Any());
        }
    }
}
