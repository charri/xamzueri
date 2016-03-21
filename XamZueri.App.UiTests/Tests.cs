using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace XamZueri.App.UiTests
{
    [TestFixture(Platform.Android)]
    [TestFixture(Platform.iOS)]
    public class Tests
    {
        IApp app;
        Platform platform;

        public Tests(Platform platform)
        {
            this.platform = platform;
        }

        [SetUp]
        public void BeforeEachTest()
        {
            app = AppInitializer.StartApp(platform);
        }

        [Test]
        public void AppLaunches()
        {
            app.Screenshot("First screen.");

        }

		[Test]
		public void Event_Detail_Test()
		{
			app.Tap(x => x.Marked("Events"));
			app.Screenshot ("Tapped on Events TabBar");
			app.Tap(x => x.Marked("EventItem"));
			app.Screenshot("Tapped on view EventItem");
			app.ScrollDownTo("BtnEventSignup");
			app.Screenshot("Scrolled to Sign-up on meetup »");
			app.Tap(x => x.Marked("BtnEventSignup"));
			app.Screenshot("Tapped on view BtnEventSignup with Text: 'Sign-up on meetup »'");
			app.Back ();
			app.Screenshot("Tapped on view UINavigationBar with ID: 'Continuous Deployment with Xamarin'");
			app.Tap(x => x.Marked("ToolbarItemShare"));
			app.Screenshot("Tapped on ToolbarItemShare");
		}
    }
}

